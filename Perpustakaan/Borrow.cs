using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Perpustakaan
{
    public partial class Borrow : Form
    {
        private readonly string _bookId;

        public Borrow(string bookId)
        {
            InitializeComponent();
            _bookId = bookId;

            // biar tidak bisa edit manual
            textBox_bookid.ReadOnly = true;
            textBox_title.ReadOnly = true;
        }

        private void Borrow_Load(object sender, EventArgs e)
        {
            // isi book id
            textBox_bookid.Text = _bookId;

            // set tanggal pinjam default hari ini
            dateTimePicker_tglpinjam.Value = DateTime.Today;

            // load data
            LoadMembers();
            LoadBookTitle(_bookId);

            // set due date +7
            UpdateDueDate();
        }

        private void LoadMembers()
        {
            using var conn = Db.Conn();
            conn.Open();

            using var da = new MySqlDataAdapter(
                "SELECT user_id, username FROM users WHERE role='anggota' ORDER BY username;", conn);

            var dt = new DataTable();
            da.Fill(dt);

            comboBox_member.DataSource = dt;
            comboBox_member.DisplayMember = "username";
            comboBox_member.ValueMember = "user_id";
        }

        private void LoadBookTitle(string bookId)
        {
            using var conn = Db.Conn();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT title FROM books WHERE book_id=@id LIMIT 1;";
            cmd.Parameters.AddWithValue("@id", bookId);

            var titleObj = cmd.ExecuteScalar();
            textBox_title.Text = titleObj?.ToString() ?? "";
        }

        private void UpdateDueDate()
        {
            var due = dateTimePicker_tglpinjam.Value.Date.AddDays(7);
            label_auto7hari.Text = due.ToString("yyyy-MM-dd");
        }

        private void dateTimePicker_tglpinjam_ValueChanged(object sender, EventArgs e)
        {
            UpdateDueDate();
        }

        private void button_simpan_Click(object sender, EventArgs e)
        {
            if (comboBox_member.SelectedValue == null)
            {
                MessageBox.Show("Pilih anggota.");
                return;
            }

            int userId = Convert.ToInt32(comboBox_member.SelectedValue); // INT (AUTO_INCREMENT)
            string bookId = _bookId;
            var loanDate = dateTimePicker_tglpinjam.Value.Date;
            var dueDate = loanDate.AddDays(7);

            try
            {
                using var conn = Db.Conn();
                conn.Open();
                using var tx = conn.BeginTransaction();

                // 1) Pastikan buku tersedia + ubah status -> dipinjam
                using (var cmd = conn.CreateCommand())
                {
                    cmd.Transaction = tx;
                    cmd.CommandText = @"
                UPDATE books
                SET status='dipinjam'
                WHERE book_id=@b AND status='tersedia';
            ";
                    cmd.Parameters.AddWithValue("@b", bookId);

                    var rows = cmd.ExecuteNonQuery();
                    if (rows != 1)
                    {
                        tx.Rollback();
                        MessageBox.Show("Buku tidak tersedia / sudah dipinjam.");
                        return;
                    }
                }

                // 2) Insert loan TANPA loan_id (karena AUTO_INCREMENT)
                using (var cmd = conn.CreateCommand())
                {
                    cmd.Transaction = tx;
                    cmd.CommandText = @"
                INSERT INTO loans (user_id, book_id, loan_date, due_date, returned_at)
                VALUES (@uid, @bid, @ld, @dd, NULL);
            ";
                    cmd.Parameters.AddWithValue("@uid", userId);
                    cmd.Parameters.AddWithValue("@bid", bookId);
                    cmd.Parameters.AddWithValue("@ld", loanDate);
                    cmd.Parameters.AddWithValue("@dd", dueDate);

                    cmd.ExecuteNonQuery();
                }

                tx.Commit();
                MessageBox.Show("Peminjaman berhasil!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal simpan:\n" + ex.Message);
            }
        }


        private void button_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      }
    }

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySqlConnector;

namespace Perpustakaan
{
    public partial class ManageBooks : Form
    {
        public ManageBooks()
        {
            InitializeComponent();
        }

        private void MenageBooks_Load(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void LoadBooks()
        {
            try
            {
                var list = new List<Book>();

                using var conn = Db.Conn();
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT book_id, title, author, status FROM books ORDER BY title;";

                using var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    list.Add(new Book
                    {
                        BookId = Convert.ToInt32(r["book_id"]),
                        Title = r["title"]?.ToString() ?? "",
                        Author = r["author"]?.ToString() ?? "",
                        Status = r["status"]?.ToString() ?? ""
                    });
                }

                dataGridView_books.AutoGenerateColumns = true;
                dataGridView_books.DataSource = list;

                dataGridView_books.ReadOnly = true;
                dataGridView_books.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView_books.MultiSelect = false;

                // Header bagus
                if (dataGridView_books.Columns.Contains("BookId"))
                    dataGridView_books.Columns["BookId"].HeaderText = "Book ID";
                if (dataGridView_books.Columns.Contains("Title"))
                    dataGridView_books.Columns["Title"].HeaderText = "Judul";
                if (dataGridView_books.Columns.Contains("Author"))
                    dataGridView_books.Columns["Author"].HeaderText = "Penulis";
                if (dataGridView_books.Columns.Contains("Status"))
                    dataGridView_books.Columns["Status"].HeaderText = "Status";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load books:\n" + ex.Message);
            }
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void button_tambahbook_Click(object sender, EventArgs e)
        {
            new AddBook().ShowDialog();
            LoadBooks();
        }

        private void button_hapusbook_Click(object sender, EventArgs e)
        {
            if (dataGridView_books.CurrentRow == null)
            {
                MessageBox.Show("Pilih buku dulu.");
                return;
            }

            int bookId = Convert.ToInt32(dataGridView_books.CurrentRow.Cells["BookId"].Value);
            string status = dataGridView_books.CurrentRow.Cells["Status"].Value?.ToString() ?? "";

            if (status.Equals("dipinjam", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Buku sedang dipinjam. Tidak bisa dihapus.");
                return;
            }

            if (HasActiveLoans(bookId))
            {
                MessageBox.Show("Buku masih punya peminjaman aktif. Tidak bisa dihapus.");
                return;
            }

            var confirm = MessageBox.Show($"Hapus buku ID {bookId}?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using var conn = Db.Conn();
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM books WHERE book_id=@id;";
                cmd.Parameters.AddWithValue("@id", bookId);

                var rows = cmd.ExecuteNonQuery();
                if (rows != 1)
                {
                    MessageBox.Show("Buku tidak ditemukan.");
                    return;
                }

                MessageBox.Show("Buku berhasil dihapus.");
                LoadBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal hapus buku:\n" + ex.Message);
            }
        }

        private bool HasActiveLoans(int bookId)
        {
            using var conn = Db.Conn();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM loans WHERE book_id=@id AND returned_at IS NULL;";
            cmd.Parameters.AddWithValue("@id", bookId);

            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        private void dataGridView_books_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // boleh kosong
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

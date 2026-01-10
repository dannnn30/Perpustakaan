using Microsoft.VisualBasic.ApplicationServices;
using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Perpustakaan
{
    public partial class ManageUsers : Form
    {
        public ManageUsers()
        {
            InitializeComponent();
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                var list = new List<User>();

                using var conn = Db.Conn();
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT user_id, username, password, role FROM users ORDER BY role, username;";

                using var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    list.Add(new User
                    {
                        UserId = Convert.ToInt32(r["user_id"]),
                        Username = r["username"]?.ToString() ?? "",
                        Password = r["password"]?.ToString() ?? "",
                        Role = r["role"]?.ToString() ?? ""
                    });

                }

                dataGridView_users.AutoGenerateColumns = true;
                dataGridView_users.DataSource = list;

                dataGridView_users.ReadOnly = true;
                dataGridView_users.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView_users.MultiSelect = false;

                // Sembunyikan password
                if (dataGridView_users.Columns.Contains("Password"))
                    dataGridView_users.Columns["Password"].Visible = false;

                // Ubah header
                if (dataGridView_users.Columns.Contains("UserId"))
                    dataGridView_users.Columns["UserId"].HeaderText = "User ID";
                if (dataGridView_users.Columns.Contains("Username"))
                    dataGridView_users.Columns["Username"].HeaderText = "Username";
                if (dataGridView_users.Columns.Contains("Role"))
                    dataGridView_users.Columns["Role"].HeaderText = "Role";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load users:\n" + ex.Message);
            }
        }

        // ADD USER
        private void button_tambah_Click(object sender, EventArgs e)
        {
            new AddUser().ShowDialog();
            LoadUsers();
        }

        // REMOVE USER (hapus user yang dipilih di grid)
        private void button_hapususers_Click(object sender, EventArgs e)
        {
            if (dataGridView_users.CurrentRow == null)
            {
                MessageBox.Show("Pilih user dulu di tabel.");
                return;
            }

            var userIdObj = dataGridView_users.CurrentRow.Cells["UserId"].Value;
            if (userIdObj == null)
            {
                MessageBox.Show("User ID tidak valid.");
                return;
            }

            int userId = Convert.ToInt32(userIdObj);

            // Cegah hapus jika masih ada pinjaman aktif
            if (HasActiveLoans(userId))
            {
                MessageBox.Show("User masih punya peminjaman aktif. Tidak bisa dihapus.");
                return;
            }

            var confirm = MessageBox.Show($"Hapus user ID {userId} ?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using var conn = Db.Conn();
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM users WHERE user_id=@id;";
                cmd.Parameters.AddWithValue("@id", userId);

                var rows = cmd.ExecuteNonQuery();
                if (rows != 1)
                {
                    MessageBox.Show("User tidak ditemukan.");
                    return;
                }

                MessageBox.Show("User berhasil dihapus.");
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal hapus user:\n" + ex.Message);
            }
        }


        private bool HasActiveLoans(int userId)
        {
            using var conn = Db.Conn();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM loans WHERE user_id=@id AND returned_at IS NULL;";
            cmd.Parameters.AddWithValue("@id", userId);

            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }


        // REFRESH
        private void button_refresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void dataGridView_users_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // boleh kosong
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

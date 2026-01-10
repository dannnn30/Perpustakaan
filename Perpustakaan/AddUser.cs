using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySqlConnector;


namespace Perpustakaan
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();

            textBox_password.UseSystemPasswordChar = true;

            comboBox_role.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_role.Items.Clear();
            comboBox_role.Items.Add("anggota");
            comboBox_role.Items.Add("petugas");
            comboBox_role.SelectedIndex = 0;
        }



        private void textBox_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_role_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_add_Click(object sender, EventArgs e)
        {
            var user = new User
            {
                Username = textBox_username.Text.Trim(),
                Password = textBox_password.Text,
                Role = comboBox_role.SelectedItem?.ToString() ?? ""
            };

            if (user.Username == "" || user.Password == "" || user.Role == "")
            {
                MessageBox.Show("Username, Password, dan Role wajib diisi.");
                return;
            }

            try
            {
                using var conn = Db.Conn();
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
            INSERT INTO users (username, password, role)
            VALUES (@u, @p, @r);
        ";
                cmd.Parameters.AddWithValue("@u", user.Username);
                cmd.Parameters.AddWithValue("@p", user.Password);
                cmd.Parameters.AddWithValue("@r", user.Role);

                cmd.ExecuteNonQuery();

                long newId = cmd.LastInsertedId; // ID dari AUTO_INCREMENT
                MessageBox.Show($"User berhasil ditambahkan. ID: {newId}");

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal tambah user:\n" + ex.Message);
            }
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

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
    public partial class AddBook : Form
    {
        public AddBook()
        {
            InitializeComponent();
        }

        private void textBox_judul_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_penulis_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_tambahbuku_Click(object sender, EventArgs e)
        {
            var judul = textBox_judul.Text.Trim();
            var penulis = textBox_penulis.Text.Trim();

            if (string.IsNullOrWhiteSpace(judul))
            {
                MessageBox.Show("Judul wajib diisi.");
                return;
            }

            try
            {
                using var conn = Db.Conn();
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
            INSERT INTO books (title, author, status)
            VALUES (@t, @a, 'tersedia');
        ";
                cmd.Parameters.AddWithValue("@t", judul);
                cmd.Parameters.AddWithValue("@a", penulis);

                cmd.ExecuteNonQuery();
                long newId = cmd.LastInsertedId;

                MessageBox.Show($"Buku berhasil ditambahkan. ID: {newId}");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal tambah buku:\n" + ex.Message);
            }
        }

        private void button_close_Click(object sender, EventArgs e)
        {

        }
    }
}

using System.Data;
using MySqlConnector;

namespace Perpustakaan
{
    public partial class Catalog : Form
    {
        private readonly string _role;

        public Catalog(string role)
        {
            InitializeComponent();
            _role = role;

            // Tombol pinjam hanya untuk petugas
            button_borrow.Visible = (_role == "petugas");
        }

        private void Catalog_Load(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void LoadBooks(string? keyword = null)
        {
            using var conn = Db.Conn();
            conn.Open();

            string sql = "SELECT book_id, title AS 'Judul', author AS 'Penulis', status AS 'Status' FROM books";
            if (!string.IsNullOrWhiteSpace(keyword))
                sql += " WHERE title LIKE @kw OR author LIKE @kw";
            sql += " ORDER BY title;";

            using var cmd = new MySqlCommand(sql, conn);
            if (!string.IsNullOrWhiteSpace(keyword))
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

            using var da = new MySqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);

            dataGridView_books.AutoGenerateColumns = true;
            dataGridView_books.DataSource = dt;

            // rapihin
            dataGridView_books.ReadOnly = true;
            dataGridView_books.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_books.MultiSelect = false;
            if (dataGridView_books.Columns.Contains("book_id"))
                dataGridView_books.Columns["book_id"].Visible = false;
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            LoadBooks(textBox_search.Text.Trim());
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            textBox_search.Clear();
            LoadBooks();
        }

        private void button_borrow_Click(object sender, EventArgs e)
        {
            if (_role != "petugas")
            {
                MessageBox.Show("Hanya petugas yang bisa meminjamkan buku.");
                return;
            }
            {
                if (dataGridView_books.CurrentRow == null)
                {
                    MessageBox.Show("Pilih buku dulu.");
                    return;
                }

                var status = dataGridView_books.CurrentRow.Cells["Status"].Value?.ToString() ?? "";
                if (!status.Equals("tersedia", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Buku tidak tersedia (sedang dipinjam).");
                    return;
                }

                var bookId = dataGridView_books.CurrentRow.Cells["book_id"].Value?.ToString();
                if (string.IsNullOrWhiteSpace(bookId))
                {
                    MessageBox.Show("Book ID tidak terbaca.");
                    return;
                }

                var f = new Borrow(bookId);
                f.ShowDialog();

                LoadBooks(textBox_search.Text.Trim()); // refresh
            }
        }

        private void button_closecat_Click(object sender, EventArgs e)
        {
            this.Close();
            var f = new Login();
            f.Show();
        }

        private void button_menageuser_Click(object sender, EventArgs e)
        {
            if (_role != "petugas")
            {
                MessageBox.Show("Hanya petugas.");
                return;
            }

            new ManageUsers().ShowDialog();
        }

        private void button_menagebooks_Click(object sender, EventArgs e)
        {
            if (_role != "petugas")
            {
                MessageBox.Show("Hanya petugas.");
                return;
            }

            new ManageBooks().ShowDialog();
            LoadBooks(); // refresh katalog setelah kelola buku
        }

        private void button_return_Click(object sender, EventArgs e)
        {
            if (_role != "petugas")
            {
                MessageBox.Show("Hanya petugas.");
                return;
            }

            new ReturnBooks().ShowDialog();
            LoadBooks(); // refresh katalog setelah pengembalian
        }

    }
}

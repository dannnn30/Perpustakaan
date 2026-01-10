using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;

namespace Perpustakaan
{
    public partial class ReturnBooks : Form
    {
        public ReturnBooks()
        {
            InitializeComponent();
        }

        private void ReturnBooks_Load(object sender, EventArgs e)
        {
            LoadActiveLoans();
        }

        private void LoadActiveLoans()
        {
            try
            {
                using var conn = Db.Conn();
                conn.Open();

                string sql = @"
                    SELECT
                        l.loan_id,
                        l.book_id,
                        b.title   AS 'Judul',
                        b.author  AS 'Penulis',
                        u.username AS 'Anggota',
                        l.loan_date AS 'Tgl Pinjam',
                        l.due_date  AS 'Jatuh Tempo'
                    FROM loans l
                    JOIN books b ON b.book_id = l.book_id
                    JOIN users u ON u.user_id = l.user_id
                    WHERE l.returned_at IS NULL
                    ORDER BY l.loan_date DESC;
                ";

                using var da = new MySqlDataAdapter(sql, conn);
                var dt = new DataTable();
                da.Fill(dt);

                dataGridView_loans.DataSource = dt;
                dataGridView_loans.ReadOnly = true;
                dataGridView_loans.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView_loans.MultiSelect = false;

                // sembunyikan kolom id internal
                if (dataGridView_loans.Columns.Contains("loan_id"))
                    dataGridView_loans.Columns["loan_id"].Visible = false;
                if (dataGridView_loans.Columns.Contains("book_id"))
                    dataGridView_loans.Columns["book_id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load peminjaman aktif:\n" + ex.Message);
            }
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            LoadActiveLoans();
        }

        private void button_kembalikan_Click(object sender, EventArgs e)
        {
            if (dataGridView_loans.CurrentRow == null)
            {
                MessageBox.Show("Pilih data peminjaman dulu.");
                return;
            }

            int loanId = Convert.ToInt32(dataGridView_loans.CurrentRow.Cells["loan_id"].Value);
            int bookId = Convert.ToInt32(dataGridView_loans.CurrentRow.Cells["book_id"].Value);

            var judul = dataGridView_loans.CurrentRow.Cells["Judul"].Value?.ToString() ?? "";
            var confirm = MessageBox.Show($"Kembalikan buku: {judul} ?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using var conn = Db.Conn();
                conn.Open();
                using var tx = conn.BeginTransaction();

                // 1) update returned_at (pastikan masih aktif)
                using (var cmd = conn.CreateCommand())
                {
                    cmd.Transaction = tx;
                    cmd.CommandText = @"
                        UPDATE loans
                        SET returned_at = NOW()
                        WHERE loan_id = @lid AND returned_at IS NULL;
                    ";
                    cmd.Parameters.AddWithValue("@lid", loanId);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows != 1)
                    {
                        tx.Rollback();
                        MessageBox.Show("Gagal: data sudah dikembalikan / tidak ditemukan.");
                        return;
                    }
                }

                // 2) set buku tersedia
                using (var cmd = conn.CreateCommand())
                {
                    cmd.Transaction = tx;
                    cmd.CommandText = "UPDATE books SET status='tersedia' WHERE book_id=@bid;";
                    cmd.Parameters.AddWithValue("@bid", bookId);
                    cmd.ExecuteNonQuery();
                }

                tx.Commit();
                MessageBox.Show("Berhasil dikembalikan!");
                LoadActiveLoans();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal pengembalian:\n" + ex.Message);
            }
        }
        private void button_close_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}

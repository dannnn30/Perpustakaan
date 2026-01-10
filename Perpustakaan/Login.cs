using MySqlConnector;

namespace Perpustakaan
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void button_login_Click(object sender, EventArgs e)
        {
            var Username = textBox_usrname.Text.Trim();
            var pass = textBox_password.Text;

            if (Username == "" || pass == "")
            {
                MessageBox.Show("Isi username dan password.");
                return;
            }

            try
            {
                using var conn = Db.Conn();
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
            SELECT user_id, username, role
            FROM users
            WHERE username = @id
              AND password = @pw
            LIMIT 1;";
                cmd.Parameters.AddWithValue("@id", Username);
                cmd.Parameters.AddWithValue("@pw", pass);

                using var r = cmd.ExecuteReader();
                if (!r.Read())
                {
                    MessageBox.Show("Login gagal. Cek username atau password.");
                    return;
                }

                var role = r.GetString("role");
                var username = r.GetString("username");

                //MessageBox.Show($"Login berhasil: {username} ({role})");

                var f = new Catalog(role);
                f.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label_clear_Click(object sender, EventArgs e)
        {
            textBox_usrname.Clear();
            textBox_password.Clear();
            textBox_usrname.Focus();
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox_usrname_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

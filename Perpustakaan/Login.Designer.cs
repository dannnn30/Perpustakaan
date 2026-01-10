namespace Perpustakaan
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            pictureBox1 = new PictureBox();
            label_login = new Label();
            pictureBox_login = new PictureBox();
            panel1 = new Panel();
            pictureBox3 = new PictureBox();
            panel2 = new Panel();
            button_login = new Button();
            label_exit = new Label();
            textBox_usrname = new TextBox();
            textBox_password = new TextBox();
            label_clear = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_login).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(201, 53);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(382, 159);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label_login
            // 
            label_login.AutoSize = true;
            label_login.Font = new Font("Bahnschrift Condensed", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_login.ForeColor = Color.Black;
            label_login.Location = new Point(288, 215);
            label_login.Name = "label_login";
            label_login.Size = new Size(203, 96);
            label_login.TabIndex = 1;
            label_login.Text = "LOG IN";
            // 
            // pictureBox_login
            // 
            pictureBox_login.Image = (Image)resources.GetObject("pictureBox_login.Image");
            pictureBox_login.Location = new Point(107, 357);
            pictureBox_login.Name = "pictureBox_login";
            pictureBox_login.Size = new Size(89, 49);
            pictureBox_login.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_login.TabIndex = 2;
            pictureBox_login.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Location = new Point(107, 429);
            panel1.Name = "panel1";
            panel1.Size = new Size(553, 1);
            panel1.TabIndex = 3;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(107, 543);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(89, 49);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.Location = new Point(107, 615);
            panel2.Name = "panel2";
            panel2.Size = new Size(553, 1);
            panel2.TabIndex = 3;
            // 
            // button_login
            // 
            button_login.BackColor = Color.Black;
            button_login.FlatStyle = FlatStyle.Flat;
            button_login.Font = new Font("Bahnschrift Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_login.ForeColor = Color.White;
            button_login.Location = new Point(107, 766);
            button_login.Name = "button_login";
            button_login.Size = new Size(553, 69);
            button_login.TabIndex = 4;
            button_login.Text = "LOG IN";
            button_login.UseVisualStyleBackColor = false;
            button_login.Click += button_login_Click;
            // 
            // label_exit
            // 
            label_exit.AutoSize = true;
            label_exit.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_exit.Location = new Point(349, 892);
            label_exit.Name = "label_exit";
            label_exit.Size = new Size(56, 39);
            label_exit.TabIndex = 5;
            label_exit.Text = "Exit";
            label_exit.Click += label_exit_Click;
            // 
            // textBox_usrname
            // 
            textBox_usrname.BorderStyle = BorderStyle.None;
            textBox_usrname.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox_usrname.ForeColor = Color.Black;
            textBox_usrname.Location = new Point(196, 357);
            textBox_usrname.Multiline = true;
            textBox_usrname.Name = "textBox_usrname";
            textBox_usrname.Size = new Size(464, 50);
            textBox_usrname.TabIndex = 6;
            textBox_usrname.TextChanged += textBox_usrname_TextChanged;
            // 
            // textBox_password
            // 
            textBox_password.BorderStyle = BorderStyle.None;
            textBox_password.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox_password.ForeColor = Color.Black;
            textBox_password.Location = new Point(196, 543);
            textBox_password.Multiline = true;
            textBox_password.Name = "textBox_password";
            textBox_password.Size = new Size(464, 50);
            textBox_password.TabIndex = 7;
            textBox_password.TextChanged += textBox_password_TextChanged;
            // 
            // label_clear
            // 
            label_clear.AutoSize = true;
            label_clear.Font = new Font("Bahnschrift SemiBold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_clear.Location = new Point(531, 723);
            label_clear.Name = "label_clear";
            label_clear.Size = new Size(129, 29);
            label_clear.TabIndex = 8;
            label_clear.Text = "Clear Field";
            label_clear.Click += label_clear_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(808, 986);
            Controls.Add(label_clear);
            Controls.Add(textBox_password);
            Controls.Add(textBox_usrname);
            Controls.Add(label_exit);
            Controls.Add(button_login);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox_login);
            Controls.Add(label_login);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            Load += Dashboard_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_login).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // Add this method to the Dashboard class to handle the Close button click event.
        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private PictureBox pictureBox1;
        private Label label_login;
        private PictureBox pictureBox_login;
        private Panel panel1;
        private PictureBox pictureBox3;
        private Panel panel2;
        private Button button_login;
        private Label label_exit;
        private TextBox textBox_usrname;
        private TextBox textBox_password;
        private Label label_clear;
    }
}

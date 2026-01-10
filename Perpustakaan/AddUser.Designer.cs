namespace Perpustakaan
{
    partial class AddUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label_username = new Label();
            label_adduser = new Label();
            label_password = new Label();
            label_role = new Label();
            comboBox_role = new ComboBox();
            textBox_username = new TextBox();
            textBox_password = new TextBox();
            button_add = new Button();
            button_close = new Button();
            SuspendLayout();
            // 
            // label_username
            // 
            label_username.AutoSize = true;
            label_username.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_username.Location = new Point(201, 126);
            label_username.Name = "label_username";
            label_username.Size = new Size(124, 39);
            label_username.TabIndex = 0;
            label_username.Text = "Username";
            // 
            // label_adduser
            // 
            label_adduser.AutoSize = true;
            label_adduser.Font = new Font("Bahnschrift", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_adduser.Location = new Point(20, 15);
            label_adduser.Name = "label_adduser";
            label_adduser.Size = new Size(221, 52);
            label_adduser.TabIndex = 1;
            label_adduser.Text = "Add Users";
            // 
            // label_password
            // 
            label_password.AutoSize = true;
            label_password.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_password.Location = new Point(201, 198);
            label_password.Name = "label_password";
            label_password.Size = new Size(120, 39);
            label_password.TabIndex = 2;
            label_password.Text = "Password";
            // 
            // label_role
            // 
            label_role.AutoSize = true;
            label_role.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_role.Location = new Point(201, 275);
            label_role.Name = "label_role";
            label_role.Size = new Size(62, 39);
            label_role.TabIndex = 2;
            label_role.Text = "Role";
            // 
            // comboBox_role
            // 
            comboBox_role.FormattingEnabled = true;
            comboBox_role.Location = new Point(397, 278);
            comboBox_role.Name = "comboBox_role";
            comboBox_role.Size = new Size(242, 40);
            comboBox_role.TabIndex = 3;
            comboBox_role.SelectedIndexChanged += comboBox_role_SelectedIndexChanged;
            // 
            // textBox_username
            // 
            textBox_username.Location = new Point(397, 124);
            textBox_username.Name = "textBox_username";
            textBox_username.Size = new Size(242, 39);
            textBox_username.TabIndex = 4;
            textBox_username.TextChanged += textBox_username_TextChanged;
            // 
            // textBox_password
            // 
            textBox_password.Location = new Point(397, 198);
            textBox_password.Name = "textBox_password";
            textBox_password.Size = new Size(242, 39);
            textBox_password.TabIndex = 4;
            textBox_password.TextChanged += textBox_password_TextChanged;
            // 
            // button_add
            // 
            button_add.Location = new Point(489, 357);
            button_add.Name = "button_add";
            button_add.Size = new Size(150, 46);
            button_add.TabIndex = 5;
            button_add.Text = "Tambahkan";
            button_add.UseVisualStyleBackColor = true;
            button_add.Click += button_add_Click;
            // 
            // button_close
            // 
            button_close.Location = new Point(489, 409);
            button_close.Name = "button_close";
            button_close.Size = new Size(150, 46);
            button_close.TabIndex = 6;
            button_close.Text = "Close";
            button_close.UseVisualStyleBackColor = true;
            button_close.Click += button_close_Click;
            // 
            // AddUser
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 527);
            Controls.Add(button_close);
            Controls.Add(button_add);
            Controls.Add(textBox_password);
            Controls.Add(textBox_username);
            Controls.Add(comboBox_role);
            Controls.Add(label_role);
            Controls.Add(label_password);
            Controls.Add(label_adduser);
            Controls.Add(label_username);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddUser";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_username;
        private Label label_adduser;
        private Label label_password;
        private Label label_role;
        private ComboBox comboBox_role;
        private TextBox textBox_username;
        private TextBox textBox_password;
        private Button button_add;
        private Button button_close;
    }
}
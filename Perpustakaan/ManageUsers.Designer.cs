namespace Perpustakaan
{
    partial class ManageUsers
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
            dataGridView_users = new DataGridView();
            label_menageusers = new Label();
            button_tambah = new Button();
            button_hapususers = new Button();
            button_refresh = new Button();
            button_close = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView_users).BeginInit();
            SuspendLayout();
            // 
            // dataGridView_users
            // 
            dataGridView_users.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_users.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_users.Location = new Point(12, 98);
            dataGridView_users.Name = "dataGridView_users";
            dataGridView_users.ReadOnly = true;
            dataGridView_users.RowHeadersWidth = 82;
            dataGridView_users.Size = new Size(876, 365);
            dataGridView_users.TabIndex = 0;
            dataGridView_users.CellContentClick += dataGridView_users_CellContentClick;
            // 
            // label_menageusers
            // 
            label_menageusers.AutoSize = true;
            label_menageusers.Font = new Font("Bahnschrift", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_menageusers.Location = new Point(20, 15);
            label_menageusers.Name = "label_menageusers";
            label_menageusers.Size = new Size(297, 52);
            label_menageusers.TabIndex = 1;
            label_menageusers.Text = "Menage Users";
            // 
            // button_tambah
            // 
            button_tambah.Location = new Point(426, 46);
            button_tambah.Name = "button_tambah";
            button_tambah.Size = new Size(150, 46);
            button_tambah.TabIndex = 2;
            button_tambah.Text = "Tambah";
            button_tambah.UseVisualStyleBackColor = true;
            button_tambah.Click += button_tambah_Click;
            // 
            // button_hapususers
            // 
            button_hapususers.Location = new Point(582, 46);
            button_hapususers.Name = "button_hapususers";
            button_hapususers.Size = new Size(150, 46);
            button_hapususers.TabIndex = 3;
            button_hapususers.Text = "Hapus";
            button_hapususers.UseVisualStyleBackColor = true;
            button_hapususers.Click += button_hapususers_Click;
            // 
            // button_refresh
            // 
            button_refresh.Location = new Point(738, 46);
            button_refresh.Name = "button_refresh";
            button_refresh.Size = new Size(150, 46);
            button_refresh.TabIndex = 4;
            button_refresh.Text = "Refresh";
            button_refresh.UseVisualStyleBackColor = true;
            button_refresh.Click += button_refresh_Click;
            // 
            // button_close
            // 
            button_close.Location = new Point(738, 469);
            button_close.Name = "button_close";
            button_close.Size = new Size(150, 46);
            button_close.TabIndex = 5;
            button_close.Text = "Close";
            button_close.UseVisualStyleBackColor = true;
            button_close.Click += button_close_Click;
            // 
            // ManageUsers
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 522);
            Controls.Add(button_close);
            Controls.Add(button_refresh);
            Controls.Add(button_hapususers);
            Controls.Add(button_tambah);
            Controls.Add(label_menageusers);
            Controls.Add(dataGridView_users);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ManageUsers";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ManageUsers";
            ((System.ComponentModel.ISupportInitialize)dataGridView_users).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView_users;
        private Label label_menageusers;
        private Button button_tambah;
        private Button button_hapususers;
        private Button button_refresh;
        private Button button_close;
    }
}
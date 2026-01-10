namespace Perpustakaan
{
    partial class Borrow
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
            label_borrow = new Label();
            label_member = new Label();
            comboBox_member = new ComboBox();
            label_bookid = new Label();
            textBox_bookid = new TextBox();
            label_tilte = new Label();
            textBox_title = new TextBox();
            label_tglpinjam = new Label();
            dateTimePicker_tglpinjam = new DateTimePicker();
            label_7hari = new Label();
            label_auto7hari = new Label();
            button_simpan = new Button();
            button_cancle = new Button();
            SuspendLayout();
            // 
            // label_borrow
            // 
            label_borrow.AutoSize = true;
            label_borrow.Font = new Font("Bahnschrift", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_borrow.Location = new Point(20, 15);
            label_borrow.Name = "label_borrow";
            label_borrow.Size = new Size(359, 45);
            label_borrow.TabIndex = 0;
            label_borrow.Text = "FORM PEMINJAMAN";
            // 
            // label_member
            // 
            label_member.AutoSize = true;
            label_member.Location = new Point(20, 70);
            label_member.Name = "label_member";
            label_member.Size = new Size(105, 32);
            label_member.TabIndex = 1;
            label_member.Text = "Anggota";
            // 
            // comboBox_member
            // 
            comboBox_member.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_member.FormattingEnabled = true;
            comboBox_member.Location = new Point(20, 110);
            comboBox_member.Name = "comboBox_member";
            comboBox_member.Size = new Size(450, 40);
            comboBox_member.TabIndex = 2;
            // 
            // label_bookid
            // 
            label_bookid.AutoSize = true;
            label_bookid.Location = new Point(20, 150);
            label_bookid.Name = "label_bookid";
            label_bookid.Size = new Size(98, 32);
            label_bookid.TabIndex = 3;
            label_bookid.Text = "Book ID";
            // 
            // textBox_bookid
            // 
            textBox_bookid.Location = new Point(20, 180);
            textBox_bookid.Name = "textBox_bookid";
            textBox_bookid.ReadOnly = true;
            textBox_bookid.Size = new Size(120, 39);
            textBox_bookid.TabIndex = 4;
            // 
            // label_tilte
            // 
            label_tilte.AutoSize = true;
            label_tilte.Location = new Point(160, 180);
            label_tilte.Name = "label_tilte";
            label_tilte.Size = new Size(71, 32);
            label_tilte.TabIndex = 5;
            label_tilte.Text = "Judul";
            // 
            // textBox_title
            // 
            textBox_title.Location = new Point(237, 180);
            textBox_title.Name = "textBox_title";
            textBox_title.ReadOnly = true;
            textBox_title.Size = new Size(233, 39);
            textBox_title.TabIndex = 6;
            // 
            // label_tglpinjam
            // 
            label_tglpinjam.AutoSize = true;
            label_tglpinjam.Location = new Point(20, 230);
            label_tglpinjam.Name = "label_tglpinjam";
            label_tglpinjam.Size = new Size(175, 32);
            label_tglpinjam.TabIndex = 7;
            label_tglpinjam.Text = "Tanggal Pinjam";
            // 
            // dateTimePicker_tglpinjam
            // 
            dateTimePicker_tglpinjam.Format = DateTimePickerFormat.Short;
            dateTimePicker_tglpinjam.Location = new Point(20, 265);
            dateTimePicker_tglpinjam.Name = "dateTimePicker_tglpinjam";
            dateTimePicker_tglpinjam.Size = new Size(200, 39);
            dateTimePicker_tglpinjam.TabIndex = 8;
            dateTimePicker_tglpinjam.ValueChanged += dateTimePicker_tglpinjam_ValueChanged;
            // 
            // label_7hari
            // 
            label_7hari.AutoSize = true;
            label_7hari.Location = new Point(240, 230);
            label_7hari.Name = "label_7hari";
            label_7hari.Size = new Size(249, 32);
            label_7hari.TabIndex = 9;
            label_7hari.Text = "Harus Kembali (7 hari)";
            // 
            // label_auto7hari
            // 
            label_auto7hari.AutoSize = true;
            label_auto7hari.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_auto7hari.Location = new Point(240, 265);
            label_auto7hari.Name = "label_auto7hari";
            label_auto7hari.Size = new Size(28, 37);
            label_auto7hari.TabIndex = 10;
            label_auto7hari.Text = "-";
            // 
            // button_simpan
            // 
            button_simpan.Location = new Point(270, 345);
            button_simpan.Name = "button_simpan";
            button_simpan.Size = new Size(103, 40);
            button_simpan.TabIndex = 11;
            button_simpan.Text = "Simpan";
            button_simpan.UseVisualStyleBackColor = true;
            button_simpan.Click += button_simpan_Click;
            // 
            // button_cancle
            // 
            button_cancle.Location = new Point(380, 345);
            button_cancle.Name = "button_cancle";
            button_cancle.Size = new Size(103, 40);
            button_cancle.TabIndex = 12;
            button_cancle.Text = "Batal";
            button_cancle.UseVisualStyleBackColor = true;
            button_cancle.Click += button_cancle_Click;
            // 
            // Borrow
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(494, 396);
            Controls.Add(button_cancle);
            Controls.Add(button_simpan);
            Controls.Add(label_auto7hari);
            Controls.Add(label_7hari);
            Controls.Add(dateTimePicker_tglpinjam);
            Controls.Add(label_tglpinjam);
            Controls.Add(textBox_title);
            Controls.Add(label_tilte);
            Controls.Add(textBox_bookid);
            Controls.Add(label_bookid);
            Controls.Add(comboBox_member);
            Controls.Add(label_member);
            Controls.Add(label_borrow);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Borrow";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Borrow";
            Load += Borrow_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_borrow;
        private Label label_member;
        private ComboBox comboBox_member;
        private Label label_bookid;
        private TextBox textBox_bookid;
        private Label label_tilte;
        private TextBox textBox_title;
        private Label label_tglpinjam;
        private DateTimePicker dateTimePicker_tglpinjam;
        private Label label_7hari;
        private Label label_auto7hari;
        private Button button_simpan;
        private Button button_cancle;
    }
}
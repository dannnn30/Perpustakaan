namespace Perpustakaan
{
    partial class AddBook
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox_judul = new TextBox();
            textBox_penulis = new TextBox();
            button_tambahbuku = new Button();
            button_close = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(20, 15);
            label1.Name = "label1";
            label1.Size = new Size(205, 52);
            label1.TabIndex = 0;
            label1.Text = "Add Book";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(200, 125);
            label2.Name = "label2";
            label2.Size = new Size(74, 39);
            label2.TabIndex = 1;
            label2.Text = "Judul";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(200, 190);
            label3.Name = "label3";
            label3.Size = new Size(94, 39);
            label3.TabIndex = 2;
            label3.Text = "Penulis";
            // 
            // textBox_judul
            // 
            textBox_judul.Location = new Point(397, 124);
            textBox_judul.Name = "textBox_judul";
            textBox_judul.Size = new Size(317, 39);
            textBox_judul.TabIndex = 3;
            textBox_judul.TextChanged += textBox_judul_TextChanged;
            // 
            // textBox_penulis
            // 
            textBox_penulis.Location = new Point(397, 193);
            textBox_penulis.Name = "textBox_penulis";
            textBox_penulis.Size = new Size(317, 39);
            textBox_penulis.TabIndex = 4;
            textBox_penulis.TextChanged += textBox_penulis_TextChanged;
            // 
            // button_tambahbuku
            // 
            button_tambahbuku.Location = new Point(564, 264);
            button_tambahbuku.Name = "button_tambahbuku";
            button_tambahbuku.Size = new Size(150, 46);
            button_tambahbuku.TabIndex = 5;
            button_tambahbuku.Text = "Tambahkan";
            button_tambahbuku.UseVisualStyleBackColor = true;
            button_tambahbuku.Click += button_tambahbuku_Click;
            // 
            // button_close
            // 
            button_close.Location = new Point(564, 334);
            button_close.Name = "button_close";
            button_close.Size = new Size(150, 46);
            button_close.TabIndex = 6;
            button_close.Text = "Close";
            button_close.UseVisualStyleBackColor = true;
            button_close.Click += button_close_Click;
            // 
            // AddBook
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 527);
            Controls.Add(button_close);
            Controls.Add(button_tambahbuku);
            Controls.Add(textBox_penulis);
            Controls.Add(textBox_judul);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddBook";
            StartPosition = FormStartPosition.CenterParent;
            Text = "AddBook";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox_judul;
        private TextBox textBox_penulis;
        private Button button_tambahbuku;
        private Button button_close;
    }
}
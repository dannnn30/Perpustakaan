namespace Perpustakaan
{
    partial class ManageBooks
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
            label_managebooks = new Label();
            button_tambahbook = new Button();
            button_hapusbook = new Button();
            button_refresh = new Button();
            dataGridView_books = new DataGridView();
            mySqlCommandBuilder1 = new MySqlConnector.MySqlCommandBuilder();
            button_close = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView_books).BeginInit();
            SuspendLayout();
            // 
            // label_managebooks
            // 
            label_managebooks.AutoSize = true;
            label_managebooks.Font = new Font("Bahnschrift", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_managebooks.Location = new Point(20, 15);
            label_managebooks.Name = "label_managebooks";
            label_managebooks.Size = new Size(303, 52);
            label_managebooks.TabIndex = 0;
            label_managebooks.Text = "Manage Books";
            // 
            // button_tambahbook
            // 
            button_tambahbook.Location = new Point(426, 46);
            button_tambahbook.Name = "button_tambahbook";
            button_tambahbook.Size = new Size(150, 46);
            button_tambahbook.TabIndex = 1;
            button_tambahbook.Text = "Tambah";
            button_tambahbook.UseVisualStyleBackColor = true;
            button_tambahbook.Click += button_tambahbook_Click;
            // 
            // button_hapusbook
            // 
            button_hapusbook.Location = new Point(582, 46);
            button_hapusbook.Name = "button_hapusbook";
            button_hapusbook.Size = new Size(150, 46);
            button_hapusbook.TabIndex = 2;
            button_hapusbook.Text = "Hapus";
            button_hapusbook.UseVisualStyleBackColor = true;
            button_hapusbook.Click += button_hapusbook_Click;
            // 
            // button_refresh
            // 
            button_refresh.Location = new Point(738, 46);
            button_refresh.Name = "button_refresh";
            button_refresh.Size = new Size(150, 46);
            button_refresh.TabIndex = 3;
            button_refresh.Text = "Refresh";
            button_refresh.UseVisualStyleBackColor = true;
            button_refresh.Click += button_refresh_Click;
            // 
            // dataGridView_books
            // 
            dataGridView_books.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_books.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_books.Location = new Point(12, 98);
            dataGridView_books.Name = "dataGridView_books";
            dataGridView_books.ReadOnly = true;
            dataGridView_books.RowHeadersWidth = 82;
            dataGridView_books.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_books.Size = new Size(876, 365);
            dataGridView_books.TabIndex = 4;
            dataGridView_books.CellContentClick += dataGridView_books_CellContentClick;
            // 
            // mySqlCommandBuilder1
            // 
            mySqlCommandBuilder1.DataAdapter = null;
            mySqlCommandBuilder1.QuotePrefix = "`";
            mySqlCommandBuilder1.QuoteSuffix = "`";
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
            // MenageBooks
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 522);
            Controls.Add(button_close);
            Controls.Add(dataGridView_books);
            Controls.Add(button_refresh);
            Controls.Add(button_hapusbook);
            Controls.Add(button_tambahbook);
            Controls.Add(label_managebooks);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MenageBooks";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView_books).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_managebooks;
        private Button button_tambahbook;
        private Button button_hapusbook;
        private Button button_refresh;
        private DataGridView dataGridView_books;
        private MySqlConnector.MySqlCommandBuilder mySqlCommandBuilder1;
        private Button button_close;
    }
}
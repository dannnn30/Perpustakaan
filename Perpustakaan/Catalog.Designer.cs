namespace Perpustakaan
{
    partial class Catalog
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
            label_katalog = new Label();
            textBox_search = new TextBox();
            button_search = new Button();
            button_refresh = new Button();
            button_borrow = new Button();
            dataGridView_books = new DataGridView();
            button_closecat = new Button();
            button_menageuser = new Button();
            button_menagebooks = new Button();
            button_return = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView_books).BeginInit();
            SuspendLayout();
            // 
            // label_katalog
            // 
            label_katalog.AutoSize = true;
            label_katalog.Font = new Font("Bahnschrift", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_katalog.Location = new Point(20, 15);
            label_katalog.Name = "label_katalog";
            label_katalog.Size = new Size(326, 52);
            label_katalog.TabIndex = 0;
            label_katalog.Text = "KATALOG BUKU";
            // 
            // textBox_search
            // 
            textBox_search.Location = new Point(20, 60);
            textBox_search.Name = "textBox_search";
            textBox_search.PlaceholderText = "Cari judul / author...";
            textBox_search.Size = new Size(327, 39);
            textBox_search.TabIndex = 1;
            // 
            // button_search
            // 
            button_search.Location = new Point(353, 60);
            button_search.Name = "button_search";
            button_search.Size = new Size(105, 39);
            button_search.TabIndex = 2;
            button_search.Text = "Search";
            button_search.UseVisualStyleBackColor = true;
            button_search.Click += button_search_Click;
            // 
            // button_refresh
            // 
            button_refresh.Location = new Point(464, 60);
            button_refresh.Name = "button_refresh";
            button_refresh.Size = new Size(105, 39);
            button_refresh.TabIndex = 3;
            button_refresh.Text = "Refresh";
            button_refresh.UseVisualStyleBackColor = true;
            button_refresh.Click += button_refresh_Click;
            // 
            // button_borrow
            // 
            button_borrow.Location = new Point(575, 60);
            button_borrow.Name = "button_borrow";
            button_borrow.Size = new Size(105, 39);
            button_borrow.TabIndex = 4;
            button_borrow.Text = "Pinjam";
            button_borrow.UseVisualStyleBackColor = true;
            button_borrow.Click += button_borrow_Click;
            // 
            // dataGridView_books
            // 
            dataGridView_books.AllowUserToAddRows = false;
            dataGridView_books.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_books.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_books.Location = new Point(20, 110);
            dataGridView_books.MultiSelect = false;
            dataGridView_books.Name = "dataGridView_books";
            dataGridView_books.ReadOnly = true;
            dataGridView_books.RowHeadersWidth = 82;
            dataGridView_books.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_books.Size = new Size(840, 360);
            dataGridView_books.TabIndex = 5;
            // 
            // button_closecat
            // 
            button_closecat.Location = new Point(741, 478);
            button_closecat.Name = "button_closecat";
            button_closecat.Size = new Size(108, 39);
            button_closecat.TabIndex = 6;
            button_closecat.Text = "Log Out";
            button_closecat.UseVisualStyleBackColor = true;
            button_closecat.Click += button_closecat_Click;
            // 
            // button_menageuser
            // 
            button_menageuser.Location = new Point(20, 478);
            button_menageuser.Name = "button_menageuser";
            button_menageuser.Size = new Size(175, 39);
            button_menageuser.TabIndex = 7;
            button_menageuser.Text = "Menage Users";
            button_menageuser.UseVisualStyleBackColor = true;
            button_menageuser.Click += button_menageuser_Click;
            // 
            // button_menagebooks
            // 
            button_menagebooks.Location = new Point(201, 478);
            button_menagebooks.Name = "button_menagebooks";
            button_menagebooks.Size = new Size(181, 39);
            button_menagebooks.TabIndex = 8;
            button_menagebooks.Text = "Menage Books";
            button_menagebooks.UseVisualStyleBackColor = true;
            button_menagebooks.Click += button_menagebooks_Click;
            // 
            // button_return
            // 
            button_return.Location = new Point(686, 60);
            button_return.Name = "button_return";
            button_return.Size = new Size(174, 39);
            button_return.TabIndex = 9;
            button_return.Text = "Pengembalian";
            button_return.UseVisualStyleBackColor = true;
            button_return.Click += button_return_Click;
            // 
            // Catalog
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 527);
            Controls.Add(button_return);
            Controls.Add(button_menagebooks);
            Controls.Add(button_menageuser);
            Controls.Add(button_closecat);
            Controls.Add(dataGridView_books);
            Controls.Add(button_borrow);
            Controls.Add(button_refresh);
            Controls.Add(button_search);
            Controls.Add(textBox_search);
            Controls.Add(label_katalog);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "Catalog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView_books).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_katalog;
        private TextBox textBox_search;
        private Button button_search;
        private Button button_refresh;
        private Button button_borrow;
        private DataGridView dataGridView_books;
        private Button button_closecat;
        private Button button_menageuser;
        private Button button_menagebooks;
        private Button button_return;
    }
}
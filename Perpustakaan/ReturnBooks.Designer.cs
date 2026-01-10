namespace Perpustakaan
{
    partial class ReturnBooks
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
            retur = new Label();
            dataGridView_loans = new DataGridView();
            button_kembalikan = new Button();
            button_refresh = new Button();
            button_close = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView_loans).BeginInit();
            SuspendLayout();
            // 
            // retur
            // 
            retur.AutoSize = true;
            retur.Font = new Font("Bahnschrift", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            retur.Location = new Point(20, 15);
            retur.Name = "retur";
            retur.Size = new Size(261, 52);
            retur.TabIndex = 0;
            retur.Text = "Return Book";
            // 
            // dataGridView_loans
            // 
            dataGridView_loans.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_loans.Location = new Point(12, 98);
            dataGridView_loans.Name = "dataGridView_loans";
            dataGridView_loans.RowHeadersWidth = 82;
            dataGridView_loans.Size = new Size(876, 365);
            dataGridView_loans.TabIndex = 1;
            // 
            // button_kembalikan
            // 
            button_kembalikan.Location = new Point(582, 46);
            button_kembalikan.Name = "button_kembalikan";
            button_kembalikan.Size = new Size(150, 46);
            button_kembalikan.TabIndex = 2;
            button_kembalikan.Text = "Kembalikan";
            button_kembalikan.UseVisualStyleBackColor = true;
            button_kembalikan.Click += button_kembalikan_Click;
            // 
            // button_refresh
            // 
            button_refresh.Location = new Point(738, 46);
            button_refresh.Name = "button_refresh";
            button_refresh.Size = new Size(150, 46);
            button_refresh.TabIndex = 3;
            button_refresh.Text = "Refresh";
            button_refresh.UseVisualStyleBackColor = true;
            // 
            // button_close
            // 
            button_close.Location = new Point(738, 469);
            button_close.Name = "button_close";
            button_close.Size = new Size(150, 46);
            button_close.TabIndex = 4;
            button_close.Text = "Close";
            button_close.UseVisualStyleBackColor = true;
            button_close.Click += button_close_Click_1;
            // 
            // ReturnBooks
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 527);
            Controls.Add(button_close);
            Controls.Add(button_refresh);
            Controls.Add(button_kembalikan);
            Controls.Add(dataGridView_loans);
            Controls.Add(retur);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ReturnBooks";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ReturnBooks";
            Load += ReturnBooks_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_loans).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label retur;
        private DataGridView dataGridView_loans;
        private Button button_kembalikan;
        private Button button_refresh;
        private Button button_close;
    }
}
namespace inventryManagementSystem.Views
{
    partial class ExpiredDate
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewExpiredDate = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpiredDate)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewExpiredDate
            // 
            this.dataGridViewExpiredDate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewExpiredDate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExpiredDate.Location = new System.Drawing.Point(112, 116);
            this.dataGridViewExpiredDate.Name = "dataGridViewExpiredDate";
            this.dataGridViewExpiredDate.ReadOnly = true;
            this.dataGridViewExpiredDate.RowHeadersWidth = 51;
            this.dataGridViewExpiredDate.RowTemplate.Height = 24;
            this.dataGridViewExpiredDate.Size = new System.Drawing.Size(1569, 576);
            this.dataGridViewExpiredDate.TabIndex = 0;
            // 
            // ExpiredDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewExpiredDate);
            this.Name = "ExpiredDate";
            this.Size = new System.Drawing.Size(1735, 829);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpiredDate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewExpiredDate;
    }
}

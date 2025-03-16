namespace inventryManagementSystem.Views
{
    partial class ShowLowStock
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
            this.dataGridViewLowStock = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLowStock)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewLowStock
            // 
            this.dataGridViewLowStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLowStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLowStock.Location = new System.Drawing.Point(112, 116);
            this.dataGridViewLowStock.Name = "dataGridViewLowStock";
            this.dataGridViewLowStock.ReadOnly = true;
            this.dataGridViewLowStock.RowHeadersWidth = 51;
            this.dataGridViewLowStock.RowTemplate.Height = 24;
            this.dataGridViewLowStock.Size = new System.Drawing.Size(1569, 576);
            this.dataGridViewLowStock.TabIndex = 0;
            // 
            // ShowLowStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.dataGridViewLowStock);
            this.Name = "ShowLowStock";
            this.Size = new System.Drawing.Size(1673, 768);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLowStock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewLowStock;
    }
}

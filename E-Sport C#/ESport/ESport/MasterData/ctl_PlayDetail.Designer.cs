namespace ESport.MasterData
{
    partial class ctl_PlayDetail
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
            this.dgvPlayDetail = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPlayDetail
            // 
            this.dgvPlayDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlayDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPlayDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvPlayDetail.Name = "dgvPlayDetail";
            this.dgvPlayDetail.RowTemplate.Height = 40;
            this.dgvPlayDetail.Size = new System.Drawing.Size(1448, 802);
            this.dgvPlayDetail.TabIndex = 0;
            // 
            // ctl_PlayDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvPlayDetail);
            this.Name = "ctl_PlayDetail";
            this.Size = new System.Drawing.Size(1448, 802);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvPlayDetail;

    }
}

namespace ESport.MasterData
{
    partial class frm_FoodAndDrinkList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_FoodAndDrinkList));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tslFoodName = new System.Windows.Forms.ToolStripSplitButton();
            this.tsmFoodName = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPrice = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmQty = new System.Windows.Forms.ToolStripMenuItem();
            this.tstSearchWith = new System.Windows.Forms.ToolStripTextBox();
            this.dgvFoodAndDrink = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFoodAndDrink)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNew,
            this.toolStripSeparator1,
            this.tsbEdit,
            this.toolStripSeparator2,
            this.tsbDelete,
            this.toolStripSeparator3,
            this.tslFoodName,
            this.tstSearchWith});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1591, 48);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbNew
            // 
            this.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbNew.Image")));
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(82, 45);
            this.tsbNew.Text = "New";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 48);
            // 
            // tsbEdit
            // 
            this.tsbEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbEdit.Image")));
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Size = new System.Drawing.Size(72, 45);
            this.tsbEdit.Text = "Edit";
            this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 48);
            // 
            // tsbDelete
            // 
            this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(108, 45);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 48);
            // 
            // tslFoodName
            // 
            this.tslFoodName.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tslFoodName.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFoodName,
            this.tsmPrice,
            this.tsmQty});
            this.tslFoodName.Image = ((System.Drawing.Image)(resources.GetObject("tslFoodName.Image")));
            this.tslFoodName.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tslFoodName.Name = "tslFoodName";
            this.tslFoodName.Size = new System.Drawing.Size(182, 45);
            this.tslFoodName.Text = "FoodName";
            this.tslFoodName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tsmFoodName
            // 
            this.tsmFoodName.Name = "tsmFoodName";
            this.tsmFoodName.Size = new System.Drawing.Size(244, 46);
            this.tsmFoodName.Text = "FoodName";
            this.tsmFoodName.Click += new System.EventHandler(this.tsmFoodName_Click);
            // 
            // tsmPrice
            // 
            this.tsmPrice.Name = "tsmPrice";
            this.tsmPrice.Size = new System.Drawing.Size(244, 46);
            this.tsmPrice.Text = "Price";
            this.tsmPrice.Click += new System.EventHandler(this.tsmPrice_Click);
            // 
            // tsmQty
            // 
            this.tsmQty.Name = "tsmQty";
            this.tsmQty.Size = new System.Drawing.Size(244, 46);
            this.tsmQty.Text = "Qty";
            this.tsmQty.Click += new System.EventHandler(this.tsmQty_Click);
            // 
            // tstSearchWith
            // 
            this.tstSearchWith.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tstSearchWith.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tstSearchWith.Name = "tstSearchWith";
            this.tstSearchWith.Size = new System.Drawing.Size(200, 48);
            this.tstSearchWith.TextChanged += new System.EventHandler(this.tstSearchWith_TextChanged);
            // 
            // dgvFoodAndDrink
            // 
            this.dgvFoodAndDrink.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFoodAndDrink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFoodAndDrink.Location = new System.Drawing.Point(0, 48);
            this.dgvFoodAndDrink.Name = "dgvFoodAndDrink";
            this.dgvFoodAndDrink.RowTemplate.Height = 40;
            this.dgvFoodAndDrink.Size = new System.Drawing.Size(1591, 787);
            this.dgvFoodAndDrink.TabIndex = 1;
            this.dgvFoodAndDrink.DoubleClick += new System.EventHandler(this.dgvFoodAndDrink_DoubleClick);
            // 
            // frm_FoodAndDrinkList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1591, 835);
            this.Controls.Add(this.dgvFoodAndDrink);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_FoodAndDrinkList";
            this.Text = "Food And Drink List";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_FoodAndDrinkList_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFoodAndDrink)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripSplitButton tslFoodName;
        private System.Windows.Forms.ToolStripTextBox tstSearchWith;
        private System.Windows.Forms.ToolStripMenuItem tsmFoodName;
        private System.Windows.Forms.ToolStripMenuItem tsmPrice;
        private System.Windows.Forms.ToolStripMenuItem tsmQty;
        private System.Windows.Forms.DataGridView dgvFoodAndDrink;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}
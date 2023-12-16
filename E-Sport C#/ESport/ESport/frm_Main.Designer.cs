namespace ESport
{
    partial class frm_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogIn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRegistration = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGameSet = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGame = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFoodAndDrink = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUserSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 15.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEntry,
            this.mnuProcess});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1805, 79);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLogIn,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(122, 75);
            this.mnuFile.Text = "File";
            // 
            // mnuLogIn
            // 
            this.mnuLogIn.Name = "mnuLogIn";
            this.mnuLogIn.Size = new System.Drawing.Size(251, 76);
            this.mnuLogIn.Text = "LogIn";
            this.mnuLogIn.Click += new System.EventHandler(this.mnuLogIn_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(251, 76);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuEntry
            // 
            this.mnuEntry.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRegistration,
            this.mnuGameSet,
            this.mnuGame,
            this.mnuFoodAndDrink,
            this.mnuUserSetting});
            this.mnuEntry.Name = "mnuEntry";
            this.mnuEntry.Size = new System.Drawing.Size(161, 75);
            this.mnuEntry.Text = "Entry";
            // 
            // mnuRegistration
            // 
            this.mnuRegistration.Name = "mnuRegistration";
            this.mnuRegistration.Size = new System.Drawing.Size(458, 76);
            this.mnuRegistration.Text = "Registration";
            this.mnuRegistration.Click += new System.EventHandler(this.mnuRegistration_Click);
            // 
            // mnuGameSet
            // 
            this.mnuGameSet.Name = "mnuGameSet";
            this.mnuGameSet.Size = new System.Drawing.Size(458, 76);
            this.mnuGameSet.Text = "GameSet";
            this.mnuGameSet.Click += new System.EventHandler(this.mnuGameSet_Click);
            // 
            // mnuGame
            // 
            this.mnuGame.Name = "mnuGame";
            this.mnuGame.Size = new System.Drawing.Size(458, 76);
            this.mnuGame.Text = "Game";
            this.mnuGame.Click += new System.EventHandler(this.mnuGame_Click);
            // 
            // mnuFoodAndDrink
            // 
            this.mnuFoodAndDrink.Name = "mnuFoodAndDrink";
            this.mnuFoodAndDrink.Size = new System.Drawing.Size(458, 76);
            this.mnuFoodAndDrink.Text = "FoodAndDrink";
            this.mnuFoodAndDrink.Click += new System.EventHandler(this.mnuFoodAndDrink_Click);
            // 
            // mnuUserSetting
            // 
            this.mnuUserSetting.Name = "mnuUserSetting";
            this.mnuUserSetting.Size = new System.Drawing.Size(458, 76);
            this.mnuUserSetting.Text = "UserSetting";
            this.mnuUserSetting.Click += new System.EventHandler(this.mnuUserSetting_Click);
            // 
            // mnuProcess
            // 
            this.mnuProcess.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPlay});
            this.mnuProcess.Name = "mnuProcess";
            this.mnuProcess.Size = new System.Drawing.Size(217, 75);
            this.mnuProcess.Text = "Process";
            // 
            // mnuPlay
            // 
            this.mnuPlay.Name = "mnuPlay";
            this.mnuPlay.Size = new System.Drawing.Size(216, 76);
            this.mnuPlay.Text = "Play";
            this.mnuPlay.Click += new System.EventHandler(this.mnuPlay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1051, 318);
            this.label1.TabIndex = 4;
            this.label1.Text = "E-Sport ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(409, 523);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(939, 318);
            this.label2.TabIndex = 5;
            this.label2.Text = "System";
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ESport.Properties.Resources.Spiderman_Laptop_Wallpaper_4k;
            this.ClientSize = new System.Drawing.Size(1805, 1061);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frm_Main";
            this.Text = "ESport System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuLogIn;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuEntry;
        private System.Windows.Forms.ToolStripMenuItem mnuRegistration;
        private System.Windows.Forms.ToolStripMenuItem mnuGameSet;
        private System.Windows.Forms.ToolStripMenuItem mnuGame;
        private System.Windows.Forms.ToolStripMenuItem mnuFoodAndDrink;
        private System.Windows.Forms.ToolStripMenuItem mnuUserSetting;
        private System.Windows.Forms.ToolStripMenuItem mnuProcess;
        private System.Windows.Forms.ToolStripMenuItem mnuPlay;
        public System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;


    }
}
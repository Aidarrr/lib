
namespace Sokoban
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.chooseLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.начатьСначалаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.историяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ходНазадToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblLevelNum = new System.Windows.Forms.Label();
            this.lblMovesCount = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(925, 543);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseLevel,
            this.историяToolStripMenuItem,
            this.начатьСначалаToolStripMenuItem,
            this.ходНазадToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(925, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip";
            // 
            // chooseLevel
            // 
            this.chooseLevel.Name = "chooseLevel";
            this.chooseLevel.Size = new System.Drawing.Size(114, 20);
            this.chooseLevel.Text = "Выбрать уровень";
            this.chooseLevel.Click += new System.EventHandler(this.chooseLevel_Click);
            // 
            // начатьСначалаToolStripMenuItem
            // 
            this.начатьСначалаToolStripMenuItem.Name = "начатьСначалаToolStripMenuItem";
            this.начатьСначалаToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.начатьСначалаToolStripMenuItem.Text = "Начать сначала";
            // 
            // историяToolStripMenuItem
            // 
            this.историяToolStripMenuItem.Name = "историяToolStripMenuItem";
            this.историяToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.историяToolStripMenuItem.Text = "История";
            // 
            // ходНазадToolStripMenuItem
            // 
            this.ходНазадToolStripMenuItem.Name = "ходНазадToolStripMenuItem";
            this.ходНазадToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.ходНазадToolStripMenuItem.Text = "Ход назад";
            // 
            // lblLevelNum
            // 
            this.lblLevelNum.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLevelNum.Location = new System.Drawing.Point(12, 476);
            this.lblLevelNum.Name = "lblLevelNum";
            this.lblLevelNum.Size = new System.Drawing.Size(106, 25);
            this.lblLevelNum.TabIndex = 2;
            this.lblLevelNum.Text = "Уровень №";
            // 
            // lblMovesCount
            // 
            this.lblMovesCount.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMovesCount.Location = new System.Drawing.Point(12, 514);
            this.lblMovesCount.Name = "lblMovesCount";
            this.lblMovesCount.Size = new System.Drawing.Size(106, 25);
            this.lblMovesCount.TabIndex = 3;
            this.lblMovesCount.Text = "Ходов: ";
            // 
            // lblTime
            // 
            this.lblTime.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTime.Location = new System.Drawing.Point(124, 514);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(106, 25);
            this.lblTime.TabIndex = 4;
            this.lblTime.Text = "Время: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 567);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblMovesCount);
            this.Controls.Add(this.lblLevelNum);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.Text = "Sokoban";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem chooseLevel;
        private System.Windows.Forms.ToolStripMenuItem историяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem начатьСначалаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ходНазадToolStripMenuItem;
        private System.Windows.Forms.Label lblLevelNum;
        private System.Windows.Forms.Label lblMovesCount;
        private System.Windows.Forms.Label lblTime;
    }
}


namespace ConjTable.Demo
{
    partial class MainForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.conjTable1 = new System.Windows.Forms.AdjTable();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.conjPanel1 = new System.Windows.Forms.AdjPanel();
            this.показатьГрафикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.conjTable1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.conjTable1);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.conjPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(998, 528);
            this.splitContainer1.SplitterDistance = 286;
            this.splitContainer1.TabIndex = 3;
            // 
            // conjTable1
            // 
            this.conjTable1.AllowUserToAddRows = false;
            this.conjTable1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.conjTable1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.conjTable1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.conjTable1.ColumnHeadersVisible = false;
            this.conjTable1.Dock = System.Windows.Forms.DockStyle.Top;
            this.conjTable1.Location = new System.Drawing.Point(0, 24);
            this.conjTable1.Name = "conjTable1";
            this.conjTable1.RowHeadersVisible = false;
            this.conjTable1.Size = new System.Drawing.Size(286, 273);
            this.conjTable1.TabIndex = 1;
            this.conjTable1.VirtualMode = true;
            this.conjTable1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.conjTable1_CellValueChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveBtn,
            this.показатьГрафикиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(286, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveBtn
            // 
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(114, 20);
            this.saveBtn.Text = "Сохранить схему";
            this.saveBtn.Click += new System.EventHandler(this.сохранитьСхемуToolStripMenuItem_Click);
            // 
            // conjPanel1
            // 
            this.conjPanel1.AutoScroll = true;
            this.conjPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.conjPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conjPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.conjPanel1.Location = new System.Drawing.Point(0, 0);
            this.conjPanel1.Name = "conjPanel1";
            this.conjPanel1.Size = new System.Drawing.Size(708, 528);
            this.conjPanel1.TabIndex = 0;
            // 
            // показатьГрафикиToolStripMenuItem
            // 
            this.показатьГрафикиToolStripMenuItem.Name = "показатьГрафикиToolStripMenuItem";
            this.показатьГрафикиToolStripMenuItem.Size = new System.Drawing.Size(119, 20);
            this.показатьГрафикиToolStripMenuItem.Text = "Показать графики";
            this.показатьГрафикиToolStripMenuItem.Click += new System.EventHandler(this.показатьГрафикиToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 528);
            this.Controls.Add(this.splitContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.conjTable1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.AdjPanel conjPanel1;
        private System.Windows.Forms.AdjTable conjTable1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveBtn;
        private System.Windows.Forms.ToolStripMenuItem показатьГрафикиToolStripMenuItem;
    }
}


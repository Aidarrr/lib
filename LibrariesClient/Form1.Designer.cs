
namespace LibrariesClient
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
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuTables = new System.Windows.Forms.ToolStripMenuItem();
            this.booksMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.libsMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.readersMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.subsMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.topicsMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.addressesMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.publishersMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.dataTable = new System.Windows.Forms.DataGridView();
            this.addRowBtn = new System.Windows.Forms.Button();
            this.deleteRowBtn = new System.Windows.Forms.Button();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTables});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1051, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            this.menu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menu_ItemClicked);
            // 
            // menuTables
            // 
            this.menuTables.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.booksMenuStrip,
            this.libsMenuStrip,
            this.readersMenuStrip,
            this.subsMenuStrip,
            this.topicsMenuStrip,
            this.addressesMenuStrip,
            this.publishersMenuStrip});
            this.menuTables.Name = "menuTables";
            this.menuTables.Size = new System.Drawing.Size(68, 20);
            this.menuTables.Text = "Таблицы";
            this.menuTables.Click += new System.EventHandler(this.издателиToolStripMenuItem_Click);
            // 
            // booksMenuStrip
            // 
            this.booksMenuStrip.Name = "booksMenuStrip";
            this.booksMenuStrip.Size = new System.Drawing.Size(167, 22);
            this.booksMenuStrip.Text = "Книги";
            this.booksMenuStrip.Click += new System.EventHandler(this.menuTables_Click);
            // 
            // libsMenuStrip
            // 
            this.libsMenuStrip.Name = "libsMenuStrip";
            this.libsMenuStrip.Size = new System.Drawing.Size(167, 22);
            this.libsMenuStrip.Text = "Библиотеки";
            this.libsMenuStrip.Click += new System.EventHandler(this.menuTables_Click);
            // 
            // readersMenuStrip
            // 
            this.readersMenuStrip.Name = "readersMenuStrip";
            this.readersMenuStrip.Size = new System.Drawing.Size(167, 22);
            this.readersMenuStrip.Text = "Читатели";
            this.readersMenuStrip.Click += new System.EventHandler(this.menuTables_Click);
            // 
            // subsMenuStrip
            // 
            this.subsMenuStrip.Name = "subsMenuStrip";
            this.subsMenuStrip.Size = new System.Drawing.Size(167, 22);
            this.subsMenuStrip.Text = "Абонементы";
            this.subsMenuStrip.Click += new System.EventHandler(this.menuTables_Click);
            // 
            // topicsMenuStrip
            // 
            this.topicsMenuStrip.Name = "topicsMenuStrip";
            this.topicsMenuStrip.Size = new System.Drawing.Size(167, 22);
            this.topicsMenuStrip.Text = "Жанры книг";
            this.topicsMenuStrip.Click += new System.EventHandler(this.menuTables_Click);
            // 
            // addressesMenuStrip
            // 
            this.addressesMenuStrip.Name = "addressesMenuStrip";
            this.addressesMenuStrip.Size = new System.Drawing.Size(167, 22);
            this.addressesMenuStrip.Text = "Таблица адресов";
            this.addressesMenuStrip.Click += new System.EventHandler(this.menuTables_Click);
            // 
            // publishersMenuStrip
            // 
            this.publishersMenuStrip.Name = "publishersMenuStrip";
            this.publishersMenuStrip.Size = new System.Drawing.Size(167, 22);
            this.publishersMenuStrip.Text = "Издательства";
            this.publishersMenuStrip.Click += new System.EventHandler(this.menuTables_Click);
            // 
            // dataTable
            // 
            this.dataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTable.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataTable.Location = new System.Drawing.Point(0, 24);
            this.dataTable.Name = "dataTable";
            this.dataTable.Size = new System.Drawing.Size(819, 569);
            this.dataTable.TabIndex = 1;
            // 
            // addRowBtn
            // 
            this.addRowBtn.Location = new System.Drawing.Point(878, 140);
            this.addRowBtn.Name = "addRowBtn";
            this.addRowBtn.Size = new System.Drawing.Size(126, 33);
            this.addRowBtn.TabIndex = 2;
            this.addRowBtn.Text = "Добавить строку";
            this.addRowBtn.UseVisualStyleBackColor = true;
            this.addRowBtn.Click += new System.EventHandler(this.addRowBtn_Click);
            // 
            // deleteRowBtn
            // 
            this.deleteRowBtn.Location = new System.Drawing.Point(878, 190);
            this.deleteRowBtn.Name = "deleteRowBtn";
            this.deleteRowBtn.Size = new System.Drawing.Size(126, 34);
            this.deleteRowBtn.TabIndex = 3;
            this.deleteRowBtn.Text = "Удалить строку";
            this.deleteRowBtn.UseVisualStyleBackColor = true;
            this.deleteRowBtn.Click += new System.EventHandler(this.deleteRowBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 593);
            this.Controls.Add(this.deleteRowBtn);
            this.Controls.Add(this.addRowBtn);
            this.Controls.Add(this.dataTable);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuTables;
        private System.Windows.Forms.ToolStripMenuItem booksMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem libsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem readersMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem subsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem topicsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addressesMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem publishersMenuStrip;
        private System.Windows.Forms.DataGridView dataTable;
        private System.Windows.Forms.Button addRowBtn;
        private System.Windows.Forms.Button deleteRowBtn;
    }
}



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
            this.filterBtn = new System.Windows.Forms.Button();
            this.colNameInput = new System.Windows.Forms.TextBox();
            this.colNameLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.conValueInput = new System.Windows.Forms.TextBox();
            this.greaterOrEqual = new System.Windows.Forms.RadioButton();
            this.operatorsForComparing = new System.Windows.Forms.GroupBox();
            this.equal = new System.Windows.Forms.RadioButton();
            this.less = new System.Windows.Forms.RadioButton();
            this.lessOrEqual = new System.Windows.Forms.RadioButton();
            this.greater = new System.Windows.Forms.RadioButton();
            this.cancelFilterBtn = new System.Windows.Forms.Button();
            this.sortBtn = new System.Windows.Forms.Button();
            this.cancelSortBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.colNameForSort = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.secondSortType = new System.Windows.Forms.RadioButton();
            this.firstSortType = new System.Windows.Forms.RadioButton();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).BeginInit();
            this.operatorsForComparing.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTables});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1401, 28);
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
            this.menuTables.Size = new System.Drawing.Size(85, 24);
            this.menuTables.Text = "Таблицы";
            this.menuTables.Click += new System.EventHandler(this.издателиToolStripMenuItem_Click);
            // 
            // booksMenuStrip
            // 
            this.booksMenuStrip.Name = "booksMenuStrip";
            this.booksMenuStrip.Size = new System.Drawing.Size(212, 26);
            this.booksMenuStrip.Text = "Книги";
            this.booksMenuStrip.Click += new System.EventHandler(this.menuTables_Click);
            // 
            // libsMenuStrip
            // 
            this.libsMenuStrip.Name = "libsMenuStrip";
            this.libsMenuStrip.Size = new System.Drawing.Size(212, 26);
            this.libsMenuStrip.Text = "Библиотеки";
            this.libsMenuStrip.Click += new System.EventHandler(this.menuTables_Click);
            // 
            // readersMenuStrip
            // 
            this.readersMenuStrip.Name = "readersMenuStrip";
            this.readersMenuStrip.Size = new System.Drawing.Size(212, 26);
            this.readersMenuStrip.Text = "Читатели";
            this.readersMenuStrip.Click += new System.EventHandler(this.menuTables_Click);
            // 
            // subsMenuStrip
            // 
            this.subsMenuStrip.Name = "subsMenuStrip";
            this.subsMenuStrip.Size = new System.Drawing.Size(212, 26);
            this.subsMenuStrip.Text = "Абонементы";
            this.subsMenuStrip.Click += new System.EventHandler(this.menuTables_Click);
            // 
            // topicsMenuStrip
            // 
            this.topicsMenuStrip.Name = "topicsMenuStrip";
            this.topicsMenuStrip.Size = new System.Drawing.Size(212, 26);
            this.topicsMenuStrip.Text = "Жанры книг";
            this.topicsMenuStrip.Click += new System.EventHandler(this.menuTables_Click);
            // 
            // addressesMenuStrip
            // 
            this.addressesMenuStrip.Name = "addressesMenuStrip";
            this.addressesMenuStrip.Size = new System.Drawing.Size(212, 26);
            this.addressesMenuStrip.Text = "Таблица адресов";
            this.addressesMenuStrip.Click += new System.EventHandler(this.menuTables_Click);
            // 
            // publishersMenuStrip
            // 
            this.publishersMenuStrip.Name = "publishersMenuStrip";
            this.publishersMenuStrip.Size = new System.Drawing.Size(212, 26);
            this.publishersMenuStrip.Text = "Издательства";
            this.publishersMenuStrip.Click += new System.EventHandler(this.menuTables_Click);
            // 
            // dataTable
            // 
            this.dataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTable.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataTable.Location = new System.Drawing.Point(0, 28);
            this.dataTable.Margin = new System.Windows.Forms.Padding(4);
            this.dataTable.Name = "dataTable";
            this.dataTable.RowHeadersWidth = 51;
            this.dataTable.Size = new System.Drawing.Size(1092, 702);
            this.dataTable.TabIndex = 1;
            // 
            // addRowBtn
            // 
            this.addRowBtn.Location = new System.Drawing.Point(1171, 539);
            this.addRowBtn.Margin = new System.Windows.Forms.Padding(4);
            this.addRowBtn.Name = "addRowBtn";
            this.addRowBtn.Size = new System.Drawing.Size(168, 41);
            this.addRowBtn.TabIndex = 2;
            this.addRowBtn.Text = "Добавить строку";
            this.addRowBtn.UseVisualStyleBackColor = true;
            this.addRowBtn.Click += new System.EventHandler(this.addRowBtn_Click);
            // 
            // deleteRowBtn
            // 
            this.deleteRowBtn.Location = new System.Drawing.Point(1171, 588);
            this.deleteRowBtn.Margin = new System.Windows.Forms.Padding(4);
            this.deleteRowBtn.Name = "deleteRowBtn";
            this.deleteRowBtn.Size = new System.Drawing.Size(168, 42);
            this.deleteRowBtn.TabIndex = 3;
            this.deleteRowBtn.Text = "Удалить строку";
            this.deleteRowBtn.UseVisualStyleBackColor = true;
            this.deleteRowBtn.Click += new System.EventHandler(this.deleteRowBtn_Click);
            // 
            // filterBtn
            // 
            this.filterBtn.Location = new System.Drawing.Point(1139, 68);
            this.filterBtn.Name = "filterBtn";
            this.filterBtn.Size = new System.Drawing.Size(109, 50);
            this.filterBtn.TabIndex = 5;
            this.filterBtn.Text = "Применить фильтр";
            this.filterBtn.UseVisualStyleBackColor = true;
            this.filterBtn.Click += new System.EventHandler(this.filterBtn_Click);
            // 
            // colNameInput
            // 
            this.colNameInput.Location = new System.Drawing.Point(1239, 129);
            this.colNameInput.Name = "colNameInput";
            this.colNameInput.Size = new System.Drawing.Size(150, 22);
            this.colNameInput.TabIndex = 6;
            // 
            // colNameLbl
            // 
            this.colNameLbl.AutoSize = true;
            this.colNameLbl.Location = new System.Drawing.Point(1136, 134);
            this.colNameLbl.Name = "colNameLbl";
            this.colNameLbl.Size = new System.Drawing.Size(93, 17);
            this.colNameLbl.TabIndex = 7;
            this.colNameLbl.Text = "Имя столбца";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1136, 284);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Значение";
            // 
            // conValueInput
            // 
            this.conValueInput.Location = new System.Drawing.Point(1239, 281);
            this.conValueInput.Name = "conValueInput";
            this.conValueInput.Size = new System.Drawing.Size(150, 22);
            this.conValueInput.TabIndex = 9;
            // 
            // greaterOrEqual
            // 
            this.greaterOrEqual.AutoSize = true;
            this.greaterOrEqual.Location = new System.Drawing.Point(6, 21);
            this.greaterOrEqual.Name = "greaterOrEqual";
            this.greaterOrEqual.Size = new System.Drawing.Size(45, 21);
            this.greaterOrEqual.TabIndex = 10;
            this.greaterOrEqual.TabStop = true;
            this.greaterOrEqual.Text = ">=";
            this.greaterOrEqual.UseVisualStyleBackColor = true;
            // 
            // operatorsForComparing
            // 
            this.operatorsForComparing.Controls.Add(this.equal);
            this.operatorsForComparing.Controls.Add(this.less);
            this.operatorsForComparing.Controls.Add(this.lessOrEqual);
            this.operatorsForComparing.Controls.Add(this.greater);
            this.operatorsForComparing.Controls.Add(this.greaterOrEqual);
            this.operatorsForComparing.Location = new System.Drawing.Point(1139, 168);
            this.operatorsForComparing.Name = "operatorsForComparing";
            this.operatorsForComparing.Size = new System.Drawing.Size(200, 97);
            this.operatorsForComparing.TabIndex = 11;
            this.operatorsForComparing.TabStop = false;
            this.operatorsForComparing.Text = "Оператор сравнения";
            // 
            // equal
            // 
            this.equal.AutoSize = true;
            this.equal.Checked = true;
            this.equal.Location = new System.Drawing.Point(6, 76);
            this.equal.Name = "equal";
            this.equal.Size = new System.Drawing.Size(37, 21);
            this.equal.TabIndex = 14;
            this.equal.TabStop = true;
            this.equal.Text = "=";
            this.equal.UseVisualStyleBackColor = true;
            // 
            // less
            // 
            this.less.AutoSize = true;
            this.less.Location = new System.Drawing.Point(100, 49);
            this.less.Name = "less";
            this.less.Size = new System.Drawing.Size(37, 21);
            this.less.TabIndex = 13;
            this.less.TabStop = true;
            this.less.Text = "<";
            this.less.UseVisualStyleBackColor = true;
            // 
            // lessOrEqual
            // 
            this.lessOrEqual.AutoSize = true;
            this.lessOrEqual.Location = new System.Drawing.Point(6, 49);
            this.lessOrEqual.Name = "lessOrEqual";
            this.lessOrEqual.Size = new System.Drawing.Size(45, 21);
            this.lessOrEqual.TabIndex = 12;
            this.lessOrEqual.TabStop = true;
            this.lessOrEqual.Text = "<=";
            this.lessOrEqual.UseVisualStyleBackColor = true;
            // 
            // greater
            // 
            this.greater.AutoSize = true;
            this.greater.Location = new System.Drawing.Point(100, 21);
            this.greater.Name = "greater";
            this.greater.Size = new System.Drawing.Size(37, 21);
            this.greater.TabIndex = 11;
            this.greater.TabStop = true;
            this.greater.Text = ">";
            this.greater.UseVisualStyleBackColor = true;
            // 
            // cancelFilterBtn
            // 
            this.cancelFilterBtn.Location = new System.Drawing.Point(1269, 68);
            this.cancelFilterBtn.Name = "cancelFilterBtn";
            this.cancelFilterBtn.Size = new System.Drawing.Size(109, 50);
            this.cancelFilterBtn.TabIndex = 12;
            this.cancelFilterBtn.Text = "Отменить фильтр";
            this.cancelFilterBtn.UseVisualStyleBackColor = true;
            this.cancelFilterBtn.Click += new System.EventHandler(this.cancelFilterBtn_Click);
            // 
            // sortBtn
            // 
            this.sortBtn.Location = new System.Drawing.Point(1139, 349);
            this.sortBtn.Name = "sortBtn";
            this.sortBtn.Size = new System.Drawing.Size(109, 50);
            this.sortBtn.TabIndex = 13;
            this.sortBtn.Text = "Применить сортировку";
            this.sortBtn.UseVisualStyleBackColor = true;
            this.sortBtn.Click += new System.EventHandler(this.sortBtn_Click);
            // 
            // cancelSortBtn
            // 
            this.cancelSortBtn.Location = new System.Drawing.Point(1269, 349);
            this.cancelSortBtn.Name = "cancelSortBtn";
            this.cancelSortBtn.Size = new System.Drawing.Size(109, 50);
            this.cancelSortBtn.TabIndex = 14;
            this.cancelSortBtn.Text = "Отменить сортировку";
            this.cancelSortBtn.UseVisualStyleBackColor = true;
            this.cancelSortBtn.Click += new System.EventHandler(this.cancelSortBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1142, 420);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Имя столбца";
            // 
            // colNameForSort
            // 
            this.colNameForSort.Location = new System.Drawing.Point(1239, 415);
            this.colNameForSort.Name = "colNameForSort";
            this.colNameForSort.Size = new System.Drawing.Size(150, 22);
            this.colNameForSort.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.secondSortType);
            this.groupBox1.Controls.Add(this.firstSortType);
            this.groupBox1.Location = new System.Drawing.Point(1145, 455);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 50);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // secondSortType
            // 
            this.secondSortType.AutoSize = true;
            this.secondSortType.Location = new System.Drawing.Point(6, 27);
            this.secondSortType.Name = "secondSortType";
            this.secondSortType.Size = new System.Drawing.Size(117, 21);
            this.secondSortType.TabIndex = 11;
            this.secondSortType.TabStop = true;
            this.secondSortType.Text = "По убыванию";
            this.secondSortType.UseVisualStyleBackColor = true;
            // 
            // firstSortType
            // 
            this.firstSortType.AutoSize = true;
            this.firstSortType.Checked = true;
            this.firstSortType.Location = new System.Drawing.Point(6, 0);
            this.firstSortType.Name = "firstSortType";
            this.firstSortType.Size = new System.Drawing.Size(137, 21);
            this.firstSortType.TabIndex = 10;
            this.firstSortType.TabStop = true;
            this.firstSortType.Text = "По возрастанию";
            this.firstSortType.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1401, 730);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.colNameForSort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancelSortBtn);
            this.Controls.Add(this.sortBtn);
            this.Controls.Add(this.cancelFilterBtn);
            this.Controls.Add(this.operatorsForComparing);
            this.Controls.Add(this.conValueInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.colNameLbl);
            this.Controls.Add(this.colNameInput);
            this.Controls.Add(this.filterBtn);
            this.Controls.Add(this.deleteRowBtn);
            this.Controls.Add(this.addRowBtn);
            this.Controls.Add(this.dataTable);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).EndInit();
            this.operatorsForComparing.ResumeLayout(false);
            this.operatorsForComparing.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Button filterBtn;
        private System.Windows.Forms.TextBox colNameInput;
        private System.Windows.Forms.Label colNameLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox conValueInput;
        private System.Windows.Forms.RadioButton greaterOrEqual;
        private System.Windows.Forms.GroupBox operatorsForComparing;
        private System.Windows.Forms.RadioButton equal;
        private System.Windows.Forms.RadioButton less;
        private System.Windows.Forms.RadioButton lessOrEqual;
        private System.Windows.Forms.RadioButton greater;
        private System.Windows.Forms.Button cancelFilterBtn;
        private System.Windows.Forms.Button sortBtn;
        private System.Windows.Forms.Button cancelSortBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox colNameForSort;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton secondSortType;
        private System.Windows.Forms.RadioButton firstSortType;
    }
}


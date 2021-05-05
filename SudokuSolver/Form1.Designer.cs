
namespace SudokuSolver
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
            this.panelSudokuGrid = new System.Windows.Forms.Panel();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnSolve = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.emptyCells = new System.Windows.Forms.Button();
            this.backtrackingCount = new System.Windows.Forms.Button();
            this.iterationsCount = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelSudokuGrid
            // 
            this.panelSudokuGrid.Location = new System.Drawing.Point(36, 30);
            this.panelSudokuGrid.Name = "panelSudokuGrid";
            this.panelSudokuGrid.Size = new System.Drawing.Size(484, 389);
            this.panelSudokuGrid.TabIndex = 0;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(542, 30);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(110, 34);
            this.btnOpenFile.TabIndex = 1;
            this.btnOpenFile.Text = "Open Sudoku";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(542, 82);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(110, 34);
            this.btnSolve.TabIndex = 2;
            this.btnSolve.Text = "Solve puzzle";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(542, 137);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(110, 34);
            this.btnCheck.TabIndex = 3;
            this.btnCheck.Text = "Check Solution";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(536, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Количество итераций";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(543, 268);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Количество откатов";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(525, 328);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Количество пустых клеток";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(526, 341);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = " перед работой алгоритма";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // emptyCells
            // 
            this.emptyCells.Location = new System.Drawing.Point(542, 367);
            this.emptyCells.Name = "emptyCells";
            this.emptyCells.Size = new System.Drawing.Size(110, 26);
            this.emptyCells.TabIndex = 8;
            this.emptyCells.Text = "button1";
            this.emptyCells.UseVisualStyleBackColor = true;
            // 
            // backtrackingCount
            // 
            this.backtrackingCount.Location = new System.Drawing.Point(542, 284);
            this.backtrackingCount.Name = "backtrackingCount";
            this.backtrackingCount.Size = new System.Drawing.Size(110, 26);
            this.backtrackingCount.TabIndex = 9;
            this.backtrackingCount.Text = "0";
            this.backtrackingCount.UseVisualStyleBackColor = true;
            // 
            // iterationsCount
            // 
            this.iterationsCount.Location = new System.Drawing.Point(542, 215);
            this.iterationsCount.Name = "iterationsCount";
            this.iterationsCount.Size = new System.Drawing.Size(110, 26);
            this.iterationsCount.TabIndex = 10;
            this.iterationsCount.Text = "0";
            this.iterationsCount.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 463);
            this.Controls.Add(this.iterationsCount);
            this.Controls.Add(this.backtrackingCount);
            this.Controls.Add(this.emptyCells);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnSolve);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.panelSudokuGrid);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelSudokuGrid;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button emptyCells;
        private System.Windows.Forms.Button backtrackingCount;
        private System.Windows.Forms.Button iterationsCount;
    }
}


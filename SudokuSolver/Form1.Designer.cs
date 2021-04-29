
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 463);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnSolve);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.panelSudokuGrid);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSudokuGrid;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Button btnCheck;
    }
}


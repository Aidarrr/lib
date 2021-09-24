
namespace Tetris
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
            this.components = new System.ComponentModel.Container();
            this.pbGameBoard = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pbNextFigure = new System.Windows.Forms.PictureBox();
            this.lblScores = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbGameBoard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNextFigure)).BeginInit();
            this.SuspendLayout();
            // 
            // pbGameBoard
            // 
            this.pbGameBoard.Location = new System.Drawing.Point(232, 15);
            this.pbGameBoard.Margin = new System.Windows.Forms.Padding(4);
            this.pbGameBoard.Name = "pbGameBoard";
            this.pbGameBoard.Size = new System.Drawing.Size(596, 742);
            this.pbGameBoard.TabIndex = 0;
            this.pbGameBoard.TabStop = false;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // pbNextFigure
            // 
            this.pbNextFigure.Location = new System.Drawing.Point(845, 15);
            this.pbNextFigure.Margin = new System.Windows.Forms.Padding(4);
            this.pbNextFigure.Name = "pbNextFigure";
            this.pbNextFigure.Size = new System.Drawing.Size(289, 230);
            this.pbNextFigure.TabIndex = 1;
            this.pbNextFigure.TabStop = false;
            // 
            // lblScores
            // 
            this.lblScores.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblScores.Location = new System.Drawing.Point(841, 271);
            this.lblScores.Name = "lblScores";
            this.lblScores.Size = new System.Drawing.Size(208, 21);
            this.lblScores.TabIndex = 2;
            this.lblScores.Text = "Scores: 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1192, 1028);
            this.Controls.Add(this.lblScores);
            this.Controls.Add(this.pbNextFigure);
            this.Controls.Add(this.pbGameBoard);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pbGameBoard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNextFigure)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbGameBoard;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox pbNextFigure;
        private System.Windows.Forms.Label lblScores;
    }
}


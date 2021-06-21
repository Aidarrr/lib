
namespace Sokoban
{
    partial class FormForCompletedLevel
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblLevelNum = new System.Windows.Forms.Label();
            this.lblMovesCount = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnChooseLvl = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnNextLevel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(48, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Уровень пройден!";
            // 
            // lblLevelNum
            // 
            this.lblLevelNum.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLevelNum.Location = new System.Drawing.Point(104, 53);
            this.lblLevelNum.Name = "lblLevelNum";
            this.lblLevelNum.Size = new System.Drawing.Size(120, 25);
            this.lblLevelNum.TabIndex = 3;
            this.lblLevelNum.Text = "Уровень №";
            // 
            // lblMovesCount
            // 
            this.lblMovesCount.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMovesCount.Location = new System.Drawing.Point(12, 90);
            this.lblMovesCount.Name = "lblMovesCount";
            this.lblMovesCount.Size = new System.Drawing.Size(120, 25);
            this.lblMovesCount.TabIndex = 4;
            this.lblMovesCount.Text = "Ходов: ";
            // 
            // lblTime
            // 
            this.lblTime.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTime.Location = new System.Drawing.Point(198, 90);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(141, 25);
            this.lblTime.TabIndex = 5;
            this.lblTime.Text = "Время: ";
            // 
            // btnChooseLvl
            // 
            this.btnChooseLvl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnChooseLvl.Location = new System.Drawing.Point(16, 133);
            this.btnChooseLvl.Name = "btnChooseLvl";
            this.btnChooseLvl.Size = new System.Drawing.Size(81, 40);
            this.btnChooseLvl.TabIndex = 6;
            this.btnChooseLvl.Text = "Выбрать уровень";
            this.btnChooseLvl.UseVisualStyleBackColor = true;
            this.btnChooseLvl.Click += new System.EventHandler(this.btnChooseLvl_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRestart.Location = new System.Drawing.Point(126, 133);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(81, 40);
            this.btnRestart.TabIndex = 7;
            this.btnRestart.Text = "Начать сначала";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnNextLevel
            // 
            this.btnNextLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnNextLevel.Location = new System.Drawing.Point(230, 133);
            this.btnNextLevel.Name = "btnNextLevel";
            this.btnNextLevel.Size = new System.Drawing.Size(81, 40);
            this.btnNextLevel.TabIndex = 8;
            this.btnNextLevel.Text = "Следующий уровень";
            this.btnNextLevel.UseVisualStyleBackColor = true;
            this.btnNextLevel.Click += new System.EventHandler(this.btnNextLevel_Click);
            // 
            // FormForCompletedLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 195);
            this.Controls.Add(this.btnNextLevel);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnChooseLvl);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblMovesCount);
            this.Controls.Add(this.lblLevelNum);
            this.Controls.Add(this.label1);
            this.Name = "FormForCompletedLevel";
            this.Text = "FormForCompletedLevel";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLevelNum;
        private System.Windows.Forms.Label lblMovesCount;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button btnChooseLvl;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnNextLevel;
    }
}
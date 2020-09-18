namespace CDA_Brezenhem
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
            this.pbCDA = new System.Windows.Forms.PictureBox();
            this.pbBrez = new System.Windows.Forms.PictureBox();
            this.pbLine = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCDA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBrez)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLine)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCDA
            // 
            this.pbCDA.Location = new System.Drawing.Point(12, 12);
            this.pbCDA.Name = "pbCDA";
            this.pbCDA.Size = new System.Drawing.Size(445, 278);
            this.pbCDA.TabIndex = 0;
            this.pbCDA.TabStop = false;
            this.pbCDA.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pbBrez
            // 
            this.pbBrez.Location = new System.Drawing.Point(463, 12);
            this.pbBrez.Name = "pbBrez";
            this.pbBrez.Size = new System.Drawing.Size(459, 279);
            this.pbBrez.TabIndex = 1;
            this.pbBrez.TabStop = false;
            // 
            // pbLine
            // 
            this.pbLine.Location = new System.Drawing.Point(12, 309);
            this.pbLine.Name = "pbLine";
            this.pbLine.Size = new System.Drawing.Size(911, 281);
            this.pbLine.TabIndex = 2;
            this.pbLine.TabStop = false;
            this.pbLine.Click += new System.EventHandler(this.pbLine_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 605);
            this.Controls.Add(this.pbLine);
            this.Controls.Add(this.pbBrez);
            this.Controls.Add(this.pbCDA);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCDA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBrez)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLine)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCDA;
        private System.Windows.Forms.PictureBox pbBrez;
        private System.Windows.Forms.PictureBox pbLine;
    }
}


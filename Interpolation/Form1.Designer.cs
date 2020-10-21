namespace Interpolation
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
            this.pbGouraud = new System.Windows.Forms.PictureBox();
            this.pbBarycentric = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbGouraud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBarycentric)).BeginInit();
            this.SuspendLayout();
            // 
            // pbGouraud
            // 
            this.pbGouraud.Location = new System.Drawing.Point(12, 12);
            this.pbGouraud.Name = "pbGouraud";
            this.pbGouraud.Size = new System.Drawing.Size(532, 341);
            this.pbGouraud.TabIndex = 0;
            this.pbGouraud.TabStop = false;
            // 
            // pbBarycentric
            // 
            this.pbBarycentric.Location = new System.Drawing.Point(595, 12);
            this.pbBarycentric.Name = "pbBarycentric";
            this.pbBarycentric.Size = new System.Drawing.Size(526, 341);
            this.pbBarycentric.TabIndex = 1;
            this.pbBarycentric.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 733);
            this.Controls.Add(this.pbBarycentric);
            this.Controls.Add(this.pbGouraud);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbGouraud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBarycentric)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbGouraud;
        private System.Windows.Forms.PictureBox pbBarycentric;
    }
}


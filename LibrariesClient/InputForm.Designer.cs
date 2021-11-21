
namespace LibrariesClient
{
    partial class InputForm
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
            this.tableForUser = new System.Windows.Forms.DataGridView();
            this.userInput = new System.Windows.Forms.TextBox();
            this.messageForUserLbl = new System.Windows.Forms.Label();
            this.applyBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tableForUser)).BeginInit();
            this.SuspendLayout();
            // 
            // tableForUser
            // 
            this.tableForUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableForUser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableForUser.Location = new System.Drawing.Point(0, 53);
            this.tableForUser.Name = "tableForUser";
            this.tableForUser.RowHeadersWidth = 51;
            this.tableForUser.RowTemplate.Height = 24;
            this.tableForUser.Size = new System.Drawing.Size(693, 390);
            this.tableForUser.TabIndex = 0;
            // 
            // userInput
            // 
            this.userInput.Location = new System.Drawing.Point(0, 20);
            this.userInput.Name = "userInput";
            this.userInput.Size = new System.Drawing.Size(215, 22);
            this.userInput.TabIndex = 1;
            // 
            // messageForUserLbl
            // 
            this.messageForUserLbl.AutoSize = true;
            this.messageForUserLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.messageForUserLbl.Location = new System.Drawing.Point(0, 0);
            this.messageForUserLbl.Name = "messageForUserLbl";
            this.messageForUserLbl.Size = new System.Drawing.Size(88, 17);
            this.messageForUserLbl.TabIndex = 2;
            this.messageForUserLbl.Text = "Text for user";
            // 
            // applyBtn
            // 
            this.applyBtn.Location = new System.Drawing.Point(248, 20);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(72, 22);
            this.applyBtn.TabIndex = 3;
            this.applyBtn.Text = "Ok";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 443);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.messageForUserLbl);
            this.Controls.Add(this.userInput);
            this.Controls.Add(this.tableForUser);
            this.Name = "InputForm";
            this.Text = "InputForm";
            this.Load += new System.EventHandler(this.InputForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tableForUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tableForUser;
        private System.Windows.Forms.TextBox userInput;
        private System.Windows.Forms.Label messageForUserLbl;
        private System.Windows.Forms.Button applyBtn;
    }
}
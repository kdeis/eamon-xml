namespace Adventure.MainHall
{
    partial class WizardForm
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
            this.mBtnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mBtnClose
            // 
            this.mBtnClose.Location = new System.Drawing.Point(230, 314);
            this.mBtnClose.Name = "mBtnClose";
            this.mBtnClose.Size = new System.Drawing.Size(75, 23);
            this.mBtnClose.TabIndex = 4;
            this.mBtnClose.Text = "Close";
            this.mBtnClose.UseVisualStyleBackColor = true;
            this.mBtnClose.Visible = false;
            this.mBtnClose.Click += new System.EventHandler(this.MBtnClose_Click);
            // 
            // WizardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(564, 370);
            this.Controls.Add(this.mBtnClose);
            this.Name = "WizardForm";
            this.Controls.SetChildIndex(this.mRtxtWhatYouSee, 0);
            this.Controls.SetChildIndex(this.mLblCommand, 0);
            this.Controls.SetChildIndex(this.mLblRoom, 0);
            this.Controls.SetChildIndex(this.historyTextBox1, 0);
            this.Controls.SetChildIndex(this.mBtnOk, 0);
            this.Controls.SetChildIndex(this.mBtnClose, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button mBtnClose;
    }
}

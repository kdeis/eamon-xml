namespace Adventure
{
    partial class HistoryTextBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mTxtBoxInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // mTxtBoxInput
            // 
            this.mTxtBoxInput.Location = new System.Drawing.Point(12, 3);
            this.mTxtBoxInput.Name = "mTxtBoxInput";
            this.mTxtBoxInput.Size = new System.Drawing.Size(200, 20);
            this.mTxtBoxInput.TabIndex = 0;
            this.mTxtBoxInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mTxtBoxInput_KeyDown);
            // 
            // HistoryTextBox
            // 
            this.Size = new System.Drawing.Size(225, 20);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mTxtBoxInput_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox mTxtBoxInput;
    }
}

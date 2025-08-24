namespace Adventure.MainHall
{
    partial class CharSelectDialog
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
            this.mLbxChooseChar = new System.Windows.Forms.ListBox();
            this.mBtnCancel = new System.Windows.Forms.Button();
            this.mBtnLoad = new System.Windows.Forms.Button();
            this.mBtnCreateChar = new System.Windows.Forms.Button();
            this.mBtnDelete = new System.Windows.Forms.Button();
            this.mTbxIrish = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // mLbxChooseChar
            // 
            this.mLbxChooseChar.DisplayMember = "Name";
            this.mLbxChooseChar.FormattingEnabled = true;
            this.mLbxChooseChar.Location = new System.Drawing.Point(13, 52);
            this.mLbxChooseChar.Name = "mLbxChooseChar";
            this.mLbxChooseChar.Size = new System.Drawing.Size(318, 160);
            this.mLbxChooseChar.TabIndex = 0;
            this.mLbxChooseChar.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MLbxChooseChar_MouseDoubleClick);
            // 
            // mBtnCancel
            // 
            this.mBtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.mBtnCancel.Location = new System.Drawing.Point(256, 226);
            this.mBtnCancel.Name = "mBtnCancel";
            this.mBtnCancel.Size = new System.Drawing.Size(75, 23);
            this.mBtnCancel.TabIndex = 1;
            this.mBtnCancel.Text = "Cancel";
            this.mBtnCancel.UseVisualStyleBackColor = true;
            // 
            // mBtnLoad
            // 
            this.mBtnLoad.Location = new System.Drawing.Point(94, 226);
            this.mBtnLoad.Name = "mBtnLoad";
            this.mBtnLoad.Size = new System.Drawing.Size(75, 23);
            this.mBtnLoad.TabIndex = 2;
            this.mBtnLoad.Text = "Load";
            this.mBtnLoad.UseVisualStyleBackColor = true;
            this.mBtnLoad.Click += new System.EventHandler(this.mBtnLoad_Click);
            // 
            // mBtnCreateChar
            // 
            this.mBtnCreateChar.Location = new System.Drawing.Point(13, 226);
            this.mBtnCreateChar.Name = "mBtnCreateChar";
            this.mBtnCreateChar.Size = new System.Drawing.Size(75, 23);
            this.mBtnCreateChar.TabIndex = 3;
            this.mBtnCreateChar.Text = "Create New";
            this.mBtnCreateChar.UseVisualStyleBackColor = true;
            this.mBtnCreateChar.Click += new System.EventHandler(this.mBtnCreateChar_Click);
            // 
            // mBtnDelete
            // 
            this.mBtnDelete.Location = new System.Drawing.Point(175, 226);
            this.mBtnDelete.Name = "mBtnDelete";
            this.mBtnDelete.Size = new System.Drawing.Size(75, 23);
            this.mBtnDelete.TabIndex = 4;
            this.mBtnDelete.Text = "Delete";
            this.mBtnDelete.UseVisualStyleBackColor = true;
            this.mBtnDelete.Click += new System.EventHandler(this.mBtnDelete_Click);
            // 
            // mTbxIrish
            // 
            this.mTbxIrish.Location = new System.Drawing.Point(13, 13);
            this.mTbxIrish.Multiline = true;
            this.mTbxIrish.Name = "mTbxIrish";
            this.mTbxIrish.ReadOnly = true;
            this.mTbxIrish.Size = new System.Drawing.Size(318, 33);
            this.mTbxIrish.TabIndex = 5;
            this.mTbxIrish.Text = "You are greeted there by a burly Irishman who looks at you with a scowl and asks," +
    " \"What\'s yer name?\"";
            // 
            // CharSelectDialog
            // 
            this.AcceptButton = this.mBtnLoad;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.mBtnCancel;
            this.ClientSize = new System.Drawing.Size(345, 261);
            this.ControlBox = false;
            this.Controls.Add(this.mTbxIrish);
            this.Controls.Add(this.mBtnDelete);
            this.Controls.Add(this.mBtnCreateChar);
            this.Controls.Add(this.mBtnLoad);
            this.Controls.Add(this.mBtnCancel);
            this.Controls.Add(this.mLbxChooseChar);
            this.Name = "CharSelectDialog";
            this.Text = "Choose your Hero";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox mLbxChooseChar;
        private System.Windows.Forms.Button mBtnCancel;
        private System.Windows.Forms.Button mBtnLoad;
        private System.Windows.Forms.Button mBtnCreateChar;
        private System.Windows.Forms.Button mBtnDelete;
        private System.Windows.Forms.TextBox mTbxIrish;
    }
}
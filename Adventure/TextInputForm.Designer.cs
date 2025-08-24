namespace Adventure
{
    partial class TextInputForm
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
            this.mRtxtWhatYouSee = new System.Windows.Forms.RichTextBox();
            this.mLblCommand = new System.Windows.Forms.Label();
            this.mLblRoom = new System.Windows.Forms.Label();
            this.mBtnOk = new System.Windows.Forms.Button();
            this.historyTextBox1 = new Adventure.HistoryTextBox();
            this.SuspendLayout();
            // 
            // mRtxtWhatYouSee
            // 
            this.mRtxtWhatYouSee.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mRtxtWhatYouSee.Location = new System.Drawing.Point(43, 64);
            this.mRtxtWhatYouSee.Name = "mRtxtWhatYouSee";
            this.mRtxtWhatYouSee.ReadOnly = true;
            this.mRtxtWhatYouSee.Size = new System.Drawing.Size(481, 234);
            this.mRtxtWhatYouSee.TabIndex = 0;
            this.mRtxtWhatYouSee.TabStop = false;
            this.mRtxtWhatYouSee.Text = "";
            // 
            // mLblCommand
            // 
            this.mLblCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mLblCommand.AutoSize = true;
            this.mLblCommand.Location = new System.Drawing.Point(40, 319);
            this.mLblCommand.Name = "mLblCommand";
            this.mLblCommand.Size = new System.Drawing.Size(57, 13);
            this.mLblCommand.TabIndex = 3;
            this.mLblCommand.Text = "Command:";
            // 
            // mLblRoom
            // 
            this.mLblRoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mLblRoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mLblRoom.Location = new System.Drawing.Point(43, 13);
            this.mLblRoom.Name = "mLblRoom";
            this.mLblRoom.Size = new System.Drawing.Size(481, 23);
            this.mLblRoom.TabIndex = 0;
            // 
            // mBtnOk
            // 
            this.mBtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mBtnOk.Location = new System.Drawing.Point(403, 314);
            this.mBtnOk.Name = "mBtnOk";
            this.mBtnOk.Size = new System.Drawing.Size(75, 23);
            this.mBtnOk.TabIndex = 2;
            this.mBtnOk.Text = "OK";
            this.mBtnOk.UseVisualStyleBackColor = true;
            this.mBtnOk.Click += new System.EventHandler(this.mBtnOk_Click);
            // 
            // historyTextBox1
            // 
            this.historyTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.historyTextBox1.Location = new System.Drawing.Point(97, 316);
            this.historyTextBox1.Name = "historyTextBox1";
            this.historyTextBox1.Size = new System.Drawing.Size(300, 20);
            this.historyTextBox1.TabIndex = 1;
            // 
            // DungeonForm
            // 
            this.AcceptButton = this.mBtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 370);
            this.Controls.Add(this.mBtnOk);
            this.Controls.Add(this.historyTextBox1);
            this.Controls.Add(this.mLblRoom);
            this.Controls.Add(this.mLblCommand);
            this.Controls.Add(this.mRtxtWhatYouSee);
            this.Name = "DungeonForm";
            this.Text = "Adventure";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.RichTextBox mRtxtWhatYouSee;
        protected System.Windows.Forms.Label mLblCommand;
        protected System.Windows.Forms.Label mLblRoom;
        protected HistoryTextBox historyTextBox1;
        protected System.Windows.Forms.Button mBtnOk;
    }
}


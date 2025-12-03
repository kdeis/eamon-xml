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
            this.button1 = new System.Windows.Forms.Button();
            this.mBtnLeave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mRtxtWhatYouSee
            // 
            this.mRtxtWhatYouSee.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mRtxtWhatYouSee.Location = new System.Drawing.Point(95, 85);
            this.mRtxtWhatYouSee.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.mRtxtWhatYouSee.Name = "mRtxtWhatYouSee";
            this.mRtxtWhatYouSee.ReadOnly = true;
            this.mRtxtWhatYouSee.Size = new System.Drawing.Size(813, 482);
            this.mRtxtWhatYouSee.TabIndex = 0;
            this.mRtxtWhatYouSee.TabStop = false;
            this.mRtxtWhatYouSee.Text = "";
            this.mRtxtWhatYouSee.SizeChanged += new System.EventHandler(this.mRtxtWhatYouSee_SizeChanged);
            // 
            // mLblCommand
            // 
            this.mLblCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mLblCommand.AutoSize = true;
            this.mLblCommand.Location = new System.Drawing.Point(91, 585);
            this.mLblCommand.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.mLblCommand.Name = "mLblCommand";
            this.mLblCommand.Size = new System.Drawing.Size(95, 22);
            this.mLblCommand.TabIndex = 3;
            this.mLblCommand.Text = "Command:";
            // 
            // mLblRoom
            // 
            this.mLblRoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mLblRoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mLblRoom.Location = new System.Drawing.Point(95, 28);
            this.mLblRoom.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.mLblRoom.Name = "mLblRoom";
            this.mLblRoom.Size = new System.Drawing.Size(813, 36);
            this.mLblRoom.TabIndex = 0;
            // 
            // mBtnOk
            // 
            this.mBtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mBtnOk.Location = new System.Drawing.Point(834, 582);
            this.mBtnOk.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.mBtnOk.Name = "mBtnOk";
            this.mBtnOk.Size = new System.Drawing.Size(74, 35);
            this.mBtnOk.TabIndex = 2;
            this.mBtnOk.Text = "OK";
            this.mBtnOk.UseVisualStyleBackColor = true;
            this.mBtnOk.Click += new System.EventHandler(this.mBtnOk_Click);
            // 
            // historyTextBox1
            // 
            this.historyTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.historyTextBox1.Location = new System.Drawing.Point(198, 585);
            this.historyTextBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.historyTextBox1.Name = "historyTextBox1";
            this.historyTextBox1.Size = new System.Drawing.Size(624, 30);
            this.historyTextBox1.TabIndex = 1;
            this.historyTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.historyTextBox1_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // mBtnLeave
            // 
            this.mBtnLeave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.mBtnLeave.Location = new System.Drawing.Point(471, 572);
            this.mBtnLeave.Name = "mBtnLeave";
            this.mBtnLeave.Size = new System.Drawing.Size(75, 35);
            this.mBtnLeave.TabIndex = 5;
            this.mBtnLeave.Text = "Leave";
            this.mBtnLeave.UseVisualStyleBackColor = true;
            this.mBtnLeave.Visible = false;
            // 
            // TextInputForm
            // 
            this.AcceptButton = this.mBtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.mBtnLeave;
            this.ClientSize = new System.Drawing.Size(1006, 642);
            this.Controls.Add(this.mBtnLeave);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mBtnOk);
            this.Controls.Add(this.historyTextBox1);
            this.Controls.Add(this.mLblRoom);
            this.Controls.Add(this.mLblCommand);
            this.Controls.Add(this.mRtxtWhatYouSee);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "TextInputForm";
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
        private System.Windows.Forms.Button button1;
        protected System.Windows.Forms.Button mBtnLeave;
    }
}


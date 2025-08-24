namespace Adventure.MainHall
{
    partial class MainHallForm
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
            this.mBtnDesk = new System.Windows.Forms.Button();
            this.mBtnAdventure = new System.Windows.Forms.Button();
            this.mRtbGreeting = new System.Windows.Forms.RichTextBox();
            this.mBtnMen = new System.Windows.Forms.Button();
            this.mBtnLeave = new System.Windows.Forms.Button();
            this.mBtnQuit = new System.Windows.Forms.Button();
            this.mBtnWizard = new System.Windows.Forms.Button();
            this.mBtnShop = new System.Windows.Forms.Button();
            this.mPnlIntro = new System.Windows.Forms.Panel();
            this.mPnlMain = new System.Windows.Forms.Panel();
            this.mBtnView = new System.Windows.Forms.Button();
            this.mPnlIntro.SuspendLayout();
            this.mPnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mBtnDesk
            // 
            this.mBtnDesk.Location = new System.Drawing.Point(15, 15);
            this.mBtnDesk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mBtnDesk.Name = "mBtnDesk";
            this.mBtnDesk.Size = new System.Drawing.Size(100, 28);
            this.mBtnDesk.TabIndex = 1;
            this.mBtnDesk.Text = "&Desk";
            this.mBtnDesk.UseVisualStyleBackColor = true;
            this.mBtnDesk.Click += new System.EventHandler(this.mBtnDesk_Click);
            // 
            // mBtnAdventure
            // 
            this.mBtnAdventure.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mBtnAdventure.Location = new System.Drawing.Point(13, 4);
            this.mBtnAdventure.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mBtnAdventure.Name = "mBtnAdventure";
            this.mBtnAdventure.Size = new System.Drawing.Size(255, 28);
            this.mBtnAdventure.TabIndex = 3;
            this.mBtnAdventure.Text = "&Go on an Adventure!";
            this.mBtnAdventure.UseVisualStyleBackColor = true;
            this.mBtnAdventure.Click += new System.EventHandler(this.mBtnAdventure_Click);
            // 
            // mRtbGreeting
            // 
            this.mRtbGreeting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mRtbGreeting.Location = new System.Drawing.Point(25, 15);
            this.mRtbGreeting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mRtbGreeting.Name = "mRtbGreeting";
            this.mRtbGreeting.ReadOnly = true;
            this.mRtbGreeting.Size = new System.Drawing.Size(513, 207);
            this.mRtbGreeting.TabIndex = 5;
            this.mRtbGreeting.Text = "";
            // 
            // mBtnMen
            // 
            this.mBtnMen.Location = new System.Drawing.Point(123, 15);
            this.mBtnMen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mBtnMen.Name = "mBtnMen";
            this.mBtnMen.Size = new System.Drawing.Size(100, 28);
            this.mBtnMen.TabIndex = 2;
            this.mBtnMen.Text = "&Men";
            this.mBtnMen.UseVisualStyleBackColor = true;
            this.mBtnMen.Click += new System.EventHandler(this.mBtnMen_Click);
            // 
            // mBtnLeave
            // 
            this.mBtnLeave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mBtnLeave.Location = new System.Drawing.Point(26, 306);
            this.mBtnLeave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mBtnLeave.Name = "mBtnLeave";
            this.mBtnLeave.Size = new System.Drawing.Size(255, 28);
            this.mBtnLeave.TabIndex = 6;
            this.mBtnLeave.Text = "Temporarily &Leave the Universe";
            this.mBtnLeave.UseVisualStyleBackColor = true;
            this.mBtnLeave.Click += new System.EventHandler(this.mBtnLeave_Click);
            // 
            // mBtnQuit
            // 
            this.mBtnQuit.Location = new System.Drawing.Point(231, 15);
            this.mBtnQuit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mBtnQuit.Name = "mBtnQuit";
            this.mBtnQuit.Size = new System.Drawing.Size(100, 28);
            this.mBtnQuit.TabIndex = 7;
            this.mBtnQuit.Text = "&Quit";
            this.mBtnQuit.UseVisualStyleBackColor = true;
            this.mBtnQuit.Click += new System.EventHandler(this.mBtnQuit_Click);
            // 
            // mBtnWizard
            // 
            this.mBtnWizard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mBtnWizard.Location = new System.Drawing.Point(13, 39);
            this.mBtnWizard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mBtnWizard.Name = "mBtnWizard";
            this.mBtnWizard.Size = new System.Drawing.Size(255, 28);
            this.mBtnWizard.TabIndex = 9;
            this.mBtnWizard.Text = "Learn &Spells";
            this.mBtnWizard.UseVisualStyleBackColor = true;
            this.mBtnWizard.Click += new System.EventHandler(this.MBtnWizard_Click);
            // 
            // mBtnShop
            // 
            this.mBtnShop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mBtnShop.Location = new System.Drawing.Point(273, 4);
            this.mBtnShop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mBtnShop.Name = "mBtnShop";
            this.mBtnShop.Size = new System.Drawing.Size(255, 28);
            this.mBtnShop.TabIndex = 8;
            this.mBtnShop.Text = "&Buy Weapons and Armor";
            this.mBtnShop.UseVisualStyleBackColor = true;
            this.mBtnShop.Click += new System.EventHandler(this.MBtnShop_Click);
            // 
            // mPnlIntro
            // 
            this.mPnlIntro.Controls.Add(this.mPnlMain);
            this.mPnlIntro.Controls.Add(this.mBtnDesk);
            this.mPnlIntro.Controls.Add(this.mBtnMen);
            this.mPnlIntro.Controls.Add(this.mBtnQuit);
            this.mPnlIntro.Location = new System.Drawing.Point(11, 230);
            this.mPnlIntro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mPnlIntro.Name = "mPnlIntro";
            this.mPnlIntro.Size = new System.Drawing.Size(544, 85);
            this.mPnlIntro.TabIndex = 10;
            // 
            // mPnlMain
            // 
            this.mPnlMain.Controls.Add(this.mBtnView);
            this.mPnlMain.Controls.Add(this.mBtnAdventure);
            this.mPnlMain.Controls.Add(this.mBtnShop);
            this.mPnlMain.Controls.Add(this.mBtnWizard);
            this.mPnlMain.Location = new System.Drawing.Point(1, 1);
            this.mPnlMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mPnlMain.Name = "mPnlMain";
            this.mPnlMain.Size = new System.Drawing.Size(543, 122);
            this.mPnlMain.TabIndex = 11;
            this.mPnlMain.Visible = false;
            // 
            // mBtnView
            // 
            this.mBtnView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mBtnView.Location = new System.Drawing.Point(273, 39);
            this.mBtnView.Margin = new System.Windows.Forms.Padding(4);
            this.mBtnView.Name = "mBtnView";
            this.mBtnView.Size = new System.Drawing.Size(255, 28);
            this.mBtnView.TabIndex = 10;
            this.mBtnView.Text = "&View Stats and Items";
            this.mBtnView.UseVisualStyleBackColor = true;
            this.mBtnView.Click += new System.EventHandler(this.MBtnView_Click);
            // 
            // MainHallForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 366);
            this.Controls.Add(this.mPnlIntro);
            this.Controls.Add(this.mRtbGreeting);
            this.Controls.Add(this.mBtnLeave);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainHallForm";
            this.Text = "Main Hall";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainHallForm_KeyDown);
            this.mPnlIntro.ResumeLayout(false);
            this.mPnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button mBtnDesk;
        private System.Windows.Forms.Button mBtnAdventure;
        private System.Windows.Forms.RichTextBox mRtbGreeting;
        private System.Windows.Forms.Button mBtnMen;
        private System.Windows.Forms.Button mBtnLeave;
        private System.Windows.Forms.Button mBtnQuit;
        private System.Windows.Forms.Button mBtnWizard;
        private System.Windows.Forms.Button mBtnShop;
        private System.Windows.Forms.Panel mPnlIntro;
        private System.Windows.Forms.Panel mPnlMain;
        private System.Windows.Forms.Button mBtnView;
    }
}
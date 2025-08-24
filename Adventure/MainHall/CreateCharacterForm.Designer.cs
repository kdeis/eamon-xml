namespace Adventure.MainHall
{
    partial class CreateCharacterForm
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
            this.mBtnCancel = new System.Windows.Forms.Button();
            this.mBtnReroll = new System.Windows.Forms.Button();
            this.mBtnSave = new System.Windows.Forms.Button();
            this.mLblName = new System.Windows.Forms.Label();
            this.mTbxName = new System.Windows.Forms.TextBox();
            this.mGbxAttributes = new System.Windows.Forms.GroupBox();
            this.mLblCharisma = new System.Windows.Forms.Label();
            this.mTbxCharisma = new System.Windows.Forms.TextBox();
            this.mLblHardiness = new System.Windows.Forms.Label();
            this.mTbxHardiness = new System.Windows.Forms.TextBox();
            this.mLblAgility = new System.Windows.Forms.Label();
            this.mTbxAgility = new System.Windows.Forms.TextBox();
            this.mGbxAttributes.SuspendLayout();
            this.SuspendLayout();
            // 
            // mBtnCancel
            // 
            this.mBtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mBtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.mBtnCancel.Location = new System.Drawing.Point(174, 187);
            this.mBtnCancel.Name = "mBtnCancel";
            this.mBtnCancel.Size = new System.Drawing.Size(75, 23);
            this.mBtnCancel.TabIndex = 0;
            this.mBtnCancel.Text = "Cancel";
            this.mBtnCancel.UseVisualStyleBackColor = true;
            // 
            // mBtnReroll
            // 
            this.mBtnReroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mBtnReroll.Location = new System.Drawing.Point(93, 187);
            this.mBtnReroll.Name = "mBtnReroll";
            this.mBtnReroll.Size = new System.Drawing.Size(75, 23);
            this.mBtnReroll.TabIndex = 1;
            this.mBtnReroll.Text = "Roll Again";
            this.mBtnReroll.UseVisualStyleBackColor = true;
            this.mBtnReroll.Click += new System.EventHandler(this.mBtnReroll_Click);
            // 
            // mBtnSave
            // 
            this.mBtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mBtnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.mBtnSave.Location = new System.Drawing.Point(12, 187);
            this.mBtnSave.Name = "mBtnSave";
            this.mBtnSave.Size = new System.Drawing.Size(75, 23);
            this.mBtnSave.TabIndex = 2;
            this.mBtnSave.Text = "Save";
            this.mBtnSave.UseVisualStyleBackColor = true;
            // 
            // mLblName
            // 
            this.mLblName.AutoSize = true;
            this.mLblName.Location = new System.Drawing.Point(13, 13);
            this.mLblName.Name = "mLblName";
            this.mLblName.Size = new System.Drawing.Size(35, 13);
            this.mLblName.TabIndex = 3;
            this.mLblName.Text = "Name";
            // 
            // mTbxName
            // 
            this.mTbxName.Location = new System.Drawing.Point(55, 13);
            this.mTbxName.Name = "mTbxName";
            this.mTbxName.Size = new System.Drawing.Size(100, 20);
            this.mTbxName.TabIndex = 4;
            this.mTbxName.TextChanged += new System.EventHandler(this.mTbxName_TextChanged);
            this.mTbxName.Validating += new System.ComponentModel.CancelEventHandler(this.mTbxName_Validating);
            // 
            // mGbxAttributes
            // 
            this.mGbxAttributes.Controls.Add(this.mLblCharisma);
            this.mGbxAttributes.Controls.Add(this.mTbxCharisma);
            this.mGbxAttributes.Controls.Add(this.mLblHardiness);
            this.mGbxAttributes.Controls.Add(this.mTbxHardiness);
            this.mGbxAttributes.Controls.Add(this.mLblAgility);
            this.mGbxAttributes.Controls.Add(this.mTbxAgility);
            this.mGbxAttributes.Location = new System.Drawing.Point(13, 42);
            this.mGbxAttributes.Name = "mGbxAttributes";
            this.mGbxAttributes.Size = new System.Drawing.Size(200, 133);
            this.mGbxAttributes.TabIndex = 5;
            this.mGbxAttributes.TabStop = false;
            this.mGbxAttributes.Text = "Attributes";
            // 
            // mLblCharisma
            // 
            this.mLblCharisma.AutoSize = true;
            this.mLblCharisma.Location = new System.Drawing.Point(7, 104);
            this.mLblCharisma.Name = "mLblCharisma";
            this.mLblCharisma.Size = new System.Drawing.Size(53, 13);
            this.mLblCharisma.TabIndex = 7;
            this.mLblCharisma.Text = "Charisma:";
            // 
            // mTbxCharisma
            // 
            this.mTbxCharisma.Location = new System.Drawing.Point(69, 101);
            this.mTbxCharisma.Name = "mTbxCharisma";
            this.mTbxCharisma.ReadOnly = true;
            this.mTbxCharisma.Size = new System.Drawing.Size(100, 20);
            this.mTbxCharisma.TabIndex = 6;
            // 
            // mLblHardiness
            // 
            this.mLblHardiness.AutoSize = true;
            this.mLblHardiness.Location = new System.Drawing.Point(7, 77);
            this.mLblHardiness.Name = "mLblHardiness";
            this.mLblHardiness.Size = new System.Drawing.Size(57, 13);
            this.mLblHardiness.TabIndex = 5;
            this.mLblHardiness.Text = "Hardiness:";
            // 
            // mTbxHardiness
            // 
            this.mTbxHardiness.Location = new System.Drawing.Point(69, 74);
            this.mTbxHardiness.Name = "mTbxHardiness";
            this.mTbxHardiness.ReadOnly = true;
            this.mTbxHardiness.Size = new System.Drawing.Size(100, 20);
            this.mTbxHardiness.TabIndex = 4;
            // 
            // mLblAgility
            // 
            this.mLblAgility.AutoSize = true;
            this.mLblAgility.Location = new System.Drawing.Point(7, 50);
            this.mLblAgility.Name = "mLblAgility";
            this.mLblAgility.Size = new System.Drawing.Size(37, 13);
            this.mLblAgility.TabIndex = 3;
            this.mLblAgility.Text = "Agility:";
            // 
            // mTbxAgility
            // 
            this.mTbxAgility.Location = new System.Drawing.Point(69, 47);
            this.mTbxAgility.Name = "mTbxAgility";
            this.mTbxAgility.ReadOnly = true;
            this.mTbxAgility.Size = new System.Drawing.Size(100, 20);
            this.mTbxAgility.TabIndex = 2;
            // 
            // CreateCharacterForm
            // 
            this.AcceptButton = this.mBtnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.mBtnCancel;
            this.ClientSize = new System.Drawing.Size(261, 222);
            this.ControlBox = false;
            this.Controls.Add(this.mGbxAttributes);
            this.Controls.Add(this.mTbxName);
            this.Controls.Add(this.mLblName);
            this.Controls.Add(this.mBtnSave);
            this.Controls.Add(this.mBtnReroll);
            this.Controls.Add(this.mBtnCancel);
            this.Name = "CreateCharacterForm";
            this.Text = "Create Your Character";
            this.mGbxAttributes.ResumeLayout(false);
            this.mGbxAttributes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button mBtnCancel;
        private System.Windows.Forms.Button mBtnReroll;
        private System.Windows.Forms.Button mBtnSave;
        private System.Windows.Forms.Label mLblName;
        private System.Windows.Forms.TextBox mTbxName;
        private System.Windows.Forms.GroupBox mGbxAttributes;
        private System.Windows.Forms.Label mLblCharisma;
        private System.Windows.Forms.TextBox mTbxCharisma;
        private System.Windows.Forms.Label mLblHardiness;
        private System.Windows.Forms.TextBox mTbxHardiness;
        private System.Windows.Forms.Label mLblAgility;
        private System.Windows.Forms.TextBox mTbxAgility;
    }
}
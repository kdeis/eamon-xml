namespace Adventure.MainHall
{
    partial class ViewCharacterForm
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
            this.components = new System.ComponentModel.Container();
            this.mLblName = new System.Windows.Forms.Label();
            this.mTbxName = new System.Windows.Forms.TextBox();
            this.mGbxAttributes = new System.Windows.Forms.GroupBox();
            this.mLblCharisma = new System.Windows.Forms.Label();
            this.mTbxCharisma = new System.Windows.Forms.TextBox();
            this.mLblHardiness = new System.Windows.Forms.Label();
            this.mTbxHardiness = new System.Windows.Forms.TextBox();
            this.mLblAgility = new System.Windows.Forms.Label();
            this.mTbxAgility = new System.Windows.Forms.TextBox();
            this.mGbxWeapSkills = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mTbxArmorExpertise = new System.Windows.Forms.TextBox();
            this.mLblSword = new System.Windows.Forms.Label();
            this.mTbxSword = new System.Windows.Forms.TextBox();
            this.mLblSpear = new System.Windows.Forms.Label();
            this.mTbxSpear = new System.Windows.Forms.TextBox();
            this.mLblMace = new System.Windows.Forms.Label();
            this.mTbxMace = new System.Windows.Forms.TextBox();
            this.mLblBow = new System.Windows.Forms.Label();
            this.mTbxBow = new System.Windows.Forms.TextBox();
            this.mLblAxe = new System.Windows.Forms.Label();
            this.mTbxAxe = new System.Windows.Forms.TextBox();
            this.mGbxSpellSkills = new System.Windows.Forms.GroupBox();
            this.mTbxSpeed = new System.Windows.Forms.TextBox();
            this.mTbxPower = new System.Windows.Forms.TextBox();
            this.mLblSpeed = new System.Windows.Forms.Label();
            this.mLblPower = new System.Windows.Forms.Label();
            this.mLblBlast = new System.Windows.Forms.Label();
            this.mTbxBlast = new System.Windows.Forms.TextBox();
            this.mLblHeal = new System.Windows.Forms.Label();
            this.mTbxHeal = new System.Windows.Forms.TextBox();
            this.mLblGold = new System.Windows.Forms.Label();
            this.mTbxGold = new System.Windows.Forms.TextBox();
            this.mLblGoldInBank = new System.Windows.Forms.Label();
            this.mTbxGoldInBank = new System.Windows.Forms.TextBox();
            this.mGbxWeapons = new System.Windows.Forms.GroupBox();
            this.mDgvWeaponsGrid = new System.Windows.Forms.DataGridView();
            this.weapBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.weaponDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.viewCharacterFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mGbxAttributes.SuspendLayout();
            this.mGbxWeapSkills.SuspendLayout();
            this.mGbxSpellSkills.SuspendLayout();
            this.mGbxWeapons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mDgvWeaponsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weapBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewCharacterFormBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // mLblName
            // 
            this.mLblName.AutoSize = true;
            this.mLblName.Location = new System.Drawing.Point(12, 9);
            this.mLblName.Name = "mLblName";
            this.mLblName.Size = new System.Drawing.Size(38, 13);
            this.mLblName.TabIndex = 0;
            this.mLblName.Text = "Name:";
            // 
            // mTbxName
            // 
            this.mTbxName.Location = new System.Drawing.Point(56, 6);
            this.mTbxName.Name = "mTbxName";
            this.mTbxName.ReadOnly = true;
            this.mTbxName.Size = new System.Drawing.Size(100, 20);
            this.mTbxName.TabIndex = 1;
            // 
            // mGbxAttributes
            // 
            this.mGbxAttributes.Controls.Add(this.mLblCharisma);
            this.mGbxAttributes.Controls.Add(this.mTbxCharisma);
            this.mGbxAttributes.Controls.Add(this.mLblHardiness);
            this.mGbxAttributes.Controls.Add(this.mTbxHardiness);
            this.mGbxAttributes.Controls.Add(this.mLblAgility);
            this.mGbxAttributes.Controls.Add(this.mTbxAgility);
            this.mGbxAttributes.Location = new System.Drawing.Point(15, 32);
            this.mGbxAttributes.Name = "mGbxAttributes";
            this.mGbxAttributes.Size = new System.Drawing.Size(200, 102);
            this.mGbxAttributes.TabIndex = 2;
            this.mGbxAttributes.TabStop = false;
            this.mGbxAttributes.Text = "Attributes";
            // 
            // mLblCharisma
            // 
            this.mLblCharisma.AutoSize = true;
            this.mLblCharisma.Location = new System.Drawing.Point(19, 71);
            this.mLblCharisma.Name = "mLblCharisma";
            this.mLblCharisma.Size = new System.Drawing.Size(53, 13);
            this.mLblCharisma.TabIndex = 13;
            this.mLblCharisma.Text = "Charisma:";
            // 
            // mTbxCharisma
            // 
            this.mTbxCharisma.Location = new System.Drawing.Point(81, 68);
            this.mTbxCharisma.Name = "mTbxCharisma";
            this.mTbxCharisma.ReadOnly = true;
            this.mTbxCharisma.Size = new System.Drawing.Size(100, 20);
            this.mTbxCharisma.TabIndex = 12;
            // 
            // mLblHardiness
            // 
            this.mLblHardiness.AutoSize = true;
            this.mLblHardiness.Location = new System.Drawing.Point(19, 44);
            this.mLblHardiness.Name = "mLblHardiness";
            this.mLblHardiness.Size = new System.Drawing.Size(57, 13);
            this.mLblHardiness.TabIndex = 11;
            this.mLblHardiness.Text = "Hardiness:";
            // 
            // mTbxHardiness
            // 
            this.mTbxHardiness.Location = new System.Drawing.Point(81, 41);
            this.mTbxHardiness.Name = "mTbxHardiness";
            this.mTbxHardiness.ReadOnly = true;
            this.mTbxHardiness.Size = new System.Drawing.Size(100, 20);
            this.mTbxHardiness.TabIndex = 10;
            // 
            // mLblAgility
            // 
            this.mLblAgility.AutoSize = true;
            this.mLblAgility.Location = new System.Drawing.Point(19, 17);
            this.mLblAgility.Name = "mLblAgility";
            this.mLblAgility.Size = new System.Drawing.Size(37, 13);
            this.mLblAgility.TabIndex = 9;
            this.mLblAgility.Text = "Agility:";
            // 
            // mTbxAgility
            // 
            this.mTbxAgility.Location = new System.Drawing.Point(81, 14);
            this.mTbxAgility.Name = "mTbxAgility";
            this.mTbxAgility.ReadOnly = true;
            this.mTbxAgility.Size = new System.Drawing.Size(100, 20);
            this.mTbxAgility.TabIndex = 8;
            // 
            // mGbxWeapSkills
            // 
            this.mGbxWeapSkills.Controls.Add(this.label1);
            this.mGbxWeapSkills.Controls.Add(this.mTbxArmorExpertise);
            this.mGbxWeapSkills.Controls.Add(this.mLblSword);
            this.mGbxWeapSkills.Controls.Add(this.mTbxSword);
            this.mGbxWeapSkills.Controls.Add(this.mLblSpear);
            this.mGbxWeapSkills.Controls.Add(this.mTbxSpear);
            this.mGbxWeapSkills.Controls.Add(this.mLblMace);
            this.mGbxWeapSkills.Controls.Add(this.mTbxMace);
            this.mGbxWeapSkills.Controls.Add(this.mLblBow);
            this.mGbxWeapSkills.Controls.Add(this.mTbxBow);
            this.mGbxWeapSkills.Controls.Add(this.mLblAxe);
            this.mGbxWeapSkills.Controls.Add(this.mTbxAxe);
            this.mGbxWeapSkills.Location = new System.Drawing.Point(246, 32);
            this.mGbxWeapSkills.Name = "mGbxWeapSkills";
            this.mGbxWeapSkills.Size = new System.Drawing.Size(350, 102);
            this.mGbxWeapSkills.TabIndex = 3;
            this.mGbxWeapSkills.TabStop = false;
            this.mGbxWeapSkills.Text = "Weapon Skills";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Armor Expertise:";
            // 
            // mTbxArmorExpertise
            // 
            this.mTbxArmorExpertise.Location = new System.Drawing.Point(210, 68);
            this.mTbxArmorExpertise.Name = "mTbxArmorExpertise";
            this.mTbxArmorExpertise.ReadOnly = true;
            this.mTbxArmorExpertise.Size = new System.Drawing.Size(100, 20);
            this.mTbxArmorExpertise.TabIndex = 18;
            // 
            // mLblSword
            // 
            this.mLblSword.AutoSize = true;
            this.mLblSword.Location = new System.Drawing.Point(126, 44);
            this.mLblSword.Name = "mLblSword";
            this.mLblSword.Size = new System.Drawing.Size(40, 13);
            this.mLblSword.TabIndex = 17;
            this.mLblSword.Text = "Sword:";
            // 
            // mTbxSword
            // 
            this.mTbxSword.Location = new System.Drawing.Point(210, 41);
            this.mTbxSword.Name = "mTbxSword";
            this.mTbxSword.ReadOnly = true;
            this.mTbxSword.Size = new System.Drawing.Size(100, 20);
            this.mTbxSword.TabIndex = 16;
            // 
            // mLblSpear
            // 
            this.mLblSpear.AutoSize = true;
            this.mLblSpear.Location = new System.Drawing.Point(126, 17);
            this.mLblSpear.Name = "mLblSpear";
            this.mLblSpear.Size = new System.Drawing.Size(38, 13);
            this.mLblSpear.TabIndex = 15;
            this.mLblSpear.Text = "Spear:";
            // 
            // mTbxSpear
            // 
            this.mTbxSpear.Location = new System.Drawing.Point(210, 14);
            this.mTbxSpear.Name = "mTbxSpear";
            this.mTbxSpear.ReadOnly = true;
            this.mTbxSpear.Size = new System.Drawing.Size(100, 20);
            this.mTbxSpear.TabIndex = 14;
            // 
            // mLblMace
            // 
            this.mLblMace.AutoSize = true;
            this.mLblMace.Location = new System.Drawing.Point(19, 71);
            this.mLblMace.Name = "mLblMace";
            this.mLblMace.Size = new System.Drawing.Size(37, 13);
            this.mLblMace.TabIndex = 13;
            this.mLblMace.Text = "Mace:";
            // 
            // mTbxMace
            // 
            this.mTbxMace.Location = new System.Drawing.Point(56, 68);
            this.mTbxMace.Name = "mTbxMace";
            this.mTbxMace.ReadOnly = true;
            this.mTbxMace.Size = new System.Drawing.Size(41, 20);
            this.mTbxMace.TabIndex = 12;
            // 
            // mLblBow
            // 
            this.mLblBow.AutoSize = true;
            this.mLblBow.Location = new System.Drawing.Point(19, 44);
            this.mLblBow.Name = "mLblBow";
            this.mLblBow.Size = new System.Drawing.Size(31, 13);
            this.mLblBow.TabIndex = 11;
            this.mLblBow.Text = "Bow:";
            // 
            // mTbxBow
            // 
            this.mTbxBow.Location = new System.Drawing.Point(56, 41);
            this.mTbxBow.Name = "mTbxBow";
            this.mTbxBow.ReadOnly = true;
            this.mTbxBow.Size = new System.Drawing.Size(41, 20);
            this.mTbxBow.TabIndex = 10;
            // 
            // mLblAxe
            // 
            this.mLblAxe.AutoSize = true;
            this.mLblAxe.Location = new System.Drawing.Point(19, 17);
            this.mLblAxe.Name = "mLblAxe";
            this.mLblAxe.Size = new System.Drawing.Size(28, 13);
            this.mLblAxe.TabIndex = 9;
            this.mLblAxe.Text = "Axe:";
            // 
            // mTbxAxe
            // 
            this.mTbxAxe.Location = new System.Drawing.Point(56, 14);
            this.mTbxAxe.Name = "mTbxAxe";
            this.mTbxAxe.ReadOnly = true;
            this.mTbxAxe.Size = new System.Drawing.Size(41, 20);
            this.mTbxAxe.TabIndex = 8;
            // 
            // mGbxSpellSkills
            // 
            this.mGbxSpellSkills.Controls.Add(this.mTbxSpeed);
            this.mGbxSpellSkills.Controls.Add(this.mTbxPower);
            this.mGbxSpellSkills.Controls.Add(this.mLblSpeed);
            this.mGbxSpellSkills.Controls.Add(this.mLblPower);
            this.mGbxSpellSkills.Controls.Add(this.mLblBlast);
            this.mGbxSpellSkills.Controls.Add(this.mTbxBlast);
            this.mGbxSpellSkills.Controls.Add(this.mLblHeal);
            this.mGbxSpellSkills.Controls.Add(this.mTbxHeal);
            this.mGbxSpellSkills.Location = new System.Drawing.Point(15, 140);
            this.mGbxSpellSkills.Name = "mGbxSpellSkills";
            this.mGbxSpellSkills.Size = new System.Drawing.Size(200, 73);
            this.mGbxSpellSkills.TabIndex = 4;
            this.mGbxSpellSkills.TabStop = false;
            this.mGbxSpellSkills.Text = "Spell Skills";
            // 
            // mTbxSpeed
            // 
            this.mTbxSpeed.Location = new System.Drawing.Point(149, 41);
            this.mTbxSpeed.Name = "mTbxSpeed";
            this.mTbxSpeed.ReadOnly = true;
            this.mTbxSpeed.Size = new System.Drawing.Size(41, 20);
            this.mTbxSpeed.TabIndex = 19;
            // 
            // mTbxPower
            // 
            this.mTbxPower.Location = new System.Drawing.Point(149, 14);
            this.mTbxPower.Name = "mTbxPower";
            this.mTbxPower.ReadOnly = true;
            this.mTbxPower.Size = new System.Drawing.Size(41, 20);
            this.mTbxPower.TabIndex = 18;
            // 
            // mLblSpeed
            // 
            this.mLblSpeed.AutoSize = true;
            this.mLblSpeed.Location = new System.Drawing.Point(103, 44);
            this.mLblSpeed.Name = "mLblSpeed";
            this.mLblSpeed.Size = new System.Drawing.Size(41, 13);
            this.mLblSpeed.TabIndex = 17;
            this.mLblSpeed.Text = "Speed:";
            // 
            // mLblPower
            // 
            this.mLblPower.AutoSize = true;
            this.mLblPower.Location = new System.Drawing.Point(103, 17);
            this.mLblPower.Name = "mLblPower";
            this.mLblPower.Size = new System.Drawing.Size(40, 13);
            this.mLblPower.TabIndex = 15;
            this.mLblPower.Text = "Power:";
            // 
            // mLblBlast
            // 
            this.mLblBlast.AutoSize = true;
            this.mLblBlast.Location = new System.Drawing.Point(19, 44);
            this.mLblBlast.Name = "mLblBlast";
            this.mLblBlast.Size = new System.Drawing.Size(33, 13);
            this.mLblBlast.TabIndex = 11;
            this.mLblBlast.Text = "Blast:";
            // 
            // mTbxBlast
            // 
            this.mTbxBlast.Location = new System.Drawing.Point(56, 41);
            this.mTbxBlast.Name = "mTbxBlast";
            this.mTbxBlast.ReadOnly = true;
            this.mTbxBlast.Size = new System.Drawing.Size(41, 20);
            this.mTbxBlast.TabIndex = 10;
            // 
            // mLblHeal
            // 
            this.mLblHeal.AutoSize = true;
            this.mLblHeal.Location = new System.Drawing.Point(19, 17);
            this.mLblHeal.Name = "mLblHeal";
            this.mLblHeal.Size = new System.Drawing.Size(32, 13);
            this.mLblHeal.TabIndex = 9;
            this.mLblHeal.Text = "Heal:";
            // 
            // mTbxHeal
            // 
            this.mTbxHeal.Location = new System.Drawing.Point(56, 14);
            this.mTbxHeal.Name = "mTbxHeal";
            this.mTbxHeal.ReadOnly = true;
            this.mTbxHeal.Size = new System.Drawing.Size(41, 20);
            this.mTbxHeal.TabIndex = 8;
            // 
            // mLblGold
            // 
            this.mLblGold.AutoSize = true;
            this.mLblGold.Location = new System.Drawing.Point(200, 9);
            this.mLblGold.Name = "mLblGold";
            this.mLblGold.Size = new System.Drawing.Size(32, 13);
            this.mLblGold.TabIndex = 11;
            this.mLblGold.Text = "Gold:";
            // 
            // mTbxGold
            // 
            this.mTbxGold.Location = new System.Drawing.Point(237, 6);
            this.mTbxGold.Name = "mTbxGold";
            this.mTbxGold.ReadOnly = true;
            this.mTbxGold.Size = new System.Drawing.Size(65, 20);
            this.mTbxGold.TabIndex = 10;
            // 
            // mLblGoldInBank
            // 
            this.mLblGoldInBank.AutoSize = true;
            this.mLblGoldInBank.Location = new System.Drawing.Point(329, 9);
            this.mLblGoldInBank.Name = "mLblGoldInBank";
            this.mLblGoldInBank.Size = new System.Drawing.Size(71, 13);
            this.mLblGoldInBank.TabIndex = 13;
            this.mLblGoldInBank.Text = "Gold in Bank:";
            // 
            // mTbxGoldInBank
            // 
            this.mTbxGoldInBank.Location = new System.Drawing.Point(406, 6);
            this.mTbxGoldInBank.Name = "mTbxGoldInBank";
            this.mTbxGoldInBank.ReadOnly = true;
            this.mTbxGoldInBank.Size = new System.Drawing.Size(98, 20);
            this.mTbxGoldInBank.TabIndex = 12;
            // 
            // mGbxWeapons
            // 
            this.mGbxWeapons.Controls.Add(this.mDgvWeaponsGrid);
            this.mGbxWeapons.Location = new System.Drawing.Point(15, 219);
            this.mGbxWeapons.Name = "mGbxWeapons";
            this.mGbxWeapons.Size = new System.Drawing.Size(573, 100);
            this.mGbxWeapons.TabIndex = 14;
            this.mGbxWeapons.TabStop = false;
            this.mGbxWeapons.Text = "Weapons";
            // 
            // mDgvWeaponsGrid
            // 
            this.mDgvWeaponsGrid.AllowUserToAddRows = false;
            this.mDgvWeaponsGrid.AllowUserToDeleteRows = false;
            this.mDgvWeaponsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mDgvWeaponsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mDgvWeaponsGrid.Location = new System.Drawing.Point(6, 19);
            this.mDgvWeaponsGrid.Name = "mDgvWeaponsGrid";
            this.mDgvWeaponsGrid.ReadOnly = true;
            this.mDgvWeaponsGrid.Size = new System.Drawing.Size(561, 75);
            this.mDgvWeaponsGrid.TabIndex = 0;
            // 
            // weaponDataBindingSource
            // 
            this.weaponDataBindingSource.DataSource = typeof(weaponData);
            // 
            // viewCharacterFormBindingSource
            // 
            this.viewCharacterFormBindingSource.DataSource = typeof(Adventure.MainHall.ViewCharacterForm);
            // 
            // ViewCharacterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.mGbxWeapons);
            this.Controls.Add(this.mLblGoldInBank);
            this.Controls.Add(this.mTbxGoldInBank);
            this.Controls.Add(this.mLblGold);
            this.Controls.Add(this.mTbxGold);
            this.Controls.Add(this.mGbxSpellSkills);
            this.Controls.Add(this.mGbxWeapSkills);
            this.Controls.Add(this.mGbxAttributes);
            this.Controls.Add(this.mTbxName);
            this.Controls.Add(this.mLblName);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ViewCharacterForm";
            this.Text = "ViewCharacterForm";
            this.Load += new System.EventHandler(this.ViewCharacterForm_Load);
            this.mGbxAttributes.ResumeLayout(false);
            this.mGbxAttributes.PerformLayout();
            this.mGbxWeapSkills.ResumeLayout(false);
            this.mGbxWeapSkills.PerformLayout();
            this.mGbxSpellSkills.ResumeLayout(false);
            this.mGbxSpellSkills.PerformLayout();
            this.mGbxWeapons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mDgvWeaponsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weapBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewCharacterFormBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mLblName;
        private System.Windows.Forms.TextBox mTbxName;
        private System.Windows.Forms.GroupBox mGbxAttributes;
        private System.Windows.Forms.Label mLblCharisma;
        private System.Windows.Forms.TextBox mTbxCharisma;
        private System.Windows.Forms.Label mLblHardiness;
        private System.Windows.Forms.TextBox mTbxHardiness;
        private System.Windows.Forms.Label mLblAgility;
        private System.Windows.Forms.TextBox mTbxAgility;
        private System.Windows.Forms.GroupBox mGbxWeapSkills;
        private System.Windows.Forms.Label mLblMace;
        private System.Windows.Forms.TextBox mTbxMace;
        private System.Windows.Forms.Label mLblBow;
        private System.Windows.Forms.TextBox mTbxBow;
        private System.Windows.Forms.Label mLblAxe;
        private System.Windows.Forms.TextBox mTbxAxe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox mTbxArmorExpertise;
        private System.Windows.Forms.Label mLblSword;
        private System.Windows.Forms.TextBox mTbxSword;
        private System.Windows.Forms.Label mLblSpear;
        private System.Windows.Forms.TextBox mTbxSpear;
        private System.Windows.Forms.GroupBox mGbxSpellSkills;
        private System.Windows.Forms.Label mLblSpeed;
        private System.Windows.Forms.Label mLblPower;
        private System.Windows.Forms.Label mLblBlast;
        private System.Windows.Forms.TextBox mTbxBlast;
        private System.Windows.Forms.Label mLblHeal;
        private System.Windows.Forms.TextBox mTbxHeal;
        private System.Windows.Forms.TextBox mTbxSpeed;
        private System.Windows.Forms.TextBox mTbxPower;
        private System.Windows.Forms.Label mLblGold;
        private System.Windows.Forms.TextBox mTbxGold;
        private System.Windows.Forms.Label mLblGoldInBank;
        private System.Windows.Forms.TextBox mTbxGoldInBank;
        private System.Windows.Forms.GroupBox mGbxWeapons;
        private System.Windows.Forms.BindingSource weaponDataBindingSource;
        private System.Windows.Forms.BindingSource viewCharacterFormBindingSource;
        private System.Windows.Forms.BindingSource weapBindingSource;
        private System.Windows.Forms.DataGridView mDgvWeaponsGrid;
    }
}
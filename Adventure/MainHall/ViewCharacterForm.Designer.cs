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
            this.mLblName.Location = new System.Drawing.Point(16, 11);
            this.mLblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mLblName.Name = "mLblName";
            this.mLblName.Size = new System.Drawing.Size(47, 16);
            this.mLblName.TabIndex = 0;
            this.mLblName.Text = "Name:";
            // 
            // mTbxName
            // 
            this.mTbxName.Location = new System.Drawing.Point(75, 7);
            this.mTbxName.Margin = new System.Windows.Forms.Padding(4);
            this.mTbxName.Name = "mTbxName";
            this.mTbxName.ReadOnly = true;
            this.mTbxName.Size = new System.Drawing.Size(132, 22);
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
            this.mGbxAttributes.Location = new System.Drawing.Point(20, 39);
            this.mGbxAttributes.Margin = new System.Windows.Forms.Padding(4);
            this.mGbxAttributes.Name = "mGbxAttributes";
            this.mGbxAttributes.Padding = new System.Windows.Forms.Padding(4);
            this.mGbxAttributes.Size = new System.Drawing.Size(267, 126);
            this.mGbxAttributes.TabIndex = 2;
            this.mGbxAttributes.TabStop = false;
            this.mGbxAttributes.Text = "Attributes";
            // 
            // mLblCharisma
            // 
            this.mLblCharisma.AutoSize = true;
            this.mLblCharisma.Location = new System.Drawing.Point(25, 87);
            this.mLblCharisma.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mLblCharisma.Name = "mLblCharisma";
            this.mLblCharisma.Size = new System.Drawing.Size(67, 16);
            this.mLblCharisma.TabIndex = 13;
            this.mLblCharisma.Text = "Charisma:";
            // 
            // mTbxCharisma
            // 
            this.mTbxCharisma.Location = new System.Drawing.Point(108, 84);
            this.mTbxCharisma.Margin = new System.Windows.Forms.Padding(4);
            this.mTbxCharisma.Name = "mTbxCharisma";
            this.mTbxCharisma.ReadOnly = true;
            this.mTbxCharisma.Size = new System.Drawing.Size(132, 22);
            this.mTbxCharisma.TabIndex = 12;
            // 
            // mLblHardiness
            // 
            this.mLblHardiness.AutoSize = true;
            this.mLblHardiness.Location = new System.Drawing.Point(25, 54);
            this.mLblHardiness.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mLblHardiness.Name = "mLblHardiness";
            this.mLblHardiness.Size = new System.Drawing.Size(72, 16);
            this.mLblHardiness.TabIndex = 11;
            this.mLblHardiness.Text = "Hardiness:";
            // 
            // mTbxHardiness
            // 
            this.mTbxHardiness.Location = new System.Drawing.Point(108, 50);
            this.mTbxHardiness.Margin = new System.Windows.Forms.Padding(4);
            this.mTbxHardiness.Name = "mTbxHardiness";
            this.mTbxHardiness.ReadOnly = true;
            this.mTbxHardiness.Size = new System.Drawing.Size(132, 22);
            this.mTbxHardiness.TabIndex = 10;
            // 
            // mLblAgility
            // 
            this.mLblAgility.AutoSize = true;
            this.mLblAgility.Location = new System.Drawing.Point(25, 21);
            this.mLblAgility.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mLblAgility.Name = "mLblAgility";
            this.mLblAgility.Size = new System.Drawing.Size(46, 16);
            this.mLblAgility.TabIndex = 9;
            this.mLblAgility.Text = "Agility:";
            // 
            // mTbxAgility
            // 
            this.mTbxAgility.Location = new System.Drawing.Point(108, 17);
            this.mTbxAgility.Margin = new System.Windows.Forms.Padding(4);
            this.mTbxAgility.Name = "mTbxAgility";
            this.mTbxAgility.ReadOnly = true;
            this.mTbxAgility.Size = new System.Drawing.Size(132, 22);
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
            this.mGbxWeapSkills.Location = new System.Drawing.Point(328, 39);
            this.mGbxWeapSkills.Margin = new System.Windows.Forms.Padding(4);
            this.mGbxWeapSkills.Name = "mGbxWeapSkills";
            this.mGbxWeapSkills.Padding = new System.Windows.Forms.Padding(4);
            this.mGbxWeapSkills.Size = new System.Drawing.Size(467, 126);
            this.mGbxWeapSkills.TabIndex = 3;
            this.mGbxWeapSkills.TabStop = false;
            this.mGbxWeapSkills.Text = "Weapon Skills";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 87);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "Armor Expertise:";
            // 
            // mTbxArmorExpertise
            // 
            this.mTbxArmorExpertise.Location = new System.Drawing.Point(280, 84);
            this.mTbxArmorExpertise.Margin = new System.Windows.Forms.Padding(4);
            this.mTbxArmorExpertise.Name = "mTbxArmorExpertise";
            this.mTbxArmorExpertise.ReadOnly = true;
            this.mTbxArmorExpertise.Size = new System.Drawing.Size(132, 22);
            this.mTbxArmorExpertise.TabIndex = 18;
            // 
            // mLblSword
            // 
            this.mLblSword.AutoSize = true;
            this.mLblSword.Location = new System.Drawing.Point(168, 54);
            this.mLblSword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mLblSword.Name = "mLblSword";
            this.mLblSword.Size = new System.Drawing.Size(48, 16);
            this.mLblSword.TabIndex = 17;
            this.mLblSword.Text = "Sword:";
            // 
            // mTbxSword
            // 
            this.mTbxSword.Location = new System.Drawing.Point(280, 50);
            this.mTbxSword.Margin = new System.Windows.Forms.Padding(4);
            this.mTbxSword.Name = "mTbxSword";
            this.mTbxSword.ReadOnly = true;
            this.mTbxSword.Size = new System.Drawing.Size(132, 22);
            this.mTbxSword.TabIndex = 16;
            // 
            // mLblSpear
            // 
            this.mLblSpear.AutoSize = true;
            this.mLblSpear.Location = new System.Drawing.Point(168, 21);
            this.mLblSpear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mLblSpear.Name = "mLblSpear";
            this.mLblSpear.Size = new System.Drawing.Size(47, 16);
            this.mLblSpear.TabIndex = 15;
            this.mLblSpear.Text = "Spear:";
            // 
            // mTbxSpear
            // 
            this.mTbxSpear.Location = new System.Drawing.Point(280, 17);
            this.mTbxSpear.Margin = new System.Windows.Forms.Padding(4);
            this.mTbxSpear.Name = "mTbxSpear";
            this.mTbxSpear.ReadOnly = true;
            this.mTbxSpear.Size = new System.Drawing.Size(132, 22);
            this.mTbxSpear.TabIndex = 14;
            // 
            // mLblMace
            // 
            this.mLblMace.AutoSize = true;
            this.mLblMace.Location = new System.Drawing.Point(25, 87);
            this.mLblMace.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mLblMace.Name = "mLblMace";
            this.mLblMace.Size = new System.Drawing.Size(44, 16);
            this.mLblMace.TabIndex = 13;
            this.mLblMace.Text = "Mace:";
            // 
            // mTbxMace
            // 
            this.mTbxMace.Location = new System.Drawing.Point(75, 84);
            this.mTbxMace.Margin = new System.Windows.Forms.Padding(4);
            this.mTbxMace.Name = "mTbxMace";
            this.mTbxMace.ReadOnly = true;
            this.mTbxMace.Size = new System.Drawing.Size(53, 22);
            this.mTbxMace.TabIndex = 12;
            // 
            // mLblBow
            // 
            this.mLblBow.AutoSize = true;
            this.mLblBow.Location = new System.Drawing.Point(25, 54);
            this.mLblBow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mLblBow.Name = "mLblBow";
            this.mLblBow.Size = new System.Drawing.Size(36, 16);
            this.mLblBow.TabIndex = 11;
            this.mLblBow.Text = "Bow:";
            // 
            // mTbxBow
            // 
            this.mTbxBow.Location = new System.Drawing.Point(75, 50);
            this.mTbxBow.Margin = new System.Windows.Forms.Padding(4);
            this.mTbxBow.Name = "mTbxBow";
            this.mTbxBow.ReadOnly = true;
            this.mTbxBow.Size = new System.Drawing.Size(53, 22);
            this.mTbxBow.TabIndex = 10;
            // 
            // mLblAxe
            // 
            this.mLblAxe.AutoSize = true;
            this.mLblAxe.Location = new System.Drawing.Point(25, 21);
            this.mLblAxe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mLblAxe.Name = "mLblAxe";
            this.mLblAxe.Size = new System.Drawing.Size(33, 16);
            this.mLblAxe.TabIndex = 9;
            this.mLblAxe.Text = "Axe:";
            // 
            // mTbxAxe
            // 
            this.mTbxAxe.Location = new System.Drawing.Point(75, 17);
            this.mTbxAxe.Margin = new System.Windows.Forms.Padding(4);
            this.mTbxAxe.Name = "mTbxAxe";
            this.mTbxAxe.ReadOnly = true;
            this.mTbxAxe.Size = new System.Drawing.Size(53, 22);
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
            this.mGbxSpellSkills.Location = new System.Drawing.Point(20, 172);
            this.mGbxSpellSkills.Margin = new System.Windows.Forms.Padding(4);
            this.mGbxSpellSkills.Name = "mGbxSpellSkills";
            this.mGbxSpellSkills.Padding = new System.Windows.Forms.Padding(4);
            this.mGbxSpellSkills.Size = new System.Drawing.Size(267, 90);
            this.mGbxSpellSkills.TabIndex = 4;
            this.mGbxSpellSkills.TabStop = false;
            this.mGbxSpellSkills.Text = "Spell Skills";
            // 
            // mTbxSpeed
            // 
            this.mTbxSpeed.Location = new System.Drawing.Point(199, 50);
            this.mTbxSpeed.Margin = new System.Windows.Forms.Padding(4);
            this.mTbxSpeed.Name = "mTbxSpeed";
            this.mTbxSpeed.ReadOnly = true;
            this.mTbxSpeed.Size = new System.Drawing.Size(53, 22);
            this.mTbxSpeed.TabIndex = 19;
            // 
            // mTbxPower
            // 
            this.mTbxPower.Location = new System.Drawing.Point(199, 17);
            this.mTbxPower.Margin = new System.Windows.Forms.Padding(4);
            this.mTbxPower.Name = "mTbxPower";
            this.mTbxPower.ReadOnly = true;
            this.mTbxPower.Size = new System.Drawing.Size(53, 22);
            this.mTbxPower.TabIndex = 18;
            // 
            // mLblSpeed
            // 
            this.mLblSpeed.AutoSize = true;
            this.mLblSpeed.Location = new System.Drawing.Point(137, 54);
            this.mLblSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mLblSpeed.Name = "mLblSpeed";
            this.mLblSpeed.Size = new System.Drawing.Size(51, 16);
            this.mLblSpeed.TabIndex = 17;
            this.mLblSpeed.Text = "Speed:";
            // 
            // mLblPower
            // 
            this.mLblPower.AutoSize = true;
            this.mLblPower.Location = new System.Drawing.Point(137, 21);
            this.mLblPower.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mLblPower.Name = "mLblPower";
            this.mLblPower.Size = new System.Drawing.Size(48, 16);
            this.mLblPower.TabIndex = 15;
            this.mLblPower.Text = "Power:";
            // 
            // mLblBlast
            // 
            this.mLblBlast.AutoSize = true;
            this.mLblBlast.Location = new System.Drawing.Point(25, 54);
            this.mLblBlast.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mLblBlast.Name = "mLblBlast";
            this.mLblBlast.Size = new System.Drawing.Size(40, 16);
            this.mLblBlast.TabIndex = 11;
            this.mLblBlast.Text = "Blast:";
            // 
            // mTbxBlast
            // 
            this.mTbxBlast.Location = new System.Drawing.Point(75, 50);
            this.mTbxBlast.Margin = new System.Windows.Forms.Padding(4);
            this.mTbxBlast.Name = "mTbxBlast";
            this.mTbxBlast.ReadOnly = true;
            this.mTbxBlast.Size = new System.Drawing.Size(53, 22);
            this.mTbxBlast.TabIndex = 10;
            // 
            // mLblHeal
            // 
            this.mLblHeal.AutoSize = true;
            this.mLblHeal.Location = new System.Drawing.Point(25, 21);
            this.mLblHeal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mLblHeal.Name = "mLblHeal";
            this.mLblHeal.Size = new System.Drawing.Size(39, 16);
            this.mLblHeal.TabIndex = 9;
            this.mLblHeal.Text = "Heal:";
            // 
            // mTbxHeal
            // 
            this.mTbxHeal.Location = new System.Drawing.Point(75, 17);
            this.mTbxHeal.Margin = new System.Windows.Forms.Padding(4);
            this.mTbxHeal.Name = "mTbxHeal";
            this.mTbxHeal.ReadOnly = true;
            this.mTbxHeal.Size = new System.Drawing.Size(53, 22);
            this.mTbxHeal.TabIndex = 8;
            // 
            // mLblGold
            // 
            this.mLblGold.AutoSize = true;
            this.mLblGold.Location = new System.Drawing.Point(267, 11);
            this.mLblGold.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mLblGold.Name = "mLblGold";
            this.mLblGold.Size = new System.Drawing.Size(39, 16);
            this.mLblGold.TabIndex = 11;
            this.mLblGold.Text = "Gold:";
            // 
            // mTbxGold
            // 
            this.mTbxGold.Location = new System.Drawing.Point(316, 7);
            this.mTbxGold.Margin = new System.Windows.Forms.Padding(4);
            this.mTbxGold.Name = "mTbxGold";
            this.mTbxGold.ReadOnly = true;
            this.mTbxGold.Size = new System.Drawing.Size(85, 22);
            this.mTbxGold.TabIndex = 10;
            // 
            // mLblGoldInBank
            // 
            this.mLblGoldInBank.AutoSize = true;
            this.mLblGoldInBank.Location = new System.Drawing.Point(439, 11);
            this.mLblGoldInBank.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mLblGoldInBank.Name = "mLblGoldInBank";
            this.mLblGoldInBank.Size = new System.Drawing.Size(86, 16);
            this.mLblGoldInBank.TabIndex = 13;
            this.mLblGoldInBank.Text = "Gold in Bank:";
            // 
            // mTbxGoldInBank
            // 
            this.mTbxGoldInBank.Location = new System.Drawing.Point(541, 7);
            this.mTbxGoldInBank.Margin = new System.Windows.Forms.Padding(4);
            this.mTbxGoldInBank.Name = "mTbxGoldInBank";
            this.mTbxGoldInBank.ReadOnly = true;
            this.mTbxGoldInBank.Size = new System.Drawing.Size(129, 22);
            this.mTbxGoldInBank.TabIndex = 12;
            // 
            // mGbxWeapons
            // 
            this.mGbxWeapons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mGbxWeapons.Controls.Add(this.mDgvWeaponsGrid);
            this.mGbxWeapons.Location = new System.Drawing.Point(20, 270);
            this.mGbxWeapons.Margin = new System.Windows.Forms.Padding(4);
            this.mGbxWeapons.Name = "mGbxWeapons";
            this.mGbxWeapons.Padding = new System.Windows.Forms.Padding(4);
            this.mGbxWeapons.Size = new System.Drawing.Size(764, 151);
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
            this.mDgvWeaponsGrid.Location = new System.Drawing.Point(8, 23);
            this.mDgvWeaponsGrid.Margin = new System.Windows.Forms.Padding(4);
            this.mDgvWeaponsGrid.Name = "mDgvWeaponsGrid";
            this.mDgvWeaponsGrid.ReadOnly = true;
            this.mDgvWeaponsGrid.RowHeadersWidth = 51;
            this.mDgvWeaponsGrid.Size = new System.Drawing.Size(748, 120);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 488);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
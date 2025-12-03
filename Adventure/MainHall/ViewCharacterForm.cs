using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adventure.MainHall
{
    public partial class ViewCharacterForm : Form
    {
        private Character character;
        private Button mBtnOk;

        public ViewCharacterForm(Character currentChar)
        {
            InitializeComponent();
            character = currentChar;
            InitializeButtons();
        }

        private void InitializeButtons()
        {
            mBtnOk = new Button();

            mBtnOk.Text = "OK";

            Size btnSize = new Size(80, 30);
            mBtnOk.Size = btnSize;

            int margin = 20;
            int y = ClientSize.Height - btnSize.Height - margin;

            // Position buttons relative to right edge so anchoring keeps spacing on resize
            int okX = ClientSize.Width - margin - btnSize.Width;

            mBtnOk.Location = new Point(okX, y);

            mBtnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            mBtnOk.DialogResult = DialogResult.OK;

            mBtnOk.Click += (s, e) => Close();

            Controls.Add(mBtnOk);

            AcceptButton = mBtnOk;
        }

        private void ViewCharacterForm_Load(object sender, EventArgs e)
        {
            mTbxName.Text = character.Name;
            mTbxAgility.Text = character.Agility.ToString();
            mTbxHardiness.Text = character.Hardiness.ToString();
            mTbxCharisma.Text = character.Charisma.ToString();
            mTbxGold.Text = character.Gold.ToString();
            mTbxGoldInBank.Text = character.GoldInBank.ToString();
            mTbxAxe.Text = character.WeaponSkills[weaponType.Axe].ToString();
            mTbxBow.Text = character.WeaponSkills[weaponType.Bow].ToString();
            mTbxMace.Text = character.WeaponSkills[weaponType.Mace].ToString();
            mTbxSpear.Text = character.WeaponSkills[weaponType.Spear].ToString();
            mTbxSword.Text = character.WeaponSkills[weaponType.Sword].ToString();
            mTbxArmorExpertise.Text = character.ArmorExpertise.ToString();
            mTbxBlast.Text = character.SpellSkills[spellType.Blast].ToString();
            mTbxHeal.Text = character.SpellSkills[spellType.Heal].ToString();
            mTbxPower.Text = character.SpellSkills[spellType.Power].ToString();
            mTbxSpeed.Text = character.SpellSkills[spellType.Speed].ToString();

            mDgvWeaponsGrid.ColumnCount = 4;
            mDgvWeaponsGrid.Columns[0].Name = "Name";
            mDgvWeaponsGrid.Columns[1].Name = "Type";
            mDgvWeaponsGrid.Columns[2].Name = "Complexity";
            mDgvWeaponsGrid.Columns[3].Name = "Damage";

            foreach (var item in character.Items.OfType<weaponData>().ToArray())
            {
                string damage = item.Attack.AttackDice.Count.ToString() + "D" + item.Attack.AttackDice.Sides;
                if (item.Attack.AttackDice.Plus != 0)
                {
                    damage += "+" + item.Attack.AttackDice.Plus.ToString();
                }
                string[] row = new string[] { item.name, item.Attack.Type.ToString(), item.Attack.Complexity.ToString(), damage };
                mDgvWeaponsGrid.Rows.Add(row);
            }
        }
    }
}

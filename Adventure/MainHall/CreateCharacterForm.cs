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
    public partial class CreateCharacterForm : Form
    {
        private diceType mAttrDice;
        private CharacterLoader cLoader;

        public CreateCharacterForm(CharacterLoader loader)
        {
            InitializeComponent();

            mAttrDice = new diceType();
            mAttrDice.Count = 3;
            mAttrDice.Sides = 8;
            cLoader = loader;
            RollAttrs();
        }

        private void mTbxName_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(mTbxName.Text))
            {
                mBtnSave.Enabled = false;
            }
            else
            {
                mBtnSave.Enabled = true;
            }
        }

        private void RollAttrs()
        {
            mTbxAgility.Text = mAttrDice.Roll().ToString();
            mTbxHardiness.Text = mAttrDice.Roll().ToString();
            mTbxCharisma.Text = mAttrDice.Roll().ToString();
        }

        private void mBtnReroll_Click(object sender, EventArgs e)
        {
            RollAttrs();
        }

        public Character GetCharacter()
        {
            int id = 1;
            while (cLoader.Characters.Character.Select(c => c.ID).Contains(id))
            {
                id++;
            }
            return new Character(id, mTbxName.Text, int.Parse(mTbxAgility.Text), int.Parse(mTbxHardiness.Text), int.Parse(mTbxCharisma.Text));
        }

        private void mTbxName_Validating(object sender, CancelEventArgs e)
        {
            if (cLoader.Characters.Character.ToList().Exists(c => c.Name == mTbxName.Text))
            {
                MessageBox.Show("There is already an adventurer by that name.\nChoose another name.");
                mBtnSave.Enabled = false;
                e.Cancel = true;
            }
            // Else, keep the mBtnOk.Enabled value set by the mTbxName_TextChanged event
        }
    }
}

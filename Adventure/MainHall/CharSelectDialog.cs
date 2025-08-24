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
    public partial class CharSelectDialog : Form
    {
        CharacterList characters;
        CharacterType Selected { get; set; }

        public Character CurrentChar { get; private set; }
        CharacterLoader cLoader = new CharacterLoader();

        public CharSelectDialog(CharacterLoader chars)
        {
            cLoader = chars;
            characters = chars.Characters;
            InitializeComponent();

            // TODO: DataSource should be an instance of BindingList
            mLbxChooseChar.DataSource = characters.Character;
        }

        private void mBtnLoad_Click(object sender, EventArgs e)
        {
            LoadCharacter();
        }

        private void LoadCharacter()
        {
            Selected = (CharacterType)mLbxChooseChar.SelectedItem;
            if (Selected == null)
            {
                var mbx = MessageBox.Show("You must select a hero from the list first!", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                CurrentChar = new Character(Selected);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void mBtnCreateChar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void mBtnDelete_Click(object sender, EventArgs e)
        {
            Selected = (CharacterType)mLbxChooseChar.SelectedItem;
            if (Selected == null)
            {
                var mbx = MessageBox.Show("You must select a hero from the list first!", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var cList = cLoader.Characters.Character.ToList();
                cList.Remove(Selected);
                cLoader.Characters.Character = cList.ToArray();

                cLoader.SaveCharacters();

                this.Invalidate();
            }

        }

        private void MLbxChooseChar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.mLbxChooseChar.SelectedIndex = this.mLbxChooseChar.IndexFromPoint(e.Location);

            if (this.mLbxChooseChar.SelectedIndex != System.Windows.Forms.ListBox.NoMatches)

            {
                LoadCharacter();
            }
        }
    }
}

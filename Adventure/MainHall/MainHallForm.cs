using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Adventure.Dungeon;

namespace Adventure.MainHall
{
    public partial class MainHallForm : Form
    {
        private const string path = @"../../Characters.xml";
        CharacterLoader cLoader = new CharacterLoader();

        Character currentChar;

        public MainHallForm()
        {
            InitializeComponent();
            cLoader.LoadCharacters(path);
            UpdateGreeting();
        }

        private void mBtnDesk_Click(object sender, EventArgs e)
        {
            var dlgCharSelect = new CharSelectDialog(cLoader);
            DialogResult charResult = dlgCharSelect.ShowDialog(this);

            if (dlgCharSelect.CurrentChar != null)
            {
                currentChar = dlgCharSelect.CurrentChar;
                UpdateGreeting();
            }
            else if (charResult == DialogResult.OK)
            {
                mRtbGreeting.Clear();
                mRtbGreeting.AppendText("He hits his forehead and says, \"Ah, ye must be new here! Well, wait just a minute and I'll bring someone out to take care of ye.\"", Color.Black, HorizontalAlignment.Left);
                mRtbGreeting.AppendText(Environment.NewLine);
                mRtbGreeting.AppendText(Environment.NewLine);
                mRtbGreeting.AppendText(Environment.NewLine);
                mRtbGreeting.AppendText(Environment.NewLine);
                mRtbGreeting.AppendText(Environment.NewLine);
                mRtbGreeting.AppendText(Environment.NewLine);
                mRtbGreeting.AppendText(Environment.NewLine);
                mRtbGreeting.AppendText(Environment.NewLine);
                mRtbGreeting.AppendText(Environment.NewLine);
                mRtbGreeting.AppendText(Environment.NewLine);
                mRtbGreeting.AppendText("Press any key to continue.", Color.Black, HorizontalAlignment.Center);

                mPnlIntro.Visible = false;
                mPnlMain.Visible = false;
            }
            else
            {
                currentChar = null;
                UpdateGreeting();
            }

        }

        private void mBtnAdventure_Click(object sender, EventArgs e)
        {
            DialogResult dgnResult;
            using (var dlgDungeon = new DungeonForm())
            {
                dgnResult = dlgDungeon.Initialize(currentChar);
                if (DialogResult.OK == dgnResult)
                {
                    dgnResult = dlgDungeon.ShowDialog(this);
                }
            }
            if (DialogResult.Retry == dgnResult)
            {
                // Reinitialize character and try again
                currentChar = cLoader.reloadCharacter(currentChar.ID);
                mBtnAdventure_Click(sender, e);
            }
            else if (currentChar.HP <= 0)
            {
                cLoader.DeleteCharacter(currentChar);
            }
            else if (DialogResult.Cancel != dgnResult)
            {
                long treasureValue = 0;
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("You deliver your goods to Sam Slicker, the local buyer for such things. He examines your goods and pays you what they are worth...");
                foreach (itemType i in currentChar.Items.FindAll(i => !(i is weaponData)))
                {
                    treasureValue += i.baseValue;
                    sb.AppendLine(i.name + " is worth " + i.baseValue + " gold pieces.");
                }
                sb.AppendLine("He pays you " + treasureValue + " gold pieces total.");
                MessageBox.Show(sb.ToString());

                currentChar.Gold = (ulong)((long)(currentChar.Gold) + treasureValue);

                cLoader.UpdateCharacter(currentChar);
            }
            cLoader.SaveCharacters();
        }

        private void UpdateGreeting()
        {
            if (currentChar == null)
            {
                //mRtbGreeting.Text = "You are greeted by a burly Irishman " +
                //    "who looks at you with a scowl and asks you, \"What's yer name?\"";
                mRtbGreeting.Clear();
                mRtbGreeting.AppendText("WELCOME TO MY" + Environment.NewLine, Color.Goldenrod, HorizontalAlignment.Center);
                mRtbGreeting.AppendText("EAMON-INSPIRED COMPUTERIZED FANTASY GAMING SYSTEM" + Environment.NewLine, Color.Goldenrod, HorizontalAlignment.Center);
                mRtbGreeting.AppendText(Environment.NewLine);
                mRtbGreeting.AppendText("You are in the outer chamber of the hall of the Guild of Free Adventurers. Many men and women are guzzling beer and there is loud singing and laughter." + Environment.NewLine + Environment.NewLine, mRtbGreeting.ForeColor, HorizontalAlignment.Left);
                mRtbGreeting.AppendText("On the north side of the chamber is a  cubbyhole with a desk. Over the desk is a sign which says: ");
                mRtbGreeting.AppendText("REGISTER HERE OR ELSE!" + Environment.NewLine, Color.LimeGreen);
                mRtbGreeting.AppendText(Environment.NewLine + Environment.NewLine);
                mRtbGreeting.AppendText("Do you go over to the desk or join the men drinking beer?");
                mPnlIntro.Visible = true;
                mPnlMain.Visible = false;

                //foreach (MemberInfo m in typeof(Color).GetMembers())
                //{
                //    if (m.ReflectedType == typeof(Color))
                //    {
                //        String name = m.Name;
                //        if (!name.StartsWith("get_"))
                //        {
                //            Color c = Color.FromName(name);
                //            mRtbGreeting.AppendText(m.Name, c);
                //        }
                //    }
                //}
            }
            else
            {
                mRtbGreeting.Clear();
                mRtbGreeting.AppendText("He starts looking through his book, while muttering something about \"strange Saxon names.\"" + Environment.NewLine + Environment.NewLine + "Finally he looks up and says, \"Ah, here ye be. Well, go and have fun in the hall.\"", Color.Black, HorizontalAlignment.Left);
                mPnlIntro.Visible = false;
                mPnlMain.Visible = true;
            }
            Invalidate();
        }

        private void MainHallForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (mPnlMain.Visible)
            {
                switch (e.KeyCode)
                {
                    case Keys.G:
                        mBtnAdventure_Click(sender, e);
                        break;

                    case Keys.B:
                        MBtnShop_Click(sender, e);
                        break;

                    case Keys.S:
                        MBtnWizard_Click(sender, e);
                        break;

                    case Keys.L:
                        mBtnLeave_Click(sender, e);
                        break;

                    default:
                        //Do Nothing
                        break;
                }

            }
            else if (mPnlIntro.Visible)
            {
                switch (e.KeyCode)
                {
                    case Keys.D:
                        mBtnDesk_Click(sender, e);
                        break;

                    case Keys.M:
                        mBtnMen_Click(sender, e);
                        break;

                    case Keys.Q:
                    case Keys.Escape:
                        mBtnQuit_Click(sender, e);
                        break;

                    default:
                        //Do Nothing
                        break;
                }
            }
            else
            {
                var dlgCreateChar = new CreateCharacterForm(cLoader);
                var dlgResult = dlgCreateChar.ShowDialog();

                if (dlgResult == System.Windows.Forms.DialogResult.OK)
                {
                    currentChar = dlgCreateChar.GetCharacter();
                    var cList = cLoader.Characters.Character.ToList();
                    cList.Add(currentChar.Translate());
                    cLoader.Characters.Character = cList.ToArray();

                    cLoader.SaveCharacters();
                    Close();
                }
                else if (dlgResult == System.Windows.Forms.DialogResult.Cancel)
                {
                    mPnlIntro.Visible = true;
                    UpdateGreeting();
                }
            }
        }

        private void mBtnMen_Click(object sender, EventArgs e)
        {
            MessageBox.Show("As you go over to the men, you feel a sword being thrust through your back and you hear someone say, \"You really must learn to follow directions!\"\n\nTry again!", "", MessageBoxButtons.OK);
        }

        private void mBtnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mBtnLeave_Click(object sender, EventArgs e)
        {
            currentChar = null;
            UpdateGreeting();
        }

        private void MBtnShop_Click(object sender, EventArgs e)
        {
            DialogResult shopResult;
            using (var dlgShop = new ShopForm(currentChar))
            {
                shopResult = dlgShop.ShowDialog(this);
            }
            if (DialogResult.OK == shopResult)
            {
                cLoader.UpdateCharacter(currentChar);
                cLoader.SaveCharacters();
            }
            else if (DialogResult.Cancel != shopResult)

            {
                // Reinitialize character and try again
                MessageBox.Show("An error occurred in the shop. Your character will be reloaded to avoid corruption.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                currentChar = cLoader.reloadCharacter(currentChar.ID);
            }

        }

        private void MBtnWizard_Click(object sender, EventArgs e)
        {
            DialogResult shopResult;
            using (var dlgShop = new WizardForm(currentChar))
            {
                shopResult = dlgShop.ShowDialog(this);
            }
            if (DialogResult.OK == shopResult)
            {
                cLoader.UpdateCharacter(currentChar);
                cLoader.SaveCharacters();
            }
            else if (DialogResult.Cancel != shopResult)

            {
                // Reinitialize character and try again
                MessageBox.Show("An error occurred in the shop. Your character will be reloaded to avoid corruption.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                currentChar = cLoader.reloadCharacter(currentChar.ID);
            }

        }

        private void MBtnView_Click(object sender, EventArgs e)
        {
            DialogResult viewResult;
            using (var dlgView = new ViewCharacterForm(currentChar))
            {
                viewResult = dlgView.ShowDialog(this);
            }
        }
    }
}

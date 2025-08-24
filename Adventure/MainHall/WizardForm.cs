using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Adventure.MainHall
{
    public partial class WizardForm : Adventure.TextInputForm
    {
        Character buyer = null;
        private Random rand;
        public WizardForm(Character character)
        {
            InitializeComponent();
            buyer = character ?? throw new NullReferenceException();
            mLblRoom.Text = "Wizard's Spell Shop";
            Logger.ClearBuffer();
            MainMenu();
            mRtxtWhatYouSee.Text = Logger.GetBuffer();
            Logger.ClearBuffer();
            rand = new Random();
        }

        private void MainMenu()
        {
            Logger.WriteLn("After a few minutes diligent searching, you find Hokas Tokas, the old Mage. He looks at you and says, \"So you want old Hokey to teach you some magic, eh? Well, it'll cost you. My fees are:\"");
            Logger.WriteLn(String.Format("  Blast\t{0,4} GP", MainHallConfig.Instance.SpellCost[spellType.Blast]));
            Logger.WriteLn(String.Format("  Heal \t{0,4} GP", MainHallConfig.Instance.SpellCost[spellType.Heal]));
            Logger.WriteLn(String.Format("  Speed\t{0,4} GP", MainHallConfig.Instance.SpellCost[spellType.Speed]));
            Logger.WriteLn(String.Format("  Power\t{0,4} GP", MainHallConfig.Instance.SpellCost[spellType.Power]));
            Logger.WriteLn();
            Logger.WriteLn("\"Well, which will it be?\"");
            Logger.WriteLn("Hit a key, B, H, S, P, or (N)one:");
        }

        protected override
        void mBtnOk_Click(object sender, EventArgs e)
        {
            spellType? spell = null;
            switch (historyTextBox1.Text.ToUpper())
            {
                case "N":
                    DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    this.Close();
                    break;
                case "B":
                    spell = spellType.Blast;
                    break;
                case "H":
                    spell = spellType.Heal;
                    break;
                case "S":
                    spell = spellType.Speed;
                    break;
                case "P":
                    spell = spellType.Power;
                    break;
                default:
                    MainMenu();
                    break;
            }

            if (spell != null)
            {
                int cost = MainHallConfig.Instance.SpellCost[(spellType)spell];
                if (buyer.SpellSkills[(spellType)spell] > 0)
                {
                    Logger.WriteLn("Hokas says, \"I ought to take your gold anyway, but haven't you forgotten something? I already taught you that spell!\"\n");
                    Goodbye("Shaking his head sadly, he returns to the bar.");
                }
                else if ((ulong)cost > buyer.Gold)
                {
                    Goodbye("When Hokas sees that you don't have enough to pay him, he stalks to the bar, muttering about youngsters who should be turned into frogs.");
                }
                else
                {
                    buyer.Gold -= (ulong)cost;
                    buyer.SpellSkills[(spellType)spell] = rand.Next(60) + 20;

                    Goodbye("Hokas teaches you your spell, takes his fee, and returns to his stool on the bar. As you walk away, you hear him order a Double Dragon Blomb.");
                }
            }
            base.mBtnOk_Click(sender, e);
        }
        private void Goodbye(string Message)
        {
            Logger.WriteLn(Message);
            this.mBtnOk.Visible = false;
            this.mLblCommand.Visible = false;
            this.historyTextBox1.Visible = false;
            this.mBtnClose.Enabled = true;
            this.mBtnClose.Visible = true;
            this.mBtnClose.Focus();
        }

        private void MBtnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}

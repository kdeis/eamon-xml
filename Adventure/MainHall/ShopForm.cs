using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.MainHall
{
    internal class ShopForm : TextInputForm
    {
        private enum ShopStateType
        {
            ItemSelect,
            ItemSubselect,
            Confirm,
            Exit
        }

        private enum ShopActionType
        {
            BuyWeap,
            SellWeap,
            Armor,
            None
        }

        private const string COME_BACK_SOON = "Marcos smiles and says, \"Come back again soon!\" as he shoos you out of his shop.";
        private const string CANT_AFFORD_IT = "\"However, I see you can't afford that much. Come back when you can.\"";
        ShopStateType state = ShopStateType.ItemSelect;
        ShopActionType shopAction = ShopActionType.None;
        ulong offerPrice = 0;
        weaponType offerType;
        itemType offerItem = null;
        Character buyer = null;
        public ShopForm(Character character) : base()
        {
            buyer = character ?? throw new NullReferenceException();
            mLblRoom.Text = "Weapons and Armor Shop";
            Logger.ClearBuffer();
            Logger.WriteLn("As you enter the weapon shop, Marcos Cavielli (the owner) comes from out of the back room and says, \"Well, as I live and breathe, if it isn't my old pal, " + buyer.Name + "!\"");
            Logger.WriteLn();
            ShowMenu();
            mRtxtWhatYouSee.Text = Logger.GetBuffer();
            Logger.ClearBuffer();
        }

        private void ShowMenu()
        {
            switch (shopAction)
            {
                case ShopActionType.None:
                    MainMenu();
                    break;
                case ShopActionType.SellWeap:
                    SellWeaponSelect();
                    break;
                case ShopActionType.BuyWeap:
                    BuyWeaponSelect();
                    break;
                case ShopActionType.Armor:
                    BuyArmorSelect();
                    break;
                default:
                    break;
            }
        }

        private void MainMenu()
        {
            Logger.WriteLn("\"So, what do you need?\"");
            Logger.WriteLn("1. Buy a weapon");
            Logger.WriteLn("2. Sell a weapon");
            Logger.WriteLn("3. Get some better armor");
            Logger.WriteLn();
            Logger.Write("Enter 1-3 (or 0 to exit) ");
            shopAction = ShopActionType.None;
        }

        protected override
        void mBtnOk_Click(object sender, EventArgs e)
        {
            if (shopAction == ShopActionType.None)
            {
                switch (historyTextBox1.Text)
                {
                    case "0":
                        DialogResult = System.Windows.Forms.DialogResult.Cancel;
                        Close();
                        break;
                    case "1":
                        BuyWeaponMenu();
                        break;
                    case "2":
                        SellWeaponMenu();
                        break;
                    case "3":
                        BuyArmorMenu();
                        break;
                    default:
                        MainMenu();
                        break;
                }
            }
            else if (shopAction == ShopActionType.SellWeap)
            {
                if (state == ShopStateType.ItemSelect)
                {
                    SellWeaponSelect();
                }
                else if (historyTextBox1.Text.StartsWith("y", StringComparison.CurrentCultureIgnoreCase))
                {
                    Logger.WriteLn("Marcos gives you your money and takes your weapon.\n");
                    buyer.Gold += offerPrice;
                    buyer.Items.Remove(offerItem);
                    Goodbye(COME_BACK_SOON);
                }
                else
                {
                    MainMenu();
                }
            }
            else if (shopAction == ShopActionType.BuyWeap)
            {
                if (state == ShopStateType.ItemSelect)
                {
                    BuyWeaponSelect();
                }
                else
                {
                    if (historyTextBox1.Text.StartsWith("y", StringComparison.CurrentCultureIgnoreCase))
                    {
                        Logger.WriteLn("Marcos hands you your new weapon and takes the price from you.\n");
                        buyer.Gold -= offerPrice;
                        buyer.Items.Add(offerItem);
                        Goodbye(COME_BACK_SOON);
                    }
                    else
                    {
                        MainMenu();
                    }
                }
            }
            else if (shopAction == ShopActionType.Armor)
            {
                if (state == ShopStateType.ItemSelect)
                {
                    BuyArmorSelect();
                }
                else
                {
                    if (historyTextBox1.Text.StartsWith("y", StringComparison.CurrentCultureIgnoreCase))
                    {
                        Logger.WriteLn("Marcos takes your gold and gives you a shield.\n");
                        buyer.Gold -= offerPrice;
                        buyer.ArmorClass++;
                    }
                    Goodbye(COME_BACK_SOON);
                }
            }
            base.mBtnOk_Click(sender, e);
        }

        private void Goodbye(string Message)
        {
            Logger.WriteLn(Message);
            mBtnOk.Visible = false;
            mLblCommand.Visible = false;
            historyTextBox1.Visible = false;
            mBtnLeave.Enabled = true;
            mBtnLeave.Visible = true;
            mBtnLeave.Focus();
        }

        private void SellWeaponSelect()
        {
            int s;
            bool success = int.TryParse(historyTextBox1.Text, out s);
            if (!success || s <= 0 || s > buyer.Items.Count)
            {
                MainMenu();
            }
            else
            {
                // Make offer
                offerItem = buyer.Items[s - 1];
                offerPrice = (ulong)offerItem.baseValue;
                Logger.WriteLn("\"Well, I can give you " + offerPrice + " gold pieces for it.\"\n");
                Logger.Write("Do you want to sell? (Y/N) ");
                state = ShopStateType.Confirm;
            }
        }

        private void BuyArmorSelect()
        {
            int s;
            bool success = int.TryParse(historyTextBox1.Text, out s);
            if (!success || s <= 0 || s > MainHallConfig.Instance.ShopArmor.Length)
            {
                MainMenu();
            }
            else
            {
                if (buyer.Gold + offerPrice >= MainHallConfig.Instance.ShopArmor[s - 1].buyValue)
                {
                    buyer.Gold = buyer.Gold + offerPrice - MainHallConfig.Instance.ShopArmor[s - 1].buyValue;
                    bool hasShield = buyer.ArmorClass % 2 == 1;
                    buyer.ArmorClass = MainHallConfig.Instance.ShopArmor[s - 1].armorClass;
                    if (hasShield)
                    {
                        buyer.ArmorClass++;
                    }
                    Logger.WriteLn("Marcos takes your gold and helps you into your new armor.\n");

                    if (hasShield)
                    {
                        Goodbye(COME_BACK_SOON);
                    }
                    else
                    {
                        Logger.WriteLn("Marcos smiles and says, \"Now how about a shield? I can let you have one for only " + MainHallConfig.Instance.ShieldValue + " gold pieces.\"\n");
                        if (buyer.Gold >= (ulong)MainHallConfig.Instance.ShieldValue)
                        {
                            Logger.Write("Do you want a shield? (Y/N): ");
                            state = ShopStateType.Confirm;
                        }
                        else
                        {
                            Goodbye(CANT_AFFORD_IT);
                        }
                    }
                }
                else
                {
                    Logger.WriteLn("Marcos frowns when he sees that you don't have enough to pay for your armor and says, \"I don't give credit!\"\n");
                    Goodbye(COME_BACK_SOON);
                }
            }
        }

        private void BuyArmorMenu()
        {
            Logger.WriteLn("Marcos takes you to the armor section of his shop and shows you suits of leather, chain and plate armor.\n");
            Logger.WriteLn("He says, \"I can fit you in any of these pretty cheaply, I need 100 for the leather, 250 for the chain, and 500 for the plate.\"\n");

            offerPrice = 0;
            bool hasShield = buyer.ArmorClass % 2 == 1;
            if (buyer.ArmorClass > 1)
            {
                // Get trade-in value
                int oldAC = buyer.ArmorClass;
                if (hasShield)
                {
                    oldAC -= 1;
                }
                ConfigArmor oldArmor = Array.Find(MainHallConfig.Instance.ShopArmor, (a) => a.armorClass == oldAC);
                if (oldArmor != null)
                {
                    offerPrice = oldArmor.sellValue;
                    Logger.WriteLn("\"Also, I can give you a trade in on your old armor of " + offerPrice + " gold pieces.\"");
                }
            }
            Logger.WriteLn("\"Well, what will it be?\"");
            for (int i = 0; i < MainHallConfig.Instance.ShopArmor.Length; i++)
            {
                Logger.WriteLn(string.Format("{0}. {1,-8} \t{2,3}", (i + 1), MainHallConfig.Instance.ShopArmor[i].name, MainHallConfig.Instance.ShopArmor[i].buyValue));
            }
            Logger.Write("Enter 1-"+ MainHallConfig.Instance.ShopArmor.Length+" (or 0 to exit): ");

            shopAction = ShopActionType.Armor;
            state = ShopStateType.ItemSelect;
        }

        private void SellWeaponMenu()
        {
            Logger.WriteLn("\"Which weapon do you wanna sell?\"\n");
            for (int i = 0; i < buyer.Items.Count; i++)
            {
                Logger.WriteLn((i + 1) + ". " + buyer.Items[i].name);
            }
            Logger.Write("Enter no. of weapon (0 exits): ");
            shopAction = ShopActionType.SellWeap;
            state = ShopStateType.ItemSelect;
        }

        private void BuyWeaponMenu()
        {
            if (buyer.Items.FindAll((w) => w is weaponData).Count >= 4)
            {
                Logger.WriteLn("Marcos smiles at you and says, \"Thatsa good, but first you must sell me a weapon. You know the law: No more than four weapons per person!\"");
            }
            else
            {
                Logger.WriteLn("Marcos smiles at you and says, \"Good! I gotta the best. What kind do you want?\"\n");
                Logger.WriteLn(" Enter weapon of choice:");
                foreach (weaponType w in Enum.GetValues(typeof(weaponType)))
                {
                    Logger.WriteLn((int)w + 1 + ". " + w);
                }
                Logger.Write("Enter 1-" + (Enum.GetValues(typeof(weaponType)).Length) + " (or 0 to exit): ");

                shopAction = ShopActionType.BuyWeap;
                state = ShopStateType.ItemSelect;
            }
        }
        private void BuyWeaponSelect()
        {
            int s;
            bool success = int.TryParse(historyTextBox1.Text, out s);
            if (!success || s <= 0 || s > Enum.GetValues(typeof(weaponType)).Length)
            {
                MainMenu();
            }
            else
            {
                offerType = (weaponType)(s - 1);
                offerItem = MainHallConfig.Instance.ShopWeapons[offerType].weapon;
                offerPrice = MainHallConfig.Instance.ShopWeapons[offerType].buyValue;
                Logger.WriteLn("\"Well, I just happen to have a " + offerType + " of decent quality. I can let you have it for " + offerPrice + " gold pieces.\"\n");
                if (buyer.Gold >= offerPrice)
                {
                    Logger.Write("Do you want to buy? (Y/N) ");
                    state = ShopStateType.Confirm;
                }
                else
                {
                    Goodbye(CANT_AFFORD_IT);
                }
            }
        }
    }
}

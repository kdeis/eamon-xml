using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using Helpers;

namespace Adventure.MainHall
{
    public class MainHallConfig
    {
        private static MainHallConfig instance = null;
        private static readonly object padlock = new object();

        private MainHallConfig()
        {
        }

        public static MainHallConfig Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        ReadConfig("MainHallConfig.xml");
                        //instance.TempWriteConfig();
                    }
                    return instance;
                }
            }
        }
        private static void ReadConfig(string fileName)
        {
            string configXml = File.ReadAllText(fileName);
            instance = configXml.ParseXML<MainHallConfig>();
        }
        public void TempWriteConfig()
        {
            defaultAttackPhrases = new SerializableDictionary<weaponType, string[]>();
            string[] axePhrases = { "chops at", "swings at", "hacks at" };
            string[] bowPhrases = { "shoots at", "fires at", "targets" };
            string[] macePhrases = { "swings at", "bludgeons" };
            string[] spearPhrases = { "thrusts at", "stabs at", "lunges at" };
            string[] swordPhrases = { "chops at", "swings at", "stabs at" };
            defaultAttackPhrases.Add(weaponType.Axe, axePhrases);
            defaultAttackPhrases.Add(weaponType.Bow, bowPhrases);
            defaultAttackPhrases.Add(weaponType.Mace, macePhrases);
            defaultAttackPhrases.Add(weaponType.Spear, spearPhrases);
            defaultAttackPhrases.Add(weaponType.Sword, swordPhrases);

            ShopWeapons = new SerializableDictionary<weaponType, ConfigWeap>();
            ShopWeapons.Add(weaponType.Axe, MakeWeap(weaponType.Axe, 6, 25));
            ShopWeapons.Add(weaponType.Bow, MakeWeap(weaponType.Bow, 6, 40));
            ShopWeapons.Add(weaponType.Mace, MakeWeap(weaponType.Mace, 4, 20));
            ShopWeapons.Add(weaponType.Spear, MakeWeap(weaponType.Spear, 5, 25));
            ShopWeapons.Add(weaponType.Sword, MakeWeap(weaponType.Sword, 8, 30));

            string characterXml = this.SerializeObject<MainHallConfig>();
            File.WriteAllText("MainHallConfig.xml", characterXml);
        }

        static ConfigWeap MakeWeap(weaponType w, int dsides, uint buyValue)
        {
            ConfigWeap weap = new ConfigWeap();
            weap.buyValue = buyValue;
            weap.weapon = new weaponData();
            weap.weapon.Attack = new WeaponAttackType();
            weap.weapon.Attack.AttackDice = new diceType();
            weap.weapon.Attack.AttackDice.Count = 1;
            weap.weapon.Attack.AttackDice.Sides = dsides;
            weap.weapon.Attack.AttackDice.Plus = 0;
            weap.weapon.Attack.Type = w;
            weap.weapon.baseValue = 15;
            weap.weapon.description = String.Format("This is a basic, decent quality {0}.", w);
            weap.weapon.name = w.ToString();
            weap.weapon.weight = 1;
            return weap;
        }
        public SerializableDictionary<weaponType, string[]> defaultAttackPhrases;
        public string[] defaultNaturalAttackPhrases;
        public SerializableDictionary<weaponType, ConfigWeap> ShopWeapons;
        public ConfigArmor[] ShopArmor;
        public int ShieldValue;

        public SerializableDictionary<spellType, int> SpellCost;
    }

    public class ConfigWeap
    {
        public weaponData weapon;
        public uint buyValue;
    }

    public class ConfigArmor
    {
        public string name;
        public int armorClass;
        public uint buyValue;
        public uint sellValue;
    }
}

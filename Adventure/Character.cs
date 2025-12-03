using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public enum spellType
    {

        /// <remarks/>
        Heal,

        /// <remarks/>
        Blast,

        /// <remarks/>
        Power,

        /// <remarks/>
        Speed
    }

    public class Character : Creature
    {
        public int ArmorExpertise { get; set; }

        public Dictionary<weaponType, int> WeaponSkills { get; set; }

        /// <summary>
        /// Base spell skill levels
        /// </summary>
        public Dictionary<spellType, int> SpellSkills { get; set; }

        /// <summary>
        /// Current spell levels, including temporary losses or fatigue from repeated use
        /// </summary>
        public Dictionary<spellType, double> CurrentSpellSkills { get; set; }

        public int Charisma { get; set; }

        public int MaxWeight { get; private set; }

        public ulong Gold { get; set; }

        public ulong GoldInBank { get; set; }

        public weaponData ReadyWeap { get; set; }

        public List<itemType> WornItems { get; }
        public Character(CharacterType character)
            : base(character)
        {
            ArmorExpertise = character.ArmorExpertise;

            Items = new List<itemType>();
            WornItems = new List<itemType>();
            WeaponSkills = new Dictionary<weaponType, int>();
            WeaponSkills.Add(weaponType.Axe, character.Axe);
            WeaponSkills.Add(weaponType.Bow, character.Bow);
            WeaponSkills.Add(weaponType.Mace, character.Mace);
            WeaponSkills.Add(weaponType.Spear, character.Spear);
            WeaponSkills.Add(weaponType.Sword, character.Sword);

            SpellSkills = new Dictionary<spellType, int>();
            SpellSkills.Add(spellType.Blast, character.Blast);
            SpellSkills.Add(spellType.Heal, character.Heal);
            SpellSkills.Add(spellType.Power, character.Power);
            SpellSkills.Add(spellType.Speed, character.Speed);
            CurrentSpellSkills = new Dictionary<spellType, double>();
            CurrentSpellSkills.Add(spellType.Blast, character.Blast);
            CurrentSpellSkills.Add(spellType.Heal, character.Heal);
            CurrentSpellSkills.Add(spellType.Power, character.Power);
            CurrentSpellSkills.Add(spellType.Speed, character.Speed);

            Charisma = character.Charisma;
            MaxWeight = character.Hardiness * 10;

            Gold = character.Gold;

            GoldInBank = character.GoldInBank;

            foreach (weaponData w in character.WeaponList)
            {
                Items.Add(w);
            }

            if (character.WeaponList.Length > 0)
            {
                ReadyWeap = character.WeaponList.First();
            }
        }

        public Character(int id, string name, int ag, int hd, int ch)
            : base()
        {
            ID = id;
            Name = name;
            HP = hd;
            Hardiness = hd;
            Agility = ag;
            Charisma = ch;

            ArmorClass = 0;
            ArmorExpertise = 0;

            Items = new List<itemType>();
            WeaponSkills = new Dictionary<weaponType, int>();
            WeaponSkills.Add(weaponType.Axe, 0);
            WeaponSkills.Add(weaponType.Bow, -20);
            WeaponSkills.Add(weaponType.Mace, 20);
            WeaponSkills.Add(weaponType.Spear, 0);
            WeaponSkills.Add(weaponType.Sword, 10);

            SpellSkills = new Dictionary<spellType, int>();
            SpellSkills.Add(spellType.Blast, 0);
            SpellSkills.Add(spellType.Heal, 0);
            SpellSkills.Add(spellType.Power, 0);
            SpellSkills.Add(spellType.Speed, 0);
            CurrentSpellSkills = new Dictionary<spellType, double>();
            CurrentSpellSkills.Add(spellType.Blast, 0);
            CurrentSpellSkills.Add(spellType.Heal, 0);
            CurrentSpellSkills.Add(spellType.Power, 0);
            CurrentSpellSkills.Add(spellType.Speed, 0);

            MaxWeight = Hardiness * 10;

            Gold = 200;

            GoldInBank = 0;
        }

        public override AttackType GetWeapon()
        {
            return ReadyWeap.Attack;
        }

        public override weaponData DropWeapon()
        {
            weaponData retval = null;
            if (ReadyWeap != null)
            {
                retval = ReadyWeap;
                Items.Remove(ReadyWeap);
                ReadyWeap = null;
            }

            return retval;
        }

        public void WearItem(itemType item)
        {
            ArmorClass += item.armorClass;
            WornItems.Add(item);
            item.DoWear();
        }

        public void RemoveItem(itemType item)
        {
            ArmorClass -= item.armorClass;
            WornItems.Remove(item);
            item.DoRemove();
        }

        protected virtual void PopulateCharacterType(CharacterType character)
        {
            PopulateCreatureType(character);
            character.ArmorExpertise = (byte)ArmorExpertise;

            character.Axe = (sbyte)WeaponSkills[weaponType.Axe];
            character.Bow = (sbyte)WeaponSkills[weaponType.Bow];
            character.Mace = (sbyte)WeaponSkills[weaponType.Mace];
            character.Spear = (sbyte)WeaponSkills[weaponType.Spear];
            character.Sword = (sbyte)WeaponSkills[weaponType.Sword];
            character.Blast = (sbyte)SpellSkills[spellType.Blast];
            character.Heal = (sbyte)SpellSkills[spellType.Heal];
            character.Power = (sbyte)SpellSkills[spellType.Power];
            character.Speed = (sbyte)SpellSkills[spellType.Speed];
            character.Charisma = (sbyte)Charisma;

            character.Gold = Gold;

            character.GoldInBank = GoldInBank;

            if (Items != null)
            {
                character.WeaponList = Items.OfType<weaponData>().ToArray();
                character.Items = new CreatureTypeItems();
                //character.Items.Item = Items.FindAll(i => !(i is weaponData)).Select<itemType, int>((j, k) => j.id).ToArray();
            }
        }

        public CharacterType Translate()
        {
            CharacterType charType = new CharacterType();
            PopulateCharacterType(charType);
            return charType;
        }
    }
}

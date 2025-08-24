using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Dungeon
{
    public class Monster : Creature
    {
        public string Description { get; set; }

        public DispositionType Disposition { get; set; }

        public int Friendliness { get; set; }

        private int Courage { get; set; }

        private bool CanUseWeapons { get; set; }

        private Dictionary<weaponType, bool> CanUseWeaponTypes { get; set; }

        private int FavoredWeaponId { get; set; }

        public weaponData Weapon { get; set; }

        private AttackType NaturalAttack { get; set; }

        public bool NoFollow { get; set; }

        public Monster(MonsterType monster)
            : base(monster)
        {
            Description = monster.Description;
            Disposition = monster.Disposition;
            if (monster.FriendlinessSpecified)
            {
                Friendliness = monster.Friendliness;
            }
            else
            {
                Friendliness = 50;
            }
            Courage = monster.Courage;
            NaturalAttack = monster.NaturalAttack;
            NoFollow = monster.NoFollow;
            CanUseWeapons = monster.CanUseWeapons;
            CanUseWeaponTypes = new Dictionary<weaponType, bool>();
            if (CanUseWeapons)
            {
                foreach (weaponType w in Enum.GetValues(typeof(weaponType)))
                {
                    CanUseWeaponTypes.Add(w, monster.CanUseWeaponTypes.Contains(w));
                }
                FavoredWeaponId = monster.FavoredWeaponID;
            }
        }

        public override AttackType GetWeapon()
        {
            if (CanUseWeapons && Weapon != null)
                return Weapon.Attack;
            else
                return NaturalAttack;
        }

        public override weaponData DropWeapon()
        {
            weaponData retval = null;
            if (CanUseWeapons && Weapon != null)
            {
                retval = Weapon;
                Weapon = null;
            }

            return retval;
        }

        public Boolean PickupWeapon(List<itemType> itemsInRoom)
        {
            Boolean pickedOneUp = false;
            if (CanUseWeapons)
            {
                // if not currently using the favored weapon, look for it
                if (Weapon == null || Weapon.id != FavoredWeaponId)
                {
                    // Already holding favored weapon?
                    weaponData fav = (weaponData)itemsInRoom.Find((i) => i.id == FavoredWeaponId);
                    if (fav == null)
                    {
                        fav = (weaponData)this.Items.Find((i) => i.id == FavoredWeaponId);
                    }
                    else
                    {
                        // Favored weapon in the room?
                        itemsInRoom.Remove(fav);
                        this.Items.Add(fav);
                        Logger.WriteLn("\n" + Name + " picks up " + fav.name + ".");
                        pickedOneUp = true;
                    }

                    // If favored weapon found, use it!
                    if (fav != null)
                    {
                        Weapon = fav;
                    }
                }

                // If still not using any weapon, look for one I can use
                if (Weapon == null)
                {
                    Random rand = new Random();
                    // If holding any useable weapons, pick one of them
                    List<itemType> useable = Items.FindAll((i) => i is weaponData && CanUseWeaponTypes[((weaponData)i).Attack.Type]);
                    if (useable.Count > 0)
                    {
                        int idx = rand.Next(useable.Count);
                        Weapon = (weaponData)useable.ElementAt(idx);
                    }
                    else
                    {
                        // If any useable weapons in the room, get one of them
                        useable = itemsInRoom.FindAll((i) => i is weaponData && CanUseWeaponTypes[((weaponData)i).Attack.Type]);
                        if (useable.Count > 0)
                        {
                            int idx = rand.Next(useable.Count);
                            Weapon = (weaponData)useable.ElementAt(idx);
                            itemsInRoom.Remove(Weapon);
                            this.Items.Add(Weapon);
                            Logger.WriteLn(ID + " picks up " + Weapon.name + ".");
                            pickedOneUp = true;
                        }
                    }
                }
            }
            return pickedOneUp;
        }

        public override void Die()
        {
            base.Die();
            itemType weap = DropWeapon();
            if (weap != null)
            {
                Context.Instance.CurrentRoom.Items.Add(weap);
            }
            if (Items != null && Items.Count > 0)
            {
                Context.Instance.CurrentRoom.Items.AddRange(Items);
                Items.Clear();
            }
        }

        public bool CourageTest(Random rand)
        {
            int adjustedCourage = Courage;
            if (HP < MaxHP / 4)
            {
                adjustedCourage = (int)(adjustedCourage * 0.90);
            }
            else if (HP < MaxHP)
            {
                adjustedCourage = (int)(adjustedCourage * 0.95);
            }

            return rand.Next(100) < adjustedCourage;
        }

        protected virtual void PopulateMonsterType(MonsterType monster)
        {
            PopulateCreatureType(monster);

            monster.Description = Description;
            monster.Disposition = Disposition;
            monster.NaturalAttack = NaturalAttack;
            monster.CanUseWeapons = CanUseWeapons;
            CanUseWeaponTypes = new Dictionary<weaponType, bool>();
            if (CanUseWeapons)
            {
                monster.CanUseWeaponTypes = CanUseWeaponTypes.Keys.ToList().FindAll(t => CanUseWeaponTypes[t] == true).ToArray();
                monster.FavoredWeaponID = FavoredWeaponId;
            }
            monster.Items.Item = Items.Select<itemType, int>((j, k) => j.id).ToArray();
        }

    }
}

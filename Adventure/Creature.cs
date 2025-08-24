using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public abstract class Creature : Adventure.ICreature
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int HP { get; set; }

        public int MaxHP { get { return Hardiness; } }

        public int Hardiness { get; set; }

        public int Agility { get; set; }

        public int ArmorClass { get; set; }

        public List<itemType> Items { get; set; }

        public Creature()
        {
        }

        public Creature(CreatureType creature)
        {
            ID = creature.ID;

            Name = creature.Name;

            HP = creature.Hardiness;

            Hardiness = creature.Hardiness;

            Agility = creature.Agility;

            ArmorClass = creature.ArmorClass;
        }

        public abstract AttackType GetWeapon();

        public abstract weaponData DropWeapon();

        public virtual void Die()
        {
            onKill?.Invoke(this, EventArgs.Empty);
        }

        public void Heal(int healPoints)
        {
            HP += healPoints;
            if (HP > MaxHP)
            {
                HP = MaxHP;
            }
            LogStatus();
        }

        public void TakeDamage(int damage)
        {
            HP -= damage;
            if (HP < 0)
            {
                HP = 0;
            }
            LogStatus();
            if (HP == 0)
            {
                Die();
            }
            else if (damage > 0 && HP > 0 && onWound != null)
            {
                onWound(this, EventArgs.Empty);
            }
        }

        private void LogStatus()
        {
            Logger.WriteLn(String.Format(" {0} is {1}", Name, GetStatus()));
        }

        public string GetStatus()
        {
            if (HP == 0)
            {
                return " dead!";
            }
            else if (HP < MaxHP / 4)
            {
                return " clinging desperately to the last vestiges of a sad little life!";
            }
            else if (HP < MaxHP / 2)
            {
                return " badly injured!";
            }
            else if (HP < MaxHP * 3 / 4)
            {
                return " hurting!";
            }
            else if (HP < MaxHP)
            {
                return " still in good shape.";
            }
            else
            {
                return " feels strong enough to pull the wings off a gondar.";
            }
        }

        public virtual void TakeItem(itemType item)
        {
            Items.Add(item);
        }

        protected void PopulateCreatureType(CreatureType creature)
        {
            creature.ID = ID;

            creature.Name = Name;

            creature.Hardiness = Hardiness;

            creature.Agility = Agility;

            creature.ArmorClass = ArmorClass;
        }

        public void blast()
        {
            onBlast?.Invoke(this, EventArgs.Empty);
        }

        public void MagicWord(string word)
        {
            onMagicWord?.Invoke(this, new StringEventArgs(word));
        }

        public bool power()
        {
            if (onPower != null)
            {
                onPower(this, EventArgs.Empty);
                return true;
            }
            return false;
        }

        public event EventHandler onBlast;

        public event EventHandler<StringEventArgs> onMagicWord;

        public event EventHandler onWound;

        public event EventHandler onPower;

        public event EventHandler onKill;
    }
}

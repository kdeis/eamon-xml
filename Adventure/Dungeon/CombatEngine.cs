using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure.MainHall;

namespace Adventure.Dungeon
{
    public class CombatEngine
    {
        private Random rand;

        /// <summary>
        /// Constructor
        /// </summary>
        public CombatEngine()
        {
            rand = new Random();
        }

        /// <summary>
        /// Roll for damage
        /// </summary>
        /// <param name="dice"></param>
        /// <returns></returns>
        private int DamageRoll(diceType dice)
        {
            int damage = dice.Roll();

            return damage;
        }

        public void Attack(IRoom currentRoom, ICreature attacker, ICreature defender)
        {
            AttackType weap = attacker.GetWeapon();
            int hitChance = 50;
            hitChance += 2 * (attacker.Agility - defender.Agility - attacker.ArmorClass + defender.ArmorClass);

            Logger.Write(String.Format("\n{0} {1} {2}", attacker.Name, GetAttackPhrase(weap), defender.Name));

            // If attacker is the player character, add armor encumbrance
            Character attackerAsPlayer = attacker as Character;
            if (attackerAsPlayer != null)
            {
                int encumbrance = 0;
                int ACsqr = attackerAsPlayer.ArmorClass * attackerAsPlayer.ArmorClass;
                if (attackerAsPlayer.ArmorExpertise < ACsqr)
                {
                    encumbrance = attackerAsPlayer.ArmorExpertise - ACsqr;
                }
                hitChance += encumbrance;

                WeaponAttackType weapData = (WeaponAttackType)weap;
                if (weapData != null)
                {
                    hitChance += attackerAsPlayer.WeaponSkills[weapData.Type];
                    int weaponOdds = weapData.Complexity;
                    if (weaponOdds > 30)
                    {
                        weaponOdds = 30;
                    }
                    hitChance += weaponOdds / 2;
                }
            }
            int hitRoll = rand.Next(100);
            if ((weap is WeaponAttackType) && hitRoll > 97)
            {
                Logger.Write("\nFUMBLE!");
                var fumbleRoll = rand.Next(100);
                if (fumbleRoll <= 40)
                {
                    Logger.Write(" Fumble recovered!");
                }
                else if (fumbleRoll <= 80)
                {
                    Logger.Write(" Weapon dropped!");
                    var fumbleWeap = attacker.DropWeapon();
                    currentRoom.Items.Add(fumbleWeap);
                    fumbleWeap.DoDrop();
                }
                else if (fumbleRoll <= 95)
                {
                    Logger.Write(" Weapon broken!");
                    var fumbleWeap = attacker.DropWeapon();
                }
                else
                {
                    Logger.Write(" Weapon broken! Broken weapon hurts user!");
                    var fumbleWeap = attacker.DropWeapon();
                    int damage = DamageRoll(fumbleWeap.Attack.AttackDice);

                    attacker.TakeDamage(damage);

                    Logger.Write(String.Format("\n{0} is {1}", attacker.Name, attacker.GetStatus()));
                }
            }
            else if (hitRoll < 5 || hitRoll < hitChance)
            {
                int damage = DamageRoll(weap.AttackDice);
                Logger.Write("\nA HIT!!!");

                // Armor absorption
                // armor  class  absorption
                // -----  -----  ----------
                //None      0         0
                //Shield    1         1
                //Leather   2         1
                //Chain     4         3
                //Plate     6         5
                //Magic     8         7
                int armorAbsorb = defender.ArmorClass;
                if (defender.ArmorClass > 1)
                {
                    armorAbsorb = defender.ArmorClass - 1;
                }
                damage -= armorAbsorb;
                if (damage < 0)
                {
                    damage = 0;
                }

                defender.TakeDamage(damage);

                // If player, check for armor expertise increase
                // and weapon skill increase
                if (attackerAsPlayer != null)
                {
                    int ACsqr = attackerAsPlayer.ArmorClass * attackerAsPlayer.ArmorClass;
                    if (attackerAsPlayer.ArmorExpertise < ACsqr)
                    {
                        if (rand.Next(65) < ACsqr - attackerAsPlayer.ArmorExpertise)
                        {
                            attackerAsPlayer.ArmorExpertise += 2;
                        }
                    }
                    WeaponAttackType weapData = (WeaponAttackType)weap;
                    if (weapData != null)
                    {
                        if (rand.Next(100) > hitChance)
                        {
                            attackerAsPlayer.WeaponSkills[weapData.Type] += 2;
                        }
                    }
                }
            }
            else
            {
                Logger.WriteLn("\nA Miss!");
            }

            // If the defender is a creature in the room and it died, remove it
            if (currentRoom.Creatures.Exists(c => c.ID == defender.ID) && defender.HP == 0 && defender is Monster)
            {
                currentRoom.Creatures.Remove((Monster)defender);
            }
            // If the attacker is a creature in the room and it died (i.e., from broken weapon), remove it
            if (currentRoom.Creatures.Exists(c => c.ID == attacker.ID) && attacker.HP == 0 && defender is Monster)
            {
                currentRoom.Creatures.Remove((Monster)attacker);
            }

        }

        private string GetAttackPhrase(AttackType weap)
        {
            string[] phrases = weap.AttackPhrases;
            if (weap.AttackPhrases == null || weap.AttackPhrases.Length == 0)
            {
                if (weap is WeaponAttackType)
                {
                    phrases = MainHallConfig.Instance.defaultAttackPhrases[((WeaponAttackType)weap).Type];
                }
                else
                {
                    phrases = MainHallConfig.Instance.defaultNaturalAttackPhrases;
                }
            }
            int phraseIndex = rand.Next(phrases.Count());
            return phrases[phraseIndex];
        }
    }
}

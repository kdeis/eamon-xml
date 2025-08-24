using System;

namespace Adventure
{
    public interface ICreature
    {
        int Agility { get; set; }
        int ArmorClass { get; set; }
        int Hardiness { get; set; }
        int HP { get; set; }
        int ID { get; set; }
        AttackType GetWeapon();
        weaponData DropWeapon();
        void TakeDamage(int damage);
        string Name { get; set; }
        string GetStatus();
        event EventHandler onWound;
        event EventHandler onKill;
    }
}

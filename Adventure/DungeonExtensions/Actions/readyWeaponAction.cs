using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure;
using Adventure.Dungeon;

public partial class readyWeaponAction
{
    weaponData Weapon;
    public readyWeaponAction()
    {
    }

    public readyWeaponAction(weaponData w, string theText)
    {
        Weapon = w;
        text = text;
        weaponItemId = w.id;
    }

    public override void Initialize(DungeonData dungeonData, Dictionary<int, Monster> MonsterList)
    {
        // If this instance was deserialized, we need to get the Item object from the deserialized itemId.
        if (Weapon == null)
        {
            Weapon = (weaponData)dungeonData.ItemList.First(i => { return i.id == weaponItemId; });
            Context.Instance.Player.ReadyWeap = Weapon;
        }
    }

    public override void Execute()
    {
        base.Execute();
        Context.Instance.Player.ReadyWeap = Weapon;
    }
}

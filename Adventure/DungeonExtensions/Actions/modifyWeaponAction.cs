using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure;
using Adventure.Dungeon;

public partial class modifyWeaponAction
{
    public modifyWeaponAction()
    {
    }

    public modifyWeaponAction(int theWeapon, string theText)
    {
        text = theText;
        id = theWeapon;
    }

    public override void Execute()
    {
        base.Execute();

        // If player has the item, remove it from inventory
        itemType item = Context.Instance.Player.Items.Find((i) => i.id == id);
        if (item == null)
        {
            // Search rooms and monsters for it
            bool found = false;
            foreach (IRoom r in Context.Instance.rooms.Values)
            {
                // If the item is in the room, remove it
                item = r.Items.Find((i) => i.id == id);
                if (item != null)
                {
                    found = true;
                }
                else
                {
                    // If a monster in the room has the item, remove it from its inventory
                    foreach (Monster m in r.Creatures)
                    {
                        item = m.Items.Find((i) => i.id == id);
                        if (item != null)
                        {
                            found = true;
                        }
                        if (found) break;
                    }
                }
                if (found) break;
            }
        }

        if (item != null)
        {
            weaponData w = item as weaponData;
            if (w != null)
            {
                w.Attack.AttackDice = damage;
                if (!string.IsNullOrEmpty(description))
                {
                    w.description = description;
                }
            }
        }
    }
}

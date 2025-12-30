using Adventure;
using Adventure.Dungeon;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class destroyItemAction
{
    public destroyItemAction()
    {
    }

    public destroyItemAction(int theItem, string theText)
    {
        text = theText;
        id = theItem;
    }

    public override void Execute()
    {
        base.Execute();

        // If player has the item, remove it from inventory
        bool found = removeItemFromList(Context.Instance.Player.Items);
        if (!found)
        {
            // Search rooms and monsters for it
            foreach (IRoom r in Context.Instance.rooms.Values)
            {
                // If the item is in the room, remove it
                found = removeItemFromList(r.Items);
                if (!found)
                {
                    // If a monster in the room has the item, remove it from its inventory
                    foreach (Monster m in r.Creatures)
                    {
                        found = removeItemFromList(m.Items);
                        if (found) break;
                    }
                }
                if (found) break;
            }
        }
    }

    private bool removeItemFromList(List<itemType> items)
    {
        bool found = false;
        foreach (itemType i in items)
        {
            if (i.id == id)
            {
                items.Remove(i);
                found = true;
            }
            else if (i.storage != null)
            {
                found = removeItemFromList(i.storage.ContentsList);
            }
            if (found) break;
        }

        return found;
    }
}

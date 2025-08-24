using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure;
using Adventure.Dungeon;

public partial class destroyItemAction
{
    public destroyItemAction()
    {
    }

    public destroyItemAction(int theItem, String theText)
    {
        text = theText;
        id = theItem;
    }

    public override void Execute()
    {
        Logger.WriteLn(text);

        // If player has the item, remove it from inventory
        itemType item = Context.Instance.Player.Items.Find((i) => i.id == id);
        if (item != null)
        {
            Context.Instance.Player.Items.Remove(item);
        }
        else
        {
            // Search rooms and monsters for it
            bool found = false;
            foreach (IRoom r in Context.Instance.rooms.Values)
            {
                // If the item is in the room, remove it
                item = r.Items.Find((i) => i.id == id);
                if (item != null)
                {
                    r.Items.Remove(item);
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
                            m.Items.Remove(item);
                            found = true;
                        }
                        if (found) break;
                    }
                }
                if (found) break;
            }
        }
    }
}

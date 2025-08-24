using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure;
using Adventure.Dungeon;

public partial class revealItemAction
{
    itemType Item = null;
    public revealItemAction()
    {
    }

    public revealItemAction(itemType i, String theText, String inRoomId)
    {
        Item = i;
        text = text;
        roomId = inRoomId;
    }

    public override void Initialize(DungeonData dungeonData, Dictionary<int, Monster> MonsterList)
    {
        // If this instance was deserialized, we need to get the Item object from the deserialized itemId.
        if (Item == null)
        {
            Item = dungeonData.ItemList.First(i => { return i.id == itemId; });
        }
    }

    public override void Execute()
    {
        if (!Item.revealed)
        {
            Logger.WriteLn(text);
            Context.Instance.GetRoom(roomId).Items.Add(Item);
            Item.revealed = true;
        }
    }
}

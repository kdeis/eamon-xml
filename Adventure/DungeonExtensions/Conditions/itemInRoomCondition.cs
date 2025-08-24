using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure;
using Adventure.Dungeon;

public partial class itemInRoomCondition
{
    itemType Item = null;
    public itemInRoomCondition()
    {
    }

    public itemInRoomCondition(itemType item, String inRoomId)
    {
        Item = item;
        roomId = inRoomId;
    }

    public override void Initialize(DungeonData dungeonData, Dictionary<int, Monster> MonsterList)
    {
        // If this instance was deserialized, we need to get the Item object from the deserialized id.
        if (Item == null)
        {
            Item = dungeonData.ItemList.First((i) => i.id == itemId);
        }
    }
    public override bool TestCondition()
    {
        return Context.Instance.GetRoom(roomId).Items.Contains(Item);
    }
}

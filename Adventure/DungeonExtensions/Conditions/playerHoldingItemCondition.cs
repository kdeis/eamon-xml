using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure;
using Adventure.Dungeon;

public partial class playerHoldingItemCondition
{
    itemType Item = null;
    public playerHoldingItemCondition()
    {
    }

    public playerHoldingItemCondition(itemType item)
    {
        Item = item;
    }

    public override void Initialize(DungeonData dungeonData, Dictionary<int, Monster> MonsterList)
    {
        // If this instance was deserialized, we need to get the Creature object from the deserialized id.
        if (Item == null)
        {
            Item = dungeonData.ItemList[itemId];
        }
    }
    public override bool TestCondition()
    {
        return Context.Instance.Player.Items.Contains(Item);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure;
using Adventure.Dungeon;

public partial class openStorageAction
{
    itemType Item = null;
    public openStorageAction()
    {
    }

    public openStorageAction(itemType i, String theText)
    {
        Item = i;
        text = text;
    }

    public override void Initialize(DungeonData dungeonData, Dictionary<int, Monster> MonsterList)
    {
        // If this instance was deserialized, we need to get the Item object from the deserialized itemId.
        if (Item == null)
        {
            Item = dungeonData.ItemList.First(i => { return i.id == storageItemId; });
            if (Item.storage == null)
            {
                throw new NullReferenceException(String.Format("Item id {0} storage is null", storageItemId));
            }
        }
    }

    public override void Execute()
    {
        if (!Item.storage.isOpen)
        {
            Logger.WriteLn(text);
            Item.storage.isOpen = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class storageType
{
    public List<itemType> ContentsList = new List<itemType>();

    public bool Add(itemType toPut)
    {
        bool retVal = false;
        int totWeight = toPut.weight + getWeight();

        if (totWeight <= maxWeight)
        {
            ContentsList.Add(toPut);
            Contents = ContentsList.Select<itemType, int>((item, id) => item.id).ToArray();
            retVal = true;
        }
        return retVal;
    }

    public void Remove(itemType toRemove)
    {
        ContentsList.Remove(toRemove);
        Contents = ContentsList.Select<itemType, int>((item, id) => item.id).ToArray();
    }

    internal void InitializeContents(DungeonData dungeonData)
    {
        if (Contents != null)
        {
            foreach (int i in Contents)
            {
                ContentsList.Add(dungeonData.ItemList.First(item => item.id == i));
            }
        }
    }

    public int getWeight()
    {
        int totWeight = 0;
        foreach (itemType item in ContentsList)
        {
            totWeight += item.weight;
        }

        return totWeight;
    }
}

using System;
using System.Collections.Generic;

namespace Adventure.Dungeon
{
    public interface IRoom
    {
        string Description { get; set; }
        ExitRooms Exits { get; set; }
        string Name { get; }
        string Title { get; }
        string ShortDescription { get; set; }
        bool FirstLook { get; set; }
        bool Light { get; set; }
        List<Monster> Creatures { get; set; }
        List<itemType> Items { get; set; }
        void DoFirstVisitIfNeeded();
        void DoEachVisit();
        void DoExamine();
        void DoMagicWord(string word);
        bool DoPower();
    }
}

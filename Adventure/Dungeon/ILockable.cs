using System;

namespace Adventure.Dungeon
{
    internal interface ILockable
    {
        string KeyItemAction { get; }
        string KeyItemId { get; }
        string ToggleLock();
        string Lock();
        string Unlock();
    }
}

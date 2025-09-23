using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure;

public partial class itemType
{
    public event EventHandler onBlast;

    public event EventHandler onGet;

    public event EventHandler onDrop;

    public event EventHandler onExamine;

    public event EventHandler onPower;

    public event EventHandler onDrink;

    public event EventHandler<StringEventArgs> onMagicWord;

    public event EventHandler<IntegerEventArgs> onPut;

    public event EventHandler onRead;

    public event EventHandler onUse;

    public event EventHandler onOpen;

    public event EventHandler onClose;

    public event EventHandler onWear;

    public event EventHandler onRemove;

    public bool isLit { get; set; }

    public int Weight
    {
        get
        {
            int total = weight;
            if (storage != null)
            {
                total += storage.getWeight();
            }
            return total;
        }
    }
    public virtual void Initialize(DungeonData dungeonData)
    {
        if (storage != null)
        {
            storage.InitializeContents(dungeonData);
        }
    }

    public bool DoBlast()
    {
        if (onBlast != null)
        {
            onBlast(this, EventArgs.Empty);
            return true;
        }
        return false;
    }

    public void DoGet()
    {
        onGet?.Invoke(this, EventArgs.Empty);
    }

    public void DoDrop()
    {
        onDrop?.Invoke(this, EventArgs.Empty);
    }

    public void DoExamine()
    {
        onExamine?.Invoke(this, EventArgs.Empty);
    }

    public void DoMagicWord(string word)
    {
        onMagicWord?.Invoke(this, new StringEventArgs(word));
    }

    public void DoPut(int containerId)
    {
        onPut?.Invoke(this, new IntegerEventArgs(containerId));
    }

    public bool DoPower()
    {
        if (onPower != null)
        {
            onPower(this, EventArgs.Empty);
            return true;
        }
        return false;
    }

    public bool HasDrinkEvent()
    {
        return onDrink != null;
    }

    public void DoDrink()
    {
        onDrink?.Invoke(this, EventArgs.Empty);
    }

    public bool HasUseEvent()
    {
        return onUse != null;
    }

    public void DoUse()
    {
        onUse?.Invoke(this, EventArgs.Empty);
    }

    public bool HasReadEvent()
    {
        return onRead != null;
    }

    public void DoRead()
    {
        onRead?.Invoke(this, EventArgs.Empty);
    }
    public bool HasOpenEvent()
    {
        return onOpen != null;
    }
    public void DoOpen()
    {
        onOpen?.Invoke(this, EventArgs.Empty);
    }
    public bool HasCloseEvent()
    {
        return onClose != null;
    }
    public void DoClose()
    {
        onClose?.Invoke(this, EventArgs.Empty);
    }
    public void DoWear()
    {
        onWear?.Invoke(this, EventArgs.Empty);
    }
    public void DoRemove()
    {
        onRemove?.Invoke(this, EventArgs.Empty);
    }

}

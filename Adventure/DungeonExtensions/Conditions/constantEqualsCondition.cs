using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure;
using Adventure.Dungeon;

public partial class constantEqualsCondition
{
    public constantEqualsCondition()
    {
    }

    public constantEqualsCondition(String theName, String theValue)
    {
        name = theName;
        value = theValue;
    }

    public override bool TestCondition()
    {
        return Context.Instance.Constants.ContainsKey(name) && Context.Instance.Constants[name] == value;
    }
}

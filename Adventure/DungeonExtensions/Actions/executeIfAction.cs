using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure;
using Adventure.Dungeon;

public partial class executeIfAction
{
    public executeIfAction()
    {
    }

    public executeIfAction(string theText, conditionType theCondition, List<actionType> theActions)
    {
        text = theText;
        condition = theCondition;
        action = theActions.ToArray();
    }

    public override void Initialize(DungeonData dungeonData, Dictionary<int, Monster> MonsterList)
    {
        condition.Initialize(dungeonData, MonsterList);
        foreach (actionType a in action)
        {
            a.Initialize(dungeonData, MonsterList);
        }
    }
    public override void Execute()
    {
        if (!string.IsNullOrEmpty(text))
        {
            Logger.WriteLn(text);
            Logger.WriteLn();
        }
        if (condition.TestCondition())
        {
            foreach (actionType a in action)
            {
                a.Execute();
            }
        }
        else if (elseAction != null)
        {
            foreach (actionType a in elseAction)
            {
                a.Execute();
            }
        }
    }
}

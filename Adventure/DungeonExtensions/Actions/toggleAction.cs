using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure;
using Adventure.Dungeon;

public partial class toggleAction
{
    int nextAction = 0;
    List<actionType> Actions = new List<actionType>();
    public toggleAction()
    {
    }

    public toggleAction(string theText, List<actionType> theActions)
    {
        text = text;
        action = theActions.ToArray();
    }

    public override void Initialize(DungeonData dungeonData, Dictionary<int, Monster> MonsterList)
    {
        //TODO:  Initialize the list of actions.
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
        action[nextAction].Execute();
        nextAction++;
        if (nextAction >= action.Length)
            nextAction = 0;
    }
}

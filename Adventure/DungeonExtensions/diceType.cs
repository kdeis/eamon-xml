using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class diceType
{
    private static Random rand = new Random();

    public int Roll()
    {
        int rollResult = 0;
        for (int i = 0; i < Count; i++)
        {
            rollResult += rand.Next(Sides - 1) + 1;
        }
        rollResult += Plus;
        return rollResult;
    }

}

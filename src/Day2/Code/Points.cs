using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2.Code;

/*
 * Originally added a bit more complex point system because I was pretty sure that's going to be a thing in part 2.
 * I was wrong.
*/
public interface IPoints
{
    public int VictoryValue { get; }
    public int DefeatValue { get; }
    public int TieValue { get; }
}

public record Points : IPoints
{
    public int VictoryValue { get; }
    public int DefeatValue { get; }
    public int TieValue { get; }

    public Points(int victoryValue, int defeatValue, int tieValue)
    {
        VictoryValue = victoryValue;
        DefeatValue = defeatValue;
        TieValue = tieValue;
    }
}


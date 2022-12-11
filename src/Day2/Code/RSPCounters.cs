using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2.Code
{
    public record RSPCounters
    {
        public static RockPaperScissor CounterPick(RockPaperScissor opponentsPick, GameConditions condition)
        {
            if (opponentsPick == RockPaperScissor.Rock)
            {
                if (condition == GameConditions.Win)
                    return RockPaperScissor.Paper;

                else if (condition == GameConditions.Defeat)
                    return RockPaperScissor.Scissor;

                else
                    return RockPaperScissor.Rock;
            }

            else if (opponentsPick == RockPaperScissor.Paper)
            {
                if (condition == GameConditions.Win)
                    return RockPaperScissor.Scissor;

                else if (condition == GameConditions.Defeat)
                    return RockPaperScissor.Rock;

                else
                    return RockPaperScissor.Paper;
            }

            else
            {
                if (condition == GameConditions.Win)
                    return RockPaperScissor.Rock;

                else if (condition == GameConditions.Defeat)
                    return RockPaperScissor.Paper;

                else
                    return RockPaperScissor.Scissor;
            }
        }
    }
}

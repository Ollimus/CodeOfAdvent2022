using Day2.Code;
using System.Runtime.Serialization;

#region part1
/*
 * A = Rock
 * B = Paper
 * C = Scissors
 * 
 * X = Rock
 * Y = Paper
 * Z = Scissors
*/
List<KeyValuePair<char, RockPaperScissor>> decryptionCodes = new List<KeyValuePair<char, RockPaperScissor>>()
{
    //Rock
    new KeyValuePair<char, RockPaperScissor>(key: 'A', value: RockPaperScissor.Rock ),
    new KeyValuePair<char, RockPaperScissor>(key: 'X', value: RockPaperScissor.Rock ),

    // Paper
    new KeyValuePair<char, RockPaperScissor>(key: 'B', value: RockPaperScissor.Paper ),
    new KeyValuePair<char, RockPaperScissor>(key: 'Y', value: RockPaperScissor.Paper ),

    // Scissor
    new KeyValuePair<char, RockPaperScissor>(key: 'C', value: RockPaperScissor.Scissor ),
    new KeyValuePair<char, RockPaperScissor>(key: 'Z', value: RockPaperScissor.Scissor ),
};

// 6 for winning, 0 for losing, 3 for tie.
Points points = new Points(victoryValue: 6, defeatValue: 0, tieValue: 3);

int playerScore = 0;

foreach (var line in File.ReadAllLines("./PuzzleInput.dat"))
{
    // Since the input is always in format of "X Y", we know the locaitons of both players' picks.
    var opponentRPSChoice = line[0];
    var myRPSChoice = line[2];

    // Decrypt chosen picks.
    var opponentPick = decryptionCodes.First(x => x.Key == opponentRPSChoice).Value;
    var myPick = decryptionCodes.First(x => x.Key == myRPSChoice).Value;

    // Adding the points according to the pick.
    playerScore += (int)myPick;

    // If both picks are the same, it is a draw. Otherwise check for other values.
    if (opponentPick != myPick)
    {
        if (opponentPick == RockPaperScissor.Rock)
        {
            if (myPick == RockPaperScissor.Paper)
                playerScore += points.VictoryValue;

            else
                playerScore -= points.DefeatValue;
        }

        else if (opponentPick == RockPaperScissor.Paper)
        {
            if (myPick == RockPaperScissor.Scissor)
                playerScore += points.VictoryValue;

            else
                playerScore -= points.DefeatValue;
        }

        else
        {
            if (myPick == RockPaperScissor.Rock)
                playerScore += points.VictoryValue;

            else
                playerScore -= points.DefeatValue;
        }
    }

    // Draw
    else
        playerScore += points.TieValue;
}

Console.WriteLine($"Part 1");
Console.WriteLine($"Final score is: {playerScore}");
Console.WriteLine("------------");

#endregion

#region part2
/*
 * A = Rock
 * B = Paper
 * C = Scissors
 * 
 * X = Lose
 * Y = Draw
 * Z = Win
*/

var opponentPicks = new List<KeyValuePair<char, RockPaperScissor>>()
{
    new KeyValuePair<char, RockPaperScissor>(key: 'A', value: RockPaperScissor.Rock ),
    new KeyValuePair<char, RockPaperScissor>(key: 'B', value: RockPaperScissor.Paper ),
    new KeyValuePair<char, RockPaperScissor>(key: 'C', value: RockPaperScissor.Scissor ),
};

var yourStrategy = new List<KeyValuePair<char, GameConditions>>()
{
    new KeyValuePair<char, GameConditions>(key: 'X', value: GameConditions.Defeat ),
    new KeyValuePair<char, GameConditions>(key: 'Y', value: GameConditions.Draw ),
    new KeyValuePair<char, GameConditions>(key: 'Z', value: GameConditions.Win )
};

//var tactics = new List<KeyValuePair<char, string>>()

// 6 for winning, 0 for losing, 3 for tie.
points = new Points(victoryValue: 6, defeatValue: 0, tieValue: 3);

playerScore = 0;

foreach (var line in File.ReadAllLines("./PuzzleInput.dat"))
{
    // Since the input is always in format of "X Y", we know the locaitons of both players' picks.
    var opponentRPSChoice = line[0];
    var myRPSChoice = line[2];

    // Decrypt chosen picks.
    var opponentPick = decryptionCodes.First(x => x.Key == opponentRPSChoice).Value;
    var yourGameCondition = yourStrategy.First(x => x.Key == myRPSChoice).Value;

    var pick = RSPCounters.CounterPick(opponentPick, yourGameCondition);

    playerScore += (int)pick; // Pick SCore
    playerScore += (int)yourGameCondition; // Points for win/draw/Defaet
}

Console.WriteLine($"Part 2");
Console.WriteLine($"Final score is: {playerScore}");
Console.WriteLine("------------");
#endregion
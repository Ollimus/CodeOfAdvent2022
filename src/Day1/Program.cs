var text = File.ReadAllText("./PuzzleInput.dat");

#region part1
var highestSum = text.Split("\r\n\r\n")
    .Select(x => x
        .Split("\r\n")
        .Where(x => x != "")
        .Select(x => int.Parse(x))
        .Sum()
    ).Max();

Console.WriteLine($"Part 1");
Console.WriteLine($"Highest calorie count is : {highestSum}");
Console.WriteLine($"-------------");
#endregion

#region part2
var sumOfThreeHighest = text.Split("\r\n\r\n")
    .Select(e =>
        e.Split("\r\n")
        .Where(x => x != "")
        .Select(x => int.Parse(x))
        .Sum())
    .OrderByDescending(x => x)
    .Take(3)
    .ToList()
    .Sum();

Console.WriteLine($"Part 2");
Console.WriteLine($"Combined calorie count is: {sumOfThreeHighest}");
#endregion
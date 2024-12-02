namespace AdventOfCode2024.Day1_1;

public class Calculator
{
    public static void Run1()
    {
        var input = new InputReader().Read();

        // Sort
        input.Left.Sort();
        input.Right.Sort();

        // Make pairs
        var pairs = input.Left.Select((x, index) => new Pair
        {
            Left = x,
            Right = input.Right[index],
        }).ToArray();

        var sum = pairs.Sum(x => x.Difference);

        Console.WriteLine($"Day 1_1: {sum}");
    }

    public static void Run2()
    {
        var input = new InputReader().Read();

        var referenceDict = input.Left.ToDictionary(x => x, x => 0);
        input.Right.ForEach(x =>
        {
            if (!referenceDict.ContainsKey(x))
                return;

            referenceDict[x]++;
        });

        var total = 0;

        foreach (var (key, value) in referenceDict)
        {
            total += key * value;
        }

        Console.WriteLine($"Day 1_2: {total}");
    }
}

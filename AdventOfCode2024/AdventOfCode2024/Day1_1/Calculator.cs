namespace AdventOfCode2024.Day1_1;

public class Calculator
{
    public static void Run()
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
}

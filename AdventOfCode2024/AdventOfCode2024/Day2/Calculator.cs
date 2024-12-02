namespace AdventOfCode2024.Day2;

public class Calculator
{
    public static void Run1()
    {
        var input = InputReader.Read();

        var valid = input.Count(x => x.IsValid());

        Console.WriteLine($"Day 2_1: {valid}");
    }

    public static void Run2()
    {
        var input = InputReader.Read();

        var valid = input.Count(x => x.IsValidDampened());

        Console.WriteLine($"Day 2_2: {valid}");
    }
}

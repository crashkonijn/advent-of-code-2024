namespace AdventOfCode2024.Day5;

public class Calculator
{
    public static void Run1()
    {
        var input = InputReader.Read();

        var validRules = input.Lines.Where(x => input.IsValid(x)).ToArray();
        var total = validRules.Sum(x => x.Center);

        Console.WriteLine($"Day 5_1: {total}");
    }

    public static void Run2()
    {
        var input = InputReader.Read();

        var invalidRules = input.Lines.Where(x => !input.IsValid(x)).ToArray();

        foreach (var invalidRule in invalidRules)
        {
            invalidRule.Sort(input);
        }

        var total = invalidRules.Sum(x => x.Center);

        Console.WriteLine($"Day 5_2: {total}");
    }
}

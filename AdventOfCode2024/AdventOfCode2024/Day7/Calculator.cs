namespace AdventOfCode2024.Day7;

public class Calculator
{
    public static void Run1()
    {
        var data = InputReader.Read();

        var result = data.Calculations
            .Where(calc => data.IsValid(calc).IsValid)
            .Sum(calc => calc.Result);

        Console.WriteLine($"Day 7_1: {result}");
    }

    public static void Run2()
    {
        var data = InputReader.Read();

        var result = data.Calculations
            .Where(calc => data.IsValid2(calc).IsValid)
            .Sum(calc => calc.Result);

        Console.WriteLine($"Day 7_2: {result}");
    }
}

namespace AdventOfCode2024.Day3;

public static class Calculator
{
    public static void Run1()
    {
        var input = InputReader.Read();

        var sum = input.Sum(x => x.Result);

        Console.WriteLine($"Day 3_1: {sum}");
    }

    public static void Run2()
    {
        var input = InputReader.Read2();

        var sum = input.Sum(x => x.Result);

        Console.WriteLine($"Day 3_2: {sum}");
    }
}

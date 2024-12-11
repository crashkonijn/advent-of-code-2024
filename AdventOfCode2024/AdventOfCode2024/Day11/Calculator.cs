namespace AdventOfCode2024.Day11;

public class Calculator
{
    public static void Run1()
    {
        var data = InputReader.Read();

        data.Simulate(25);

        Console.WriteLine($"Day 11_1: {data.GetCount()}");
    }

    public static void Run2()
    {
        var data = InputReader.Read();

        data.Simulate(75);

        Console.WriteLine($"Day 11_2: {data.GetCount()}");
    }
}

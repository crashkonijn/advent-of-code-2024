namespace AdventOfCode2024.Day6;

public class Calculator
{
    public static void Run1()
    {
        var world = InputReader.Read();

        world.Simulate();

        var total = world.GetTotalVisited();

        Console.WriteLine($"Day 6_1: {total}");
    }

    public static void Run2()
    {
        var world = InputReader.Read();

        world.Simulate(true);

        var total = world.GetLoops();

        Console.Write("\r{0}   ", $"Day 6_2: {total.Length}");
    }

    public static void Run2J()
    {
        var world = InputReader.ReadJustin();

        world.Simulate(true);

        var total = world.GetLoops();

        Console.Write("\r{0}   ", $"Day 6_2: {total.Length}");
    }
}

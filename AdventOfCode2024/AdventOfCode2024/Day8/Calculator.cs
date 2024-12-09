namespace AdventOfCode2024.Day8;

public class Calculator
{
    public static void Run1()
    {
        var map = InputReader.Read();

        map.Compute();

        var total = map.AntiNodes.Count;

        Console.WriteLine($"Day 8_1: {total}");
    }
    
    public static void Run2()
    {
        var map = InputReader.Read();

        map.Compute2();

        var total = map.AntiNodes.Count;

        Console.WriteLine($"Day 8_2: {total}");
    }
}

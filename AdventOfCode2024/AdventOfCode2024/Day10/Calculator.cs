namespace AdventOfCode2024.Day10;

public class Calculator
{
    public static void Run1()
    {
        var map = InputReader.Read();

        map.Compute();

        var score = map.GetTrailheadScore();

        Console.WriteLine($"Day 10_1: {score}");
    }
    
    public static void Run2()
    {
        var map = InputReader.Read();

        map.Compute();

        var score = map.GetTrailheadRating();

        Console.WriteLine($"Day 10_2: {score}");
    }
}

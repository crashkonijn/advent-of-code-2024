namespace AdventOfCode2024.Day4;

public class Calculator
{
    public static void Run1()
    {
        var input = InputReader.Read();

        var total = input.GetTotalXmas();

        Console.WriteLine($"Day 4_1: {total}");
    }

    public static void Run2()
    {
        var input = InputReader.Read();

        var total = input.GetTotalMas();

        Console.WriteLine($"Day 4_2: {total}");
    }
}

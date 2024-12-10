namespace AdventOfCode2024.Day9;

public class Calculator
{
    public static void Run1()
    {
        var disk = InputReader.Read();

        disk.Compress();

        var checksum = disk.GetChecksum();

        Console.WriteLine($"Day 9_1: {checksum}");
    }

    public static void Run2()
    {
        var disk = InputReader.Read();

        disk.CompressLarge();

        var checksum = disk.GetChecksum();

        Console.WriteLine($"Day 9_2: {checksum}");
    }
}

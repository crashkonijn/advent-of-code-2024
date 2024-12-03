namespace AdventOfCode2024.Day3;

public static class Calculator
{
    public static void Run1()
    {
        var input = InputReader.Read();
        
        var sum = input.Sum(x => x.Result);
    }
}

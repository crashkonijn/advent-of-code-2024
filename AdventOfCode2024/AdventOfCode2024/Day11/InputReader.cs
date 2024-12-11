using AdventOfCode2024.Common;

namespace AdventOfCode2024.Day11;

public class InputReader
{
    public static Data Read()
    {
        var lines = FileReader.ReadLines("Day11\\input.txt");

        return Read(lines[0]);
    }

    public static Data Read(string line)
    {
        var data = new Data();

        foreach (var number in line.Split(" "))
        {
            data.AddStone(long.Parse(number), 1);
        }

        return data;
    }
}

public class Data
{
    public Dictionary<long, long> Stones = new();

    public void AddStone(long number, long count)
    {
        if (!this.Stones.TryAdd(number, count))
        {
            this.Stones[number] += count;
        }
    }

    public void Simulate(int count)
    {
        for (var i = 0; i < count; i++)
        {
            this.Step(i);
        }
    }

    public void Step(int step = 0)
    {
        var stones = new Dictionary<long, long>(this.Stones);
        this.Stones = new Dictionary<long, long>();

        foreach (var stone in stones)
        {
            this.Step(stone.Key, stone.Value);
        }
    }

    public void Step(long number, long count)
    {
        if (number == 0)
        {
            this.Handle0Rule(number, count);
            return;
        }

        if (number.ToString().Length % 2 == 0)
        {
            this.HandleEvenRule(number, count);
            return;
        }

        this.HandleMultiplyRule(number, count);
    }

    private void Handle0Rule(long number, long count)
    {
        this.AddStone(1, count);
    }

    private void HandleEvenRule(long number, long count)
    {
        var stringNumber = number.ToString();
        var length = stringNumber.Length;
        var leftNumber = long.Parse(stringNumber.Substring(0, length / 2));
        var rightNumber = long.Parse(stringNumber.Substring(length / 2));

        this.AddStone(leftNumber, count);
        this.AddStone(rightNumber, count);
    }

    private void HandleMultiplyRule(long number, long count)
    {
        this.AddStone(number * 2024, count);
    }

    public long GetCount()
    {
        return this.Stones.Sum(stone => stone.Value);
    }
}

public class Stone
{
    public long Number { get; set; }
    public bool HasEvenNumberOfDigits => this.Number.ToString().Length % 2 == 0;
}

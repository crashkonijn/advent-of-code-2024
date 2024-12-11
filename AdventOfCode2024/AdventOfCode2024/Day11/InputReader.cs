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
            data.Stones.Add(new Stone
            {
                Number = int.Parse(number),
            });
        }

        return data;
    }
}

public class Data
{
    public List<Stone> Stones { get; set; } = new();

    public void Simulate(int count)
    {
        for (var i = 0; i < count; i++)
        {
            this.Step(i);
        }
    }

    public void Step(int step = 0)
    {
        var length = this.Stones.Count;
        var stones = this.Stones.ToList();
        
        for (var i = 0; i < stones.Count; i++)
        {
            var percentage = (double)i / length * 100;
            
            Console.Write("\rStep: {0}: {1} / {2}  ({3}%)", step, i, length, percentage);
            this.Step(stones[i]);
        }
    }

    public void Step(Stone stone)
    {
        if (stone.Number == 0)
        {
            this.Handle0Rule(stone);
            return;
        }

        if (stone.HasEvenNumberOfDigits)
        {
            this.HandleEvenRule(stone);
            return;
        }

        this.HandleMultiplyRule(stone);
    }

    private void Handle0Rule(Stone stone)
    {
        stone.Number = 1;
    }

    private void HandleEvenRule(Stone stone)
    {
        var length = stone.Number.ToString().Length;
        var leftNumber = long.Parse(stone.Number.ToString().Substring(0, length / 2));
        var rightNumber = long.Parse(stone.Number.ToString().Substring(length / 2));

        stone.Number = rightNumber;

        var index = this.Stones.IndexOf(stone);

        this.Stones.Insert(index, new Stone
        {
            Number = leftNumber,
        });
    }

    private void HandleMultiplyRule(Stone stone)
    {
        stone.Number *= 2024;
    }

    public string GetPrint()
    {
        return string.Join(" ", this.Stones.Select(x => x.Number));
    }
}

public class Stone
{
    public long Number { get; set; }
    public bool HasEvenNumberOfDigits => this.Number.ToString().Length % 2 == 0;
}

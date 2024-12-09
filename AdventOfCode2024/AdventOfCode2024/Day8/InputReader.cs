using AdventOfCode2024.Common;

namespace AdventOfCode2024.Day8;

public class InputReader
{
    public static Map Read()
    {
        var input = FileReader.ReadLines("Day8\\input.txt");

        return Read(input);
    }

    public static Map Read(string[] input)
    {
        var map = new Map();

        var cols = input[0].Length;
        var rows = input.Length;

        map.Positions = new Position[cols, rows];

        var y = 0;
        foreach (var line in input)
        {
            var x = 0;
            foreach (var value in line)
            {
                var position = new Position
                {
                    X = x,
                    Y = y,
                    Value = value != '.' ? value : null,
                };

                map.Positions[x, y] = position;

                if (value != '.')
                    map.GetPositions(value).Add(position);

                x++;
            }

            y++;
        }

        return map;
    }
}

public class Map
{
    public Position[,] Positions { get; set; }
    public Dictionary<char, List<Position>> PositionsByValue { get; set; } = new();

    public List<Position> GetPositions(char value)
    {
        if (!this.PositionsByValue.ContainsKey(value))
            this.PositionsByValue[value] = [];

        return this.PositionsByValue[value];
    }

    public void Compute()
    {
        foreach (var key in this.PositionsByValue.Keys)
        {
            this.Compute(key);
        }
    }

    public void Compute(char value)
    {
        foreach (var posA in this.PositionsByValue[value])
        {
            foreach (var posB in this.PositionsByValue[value])
            {
                if (posA == posB)
                    continue;

                var diff = posB.GetDiff(posA);

                var pos = this.GetPosition(posA.X + diff.x, posA.Y + diff.y);

                if (pos != null)
                    pos.AntiNodes.Add(value);
            }
        }
    }

    public void Compute2()
    {
        foreach (var key in this.PositionsByValue.Keys)
        {
            this.Compute2(key);
        }
    }

    public void Compute2(char value)
    {
        foreach (var posA in this.PositionsByValue[value])
        {
            foreach (var posB in this.PositionsByValue[value])
            {
                if (posA == posB)
                    continue;

                var diff = posB.GetDiff(posA);
                var x = posA.X + diff.x;
                var y = posA.Y + diff.y;

                var pos = this.GetPosition(x, y);

                if (pos != null)
                {
                    posA.AntiNodes.Add(value);
                    posB.AntiNodes.Add(value);
                }

                while (pos != null)
                {
                    pos.AntiNodes.Add(value);

                    x += diff.x;
                    y += diff.y;
                    pos = this.GetPosition(x, y);
                }
            }
        }
    }


    public Position? GetPosition(int x, int y)
    {
        if (x < 0 || x >= this.Positions.GetLength(0) || y < 0 || y >= this.Positions.GetLength(1))
            return null;

        return this.Positions[x, y];
    }

    public List<Position> AntiNodes => this.Positions.Cast<Position>().Where(p => p.IsAntiNode).ToList();

    public void Print()
    {
        for (var y = 0; y < this.Positions.GetLength(1); y++)
        {
            for (var x = 0; x < this.Positions.GetLength(0); x++)
            {
                var pos = this.Positions[x, y];

                if (pos.Value != null)
                    Console.Write(pos.Value);
                else if (pos.IsAntiNode)
                    Console.Write("#");
                else
                    Console.Write(pos.Value ?? '.');
            }

            Console.WriteLine();
        }
    }
}

public class Position
{
    public int X { get; set; }
    public int Y { get; set; }
    public char? Value { get; set; }
    public List<char> AntiNodes { get; set; } = new();
    public bool IsAntiNode => this.AntiNodes.Count > 0;

    public (int x, int y) GetDiff(Position other)
    {
        return (other.X - this.X, other.Y - this.Y);
    }
}

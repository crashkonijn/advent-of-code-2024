using AdventOfCode2024.Common;

namespace AdventOfCode2024.Day10;

public class InputReader
{
    public static Map Read()
    {
        var lines = FileReader.ReadLines("Day10\\input.txt");

        return Read(lines);
    }

    public static Map Read(string[] lines)
    {
        var map = new Map();

        var rows = lines.Length;
        var columns = lines[0].Length;

        map.Tiles = new Tile[rows, columns];

        var y = 0;
        foreach (var line in lines)
        {
            var x = 0;
            foreach (var c in line)
            {
                map.Tiles[x, y] = new Tile
                {
                    Number = c == '.' ? -1 : int.Parse(c.ToString()),
                    X = x,
                    Y = y,
                };

                x++;
            }

            y++;
        }

        return map;
    }
}

public class Map
{
    public Tile[,] Tiles { get; set; }
    public List<Path> Paths { get; set; } = new();

    public void Compute()
    {
        foreach (var tile in this.Tiles)
        {
            this.Compute(tile);
        }
    }

    public void Compute(Tile tile)
    {
        if (tile.Number != 0)
            return;

        this.Traverse(tile, []);
    }

    private void Traverse(Tile tile, Tile[] path)
    {
        var newPath = path.Append(tile).ToArray();

        if (tile.Number == 9)
        {
            this.Paths.Add(new Path(newPath));
            return;
        }

        foreach (var neighbour in this.GetClimeableNeighbours(tile))
        {
            this.Traverse(neighbour, newPath);
        }
    }

    public Tile[] GetNeighbours(int x, int y)
    {
        var neighbours = new List<Tile>();

        if (x > 0)
            neighbours.Add(this.Tiles[x - 1, y]);

        if (x < this.Tiles.GetLength(0) - 1)
            neighbours.Add(this.Tiles[x + 1, y]);

        if (y > 0)
            neighbours.Add(this.Tiles[x, y - 1]);

        if (y < this.Tiles.GetLength(1) - 1)
            neighbours.Add(this.Tiles[x, y + 1]);

        return neighbours.ToArray();
    }

    public Tile[] GetClimeableNeighbours(Tile tile)
    {
        return this.GetNeighbours(tile.X, tile.Y).Where(x => x.Number == tile.Number + 1).ToArray();
    }

    public Tile[] GetTrailheads()
    {
        return this.Tiles.Cast<Tile>().Where(x => x.Number == 0 && x.Paths.Count > 0).ToArray();
    }

    public int GetTrailheadScore()
    {
        return this.GetTrailheads().Sum(x => x.Destinations.Length);
    }
    
    public int GetTrailheadRating()
    {
        return this.GetTrailheads().Sum(x => x.Paths.Count);
    }

    public void Print(Path path)
    {
        Console.WriteLine();

        for (var y = 0; y < this.Tiles.GetLength(1); y++)
        {
            for (var x = 0; x < this.Tiles.GetLength(0); x++)
            {
                var tile = path.Tiles.FirstOrDefault(t => t.X == x && t.Y == y);

                if (tile != null)
                    Console.Write(tile.Number);
                else
                    Console.Write(".");
            }

            Console.WriteLine();
        }
    }
}

public class Tile
{
    public int Number { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public List<Path> Paths { get; set; } = new();
    public Tile[] Destinations => this.Paths.Select(x => x.End).Distinct().ToArray();
}

public class Path
{
    public Tile Start { get; set; }
    public Tile End { get; set; }
    public Tile[] Tiles { get; set; }

    public Path(Tile[] tiles)
    {
        this.Tiles = tiles;
        this.Start = tiles.First();
        this.End = tiles.Last();

        this.Start.Paths.Add(this);
    }
}

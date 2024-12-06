using AdventOfCode2024.Common;

namespace AdventOfCode2024.Day6;

public class InputReader
{
    public static World Read()
    {
        var input = FileReader.ReadLines("Day6\\input.txt");

        return Read(input);
    }

    public static World ReadJustin()
    {
        var input = FileReader.ReadLines("Day6\\justin.txt");

        return Read(input);
    }

    public static World Read(string[] input)
    {
        var world = new World();

        var reversed = input;

        var cols = input[0].Length;
        var rows = input.Length;

        world.Tiles = new Tile[cols, rows];

        var x = 0;
        var y = 0;

        foreach (var row in reversed)
        {
            x = 0;

            foreach (var c in row)
            {
                var tile = new Tile
                {
                    X = x,
                    Y = y,
                    IsWall = c == '#',
                };

                world.Tiles[x, y] = tile;

                if (IsGuard(c))
                {
                    world.InitialDirection = GetDirection(c);
                    world.InitialPosition = tile;
                    tile.VisitedDirections.Add(world.InitialDirection);
                }

                x++;
            }

            y++;
        }

        return world;
    }

    private static bool IsGuard(char c)
    {
        return c == '^' || c == 'v' || c == '<' || c == '>';
    }

    private static Direction GetDirection(char c)
    {
        return c switch
        {
            '^' => Direction.Up,
            'v' => Direction.Down,
            '<' => Direction.Left,
            '>' => Direction.Right,
            _ => throw new Exception("Invalid direction"),
        };
    }
}

public class World
{
    public Direction InitialDirection { get; set; }
    public Tile InitialPosition { get; set; }

    public Tile[,] Tiles { get; set; }

    public void Simulate(bool includeLoops = false)
    {
        var guard = new Guard
        {
            Position = this.InitialPosition,
            Direction = this.InitialDirection,
        };

        var i = 0;
        // if (includeLoops)
        // {
        //     Console.WriteLine("");
        // }

        while (guard.Position != null)
        {
            // this.Print(guard);

            if (includeLoops)
            {
                // Console.Write("\r{0}   ", i);
                i++;
                var nextTile = this.GetNextTile(guard.Position, guard.Direction);

                if (nextTile != null && !nextTile.IsWall && nextTile != this.InitialPosition)
                {
                    nextTile.IsWall = true;

                    var (isLoop, path) = this.IsLoopPosition(guard.Position, guard.Direction);

                    if (isLoop)
                    {
                        nextTile.IsLoopPosition = true;
                        nextTile.LoopPath = path;

                        // this.Print(nextTile, guard.Position, guard.Direction);
                    }

                    if (nextTile.Postion == "75,22")
                    {
                        nextTile.IsLoopPosition = true;
                        nextTile.LoopPath = path;
                        this.Print(nextTile, guard.Position, guard.Direction);
                    }

                    nextTile.IsWall = false;
                }
            }

            this.Next(guard);

            if (guard.Position == null)
                break;

            guard.Position.VisitedDirections.Add(guard.Direction);
        }

        this.Print(guard);
    }


    private (bool, Dictionary<Tile, List<Direction>> path) IsLoopPosition(Tile tile, Direction direction)
    {
        var guard = new Guard
        {
            Position = tile,
            Direction = direction,
        };

        var visited = new Dictionary<Tile, List<Direction>>();

        List<Direction> GetVisitedList(Tile tile)
        {
            if (!visited.ContainsKey(tile))
                visited[tile] = new List<Direction>();

            return visited[tile];
        }

        GetVisitedList(tile).Add(direction);
        // visited[this.GetTurnDirection(direction)].Add(tile);


        var nextTile = this.GetNextTile(guard.Position, this.GetTurnDirection(direction));

        if (nextTile == null)
            return (false, visited);

        // if (nextTile.IsWall)
        //     return (false, visited);

        while (true)
        {
            var dir = guard.Direction;
            var pos = guard.Position;

            this.Next(guard);

            if (guard.Position == null)
                return (false, visited);

            var list = GetVisitedList(guard.Position);

            if (list.Contains(guard.Direction))
                return (true, visited);

            list.Add(guard.Direction);

            if (guard.Direction != dir)
                GetVisitedList(pos).Add(guard.Direction);

            // if (guard.Position == tile)
            //     return true;
        }
    }

    public Tile[] GetLoops()
    {
        var loops = new List<Tile>();

        foreach (var tile in this.Tiles)
        {
            if (tile.IsLoopPosition)
                loops.Add(tile);
        }

        return loops.ToArray();
    }

    private void Next(Guard guard)
    {
        var nextTile = this.GetNextTile(guard.Position, guard.Direction);

        if (nextTile == null)
        {
            guard.Position = null;
            return;
        }

        if (nextTile.IsWall)
        {
            this.Turn(guard);
            guard.Position = this.GetNextTile(guard.Position, guard.Direction);
            return;
        }

        guard.Position = nextTile;
    }

    private void Turn(Guard guard)
    {
        guard.Direction = this.GetTurnDirection(guard.Direction);
    }

    private Direction GetTurnDirection(Direction direction)
    {
        return direction switch
        {
            Direction.Up => Direction.Right,
            Direction.Down => Direction.Left,
            Direction.Left => Direction.Up,
            Direction.Right => Direction.Down,
            _ => throw new Exception("Invalid direction"),
        };
    }

    private Tile? GetNextTile(Tile tile, Direction direction)
    {
        try
        {
            var nextTile = direction switch
            {
                Direction.Up => this.Tiles[tile.X, tile.Y - 1],
                Direction.Down => this.Tiles[tile.X, tile.Y + 1],
                Direction.Left => this.Tiles[tile.X - 1, tile.Y],
                Direction.Right => this.Tiles[tile.X + 1, tile.Y],
                _ => throw new Exception("Invalid direction"),
            };

            return nextTile;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public int GetTotalVisited()
    {
        var total = 0;

        foreach (var tile in this.Tiles)
        {
            if (tile.IsVisited)
                total++;
        }

        return total;
    }

    public void Print(Guard guard)
    {
        for (var y = 0; y < this.Tiles.GetLength(0); y++)
        {
            for (var x = 0; x < this.Tiles.GetLength(1); x++)
            {
                var tile = this.Tiles[x, y];

                if (guard.Position == tile)
                {
                    switch (guard.Direction)
                    {
                        case Direction.Up:
                            Console.Write("^");
                            break;
                        case Direction.Down:
                            Console.Write("v");
                            break;
                        case Direction.Left:
                            Console.Write("<");
                            break;
                        case Direction.Right:
                            Console.Write(">");
                            break;
                    }
                }
                else if (tile.IsWall)
                    Console.Write("#");
                else if (tile.IsLoopPosition)
                    Console.Write("L");
                // else if (tile.IsVisited)
                //     Console.Write(".");
                else
                    Console.Write(".");

                Console.Write(" ");
            }

            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine();
    }

    public void Print(Tile loopedTile, Tile prevTile, Direction direction)
    {
        var lastTile = loopedTile.LoopPath.Keys.Last();

        for (var y = 0; y < this.Tiles.GetLength(0); y++)
        {
            for (var x = 0; x < this.Tiles.GetLength(1); x++)
            {
                var tile = this.Tiles[x, y];

                if (tile == prevTile)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    switch (direction)
                    {
                        case Direction.Up:
                            Console.Write("^");
                            break;
                        case Direction.Down:
                            Console.Write("v");
                            break;
                        case Direction.Left:
                            Console.Write("<");
                            break;
                        case Direction.Right:
                            Console.Write(">");
                            break;
                    }

                    Console.ResetColor();
                }
                else if (tile == loopedTile)
                    Console.Write("L");
                else if (tile == lastTile)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("X");
                    Console.ResetColor();
                }
                else if (loopedTile.LoopPath.ContainsKey(tile))
                {
                    var horizontal = loopedTile.LoopPath[tile].Contains(Direction.Left) || loopedTile.LoopPath[tile].Contains(Direction.Right);
                    var vertical = loopedTile.LoopPath[tile].Contains(Direction.Up) || loopedTile.LoopPath[tile].Contains(Direction.Down);

                    if (horizontal && vertical)
                        Console.Write("+");
                    else if (horizontal)
                    {
                        if (loopedTile.LoopPath[tile].Contains(Direction.Left) && loopedTile.LoopPath[tile].Contains(Direction.Right))
                            Console.Write("+");
                        else if (loopedTile.LoopPath[tile].Contains(Direction.Left))
                            Console.Write("<");
                        else
                            Console.Write(">");
                    }
                    else if (vertical)
                    {
                        if (loopedTile.LoopPath[tile].Contains(Direction.Up) && loopedTile.LoopPath[tile].Contains(Direction.Down))
                            Console.Write("+");
                        else if (loopedTile.LoopPath[tile].Contains(Direction.Up))
                            Console.Write("^");
                        else
                            Console.Write("v");
                    }
                }
                else if (tile.IsWall)
                    Console.Write("#");
                else
                    Console.Write(".");

                Console.Write(" ");
            }

            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine();
    }
}

public class Tile
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsWall { get; set; }
    public bool IsVisited => this.VisitedDirections.Count > 0;
    public List<Direction> VisitedDirections { get; set; } = new();
    public bool IsLoopPosition { get; set; } = false;

    public string Postion => $"{this.X},{this.Y}";
    public Dictionary<Tile, List<Direction>> LoopPath { get; set; } = new();
}

public class Guard
{
    public Tile? Position { get; set; }
    public Direction Direction { get; set; }
}

public enum Direction
{
    Up,
    Down,
    Left,
    Right,
    None,
}

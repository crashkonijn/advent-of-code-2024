using AdventOfCode2024.Common;

namespace AdventOfCode2024.Day4;

public class InputReader
{
    public static Graph Read()
    {
        var lines = FileReader.ReadLines("Day4\\input.txt");

        return Read(lines);
    }

    public static Graph Read(string[] lines)
    {
        var graph = CreateGraph(lines);

        ConnectNodes(graph);

        return graph;
    }

    private static void ConnectNodes(Graph graph)
    {
        foreach (var rows in graph.Nodes)
        {
            foreach (var node in rows)
            {
                var neighbours = graph.GetNeighbours(node);

                foreach (var neighbour in neighbours)
                {
                    if (ShouldBeConnected(node, neighbour))
                    {
                        node.Connections.Add(new Connection
                        {
                            Node = neighbour,
                            Direction = graph.GetDirection(node, neighbour),
                        });
                    }

                    if (ShouldBeConnected(neighbour, node))
                    {
                        neighbour.Connections.Add(new Connection
                        {
                            Node = node,
                            Direction = graph.GetDirection(neighbour, node),
                        });
                    }
                }
            }
        }
    }

    private static bool ShouldBeConnected(Node a, Node b)
    {
        var diff = b.Letter - a.Letter;

        return diff == 1;
    }

    private static Graph CreateGraph(string[] lines)
    {
        var graph = new Graph();

        var x = 0;
        var y = 0;
        foreach (var line in lines)
        {
            x = 0;
            var nodes = new List<Node>();
            foreach (var c in line)
            {
                nodes.Add(new Node
                {
                    Letter = c switch
                    {
                        'X' => Letter.X,
                        'M' => Letter.M,
                        'A' => Letter.A,
                        'S' => Letter.S,
                        _ => throw new Exception("Invalid letter"),
                    },
                    X = x,
                    Y = y,
                });

                x++;
            }

            graph.Nodes.Add(nodes);

            y++;
        }

        return graph;
    }
}

public class Graph
{
    public List<List<Node>> Nodes { get; set; } = new();

    public List<Node> GetAllNodes()
    {
        return this.Nodes.SelectMany(x => x).ToList();
    }

    public int GetTotalXmas()
    {
        var xNodes = this.GetAllNodes().Where(x => x.Letter == Letter.X).ToList();

        return xNodes.Select(x => x.GetXmasWords()).Sum(x => x.Length);
    }

    public int GetTotalMas()
    {
        var mNodes = this.GetAllNodes().Where(x => x.Letter == Letter.M).ToList();

        mNodes.ForEach(x => x.CalculateMas());

        var aNodes = this.GetAllNodes().Where(x => x.Letter == Letter.A).ToList();

        return aNodes.Count(x => x.IsMasA());
    }

    public List<Node> GetNeighbours(Node node)
    {
        var neighbours = new List<Node?>();

        neighbours.AddRange(new[]
        {
            this.GetNode(node.X + 1, node.Y),
            this.GetNode(node.X + 1, node.Y + 1),
            this.GetNode(node.X, node.Y + 1),
            this.GetNode(node.X - 1, node.Y + 1),
        });

        return neighbours.Where(x => x != null).ToList()!;
    }

    public Direction GetDirection(Node a, Node b)
    {
        if (a.X == b.X)
        {
            if (a.Y < b.Y)
                return Direction.Down;
            if (a.Y > b.Y)
                return Direction.Up;
        }

        if (a.Y == b.Y)
        {
            if (a.X < b.X)
                return Direction.Right;
            if (a.X > b.X)
                return Direction.Left;
        }

        if (a.X < b.X && a.Y < b.Y)
            return Direction.DownRight;
        if (a.X < b.X && a.Y > b.Y)
            return Direction.UpRight;
        if (a.X > b.X && a.Y < b.Y)
            return Direction.DownLeft;
        if (a.X > b.X && a.Y > b.Y)
            return Direction.UpLeft;

        return Direction.Stale;
    }

    public Node? GetNode(int x, int y)
    {
        if (x < 0 || y < 0 || x >= this.Nodes.Count || y >= this.Nodes[0].Count)
            return null;

        return this.Nodes[y][x];
    }

    public string PrintXmas()
    {
        var print = "";

        foreach (var row in this.Nodes)
        {
            foreach (var node in row)
            {
                if (!node.IsPartOfXmas)
                {
                    print += ".";
                    continue;
                }

                print += node.Letter switch
                {
                    Letter.X => "X",
                    Letter.M => "M",
                    Letter.A => "A",
                    Letter.S => "S",
                    _ => throw new Exception("Invalid letter"),
                };
            }

            print += "\n";
        }

        return print;
    }

    public string PrintMas()
    {
        var print = "";

        foreach (var row in this.Nodes)
        {
            foreach (var node in row)
            {
                if (node.IsMasA())
                {
                    print += "a";
                    continue;
                }

                if (!node.IsPartOfMas)
                {
                    print += ".";
                    continue;
                }

                print += node.Letter switch
                {
                    Letter.X => ".",
                    Letter.M => "M",
                    Letter.A => "A",
                    Letter.S => "S",
                    _ => throw new Exception("Invalid letter"),
                };
            }

            print += "\n";
        }

        return print;
    }
}

public class Node
{
    public int X { get; init; }
    public int Y { get; init; }
    public Letter Letter { get; init; }
    public List<Connection> Connections { get; set; } = new();
    public bool IsPartOfXmas { get; set; } = false;
    public bool IsPartOfMas { get; set; } = false;
    public int MasCount { get; set; } = 0;

    public Direction[] GetXmasWords()
    {
        var list = new List<Direction>();

        foreach (var connection in this.Connections)
        {
            if (this.IsXmas(connection.Direction))
                list.Add(connection.Direction);
        }

        return list.ToArray();
    }

    public bool IsXmas(Direction direction)
    {
        var word = new List<Node>();

        this.BuildXmas(word, direction);

        if (word.Count != 4)
            return false;

        foreach (var node in word)
        {
            node.IsPartOfXmas = true;
        }

        return true;
    }

    public bool IsMasA()
    {
        if (this.Letter != Letter.A)
            return false;

        return this.MasCount == 2;
    }

    public void CalculateMas()
    {
        foreach (var connection in this.Connections)
        {
            this.IsMas(connection.Direction);
        }
    }

    public void IsMas(Direction direction)
    {
        switch (direction)
        {
            case Direction.Down:
            case Direction.Left:
            case Direction.Up:
            case Direction.Right:
                return;
        }

        var word = new List<Node>();

        this.BuildMas(word, direction);

        if (word.Count != 3)
            return;

        foreach (var node in word)
        {
            node.IsPartOfMas = true;
            node.MasCount++;
        }
    }

    public Connection? GetConnection(Direction direction)
    {
        return this.Connections.FirstOrDefault(x => x.Direction == direction);
    }

    public void BuildXmas(List<Node> letters, Direction direction)
    {
        letters.Add(this);

        var connection = this.GetConnection(direction);

        if (connection == null)
            return;

        connection.Node.BuildXmas(letters, connection.Direction);
    }

    public void BuildMas(List<Node> letters, Direction direction)
    {
        letters.Add(this);

        var connection = this.GetConnection(direction);

        if (connection == null)
            return;

        connection.Node.BuildMas(letters, connection.Direction);
    }
}

public class Connection
{
    public Node Node { get; set; }
    public Direction Direction { get; set; }
}

public enum Direction
{
    Up = 0,
    Down = 1,
    Left = 2,
    Right = 3,
    UpLeft = 4,
    UpRight = 5,
    DownLeft = 6,
    DownRight = 7,
    Stale = 8,
}

public enum Letter
{
    X = 0,
    M = 1,
    A = 2,
    S = 3,
}

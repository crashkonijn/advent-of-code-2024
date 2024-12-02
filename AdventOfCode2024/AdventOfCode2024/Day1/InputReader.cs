using AdventOfCode2024.Common;

namespace AdventOfCode2024.Day1;

public class InputReader
{
    public Input Read()
    {
        var reader = new FileReader();
        var content = reader.Read("Day1_1\\input.txt");

        var left = new List<int>();
        var right = new List<int>();

        var lines = content.Split(Environment.NewLine);

        foreach (var line in lines)
        {
            var split = line.Split("   ");
            left.Add(int.Parse(split[0]));
            right.Add(int.Parse(split[1]));
        }

        return new Input
        {
            Left = left,
            Right = right,
        };
    }

    public class Input
    {
        public List<int> Left { get; set; }
        public List<int> Right { get; set; }
    }
}

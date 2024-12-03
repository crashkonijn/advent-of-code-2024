using System.Text.RegularExpressions;
using AdventOfCode2024.Common;

namespace AdventOfCode2024.Day3;

public class InputReader
{
    public static Multiplication[] Read()
    {
        var content = FileReader.Read("Day3\\input.txt");
        var regex = new Regex(@"mul\((?<a>[0-9]+),(?<b>[0-9]+)\)");

        var matches = regex.Matches(content);

        var muls = matches.Select(x => new Multiplication
        {
            A = int.Parse(x.Groups["a"].Value),
            B = int.Parse(x.Groups["b"].Value),
        }).ToArray();

        return muls;
    }
}

public class Multiplication
{
    public int A { get; set; }
    public int B { get; set; }

    public int Result => this.A * this.B;
}

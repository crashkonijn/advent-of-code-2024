using System.Text.RegularExpressions;
using AdventOfCode2024.Common;

namespace AdventOfCode2024.Day3;

public class InputReader
{
    private static readonly Regex mulRegex = new(@"mul\((?<a>[0-9]+),(?<b>[0-9]+)\)");
    private static readonly Regex splitRegex = new(@"(?<instructions>[\n\s\S]*?)(?:(?<do>do)|(?<dont>don\'t))\(\)");

    public static Multiplication[] Read()
    {
        var content = FileReader.Read("Day3\\input.txt");

        var matches = mulRegex.Matches(content);

        var muls = matches.Select(x => new Multiplication
        {
            A = int.Parse(x.Groups["a"].Value),
            B = int.Parse(x.Groups["b"].Value),
        }).ToArray();

        return muls;
    }

    public static Multiplication[] Read2()
    {
        var content = FileReader.Read("Day3\\input.txt");

        // Add do() to the end of the content to make sure the last match is found
        var splitMatch = splitRegex.Matches(content + "do()");

        var valid = true;

        var muls = new List<Multiplication>();

        foreach (Match match in splitMatch)
        {
            if (valid)
            {
                var mulMatches = mulRegex.Matches(match.Groups["instructions"].Value);

                muls.AddRange(mulMatches.Select(x => new Multiplication
                {
                    A = int.Parse(x.Groups["a"].Value),
                    B = int.Parse(x.Groups["b"].Value),
                }));
            }

            var doMatch = match.Groups["do"].Success;
            var dontMatch = match.Groups["dont"].Success;

            valid = doMatch;
        }

        return muls.ToArray();
    }
}

public class Multiplication
{
    public int A { get; set; }
    public int B { get; set; }

    public int Result => this.A * this.B;
}

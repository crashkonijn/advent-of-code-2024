namespace AdventOfCode2024.Day5;

public class InputReader
{
    public static Input Read()
    {
        var rules = File.ReadAllLines("Day5/input_rules.txt");
        var lines = File.ReadAllLines("Day5/input_lines.txt");

        return Read(rules, lines);
    }

    public static Input Read(string[] rules, string[] lines)
    {
        var parsedRules = rules.Select(r => new Rule(r)).ToArray();
        var parsedLines = lines.Select(l => new Line(l)).ToArray();

        return new Input
        {
            Rules = parsedRules,
            Lines = parsedLines,
        };
    }
}

public class Input
{
    public Rule[] Rules { get; init; }
    public Line[] Lines { get; init; }

    public bool IsValid(Line line)
    {
        return this.Rules.All(x => x.IsValid(line));
    }

    public NumberComparer GetComparer()
    {
        return new NumberComparer(this.Rules);
    }
}

public class Rule
{
    public int Before { get; init; }
    public int After { get; init; }

    public Rule(string rule)
    {
        var parts = rule.Split("|");

        this.Before = int.Parse(parts[0]);
        this.After = int.Parse(parts[1]);
    }

    public bool IsValid(Line line)
    {
        var beforeIndex = line.GetIndex(this.Before);
        var afterIndex = line.GetIndex(this.After);

        if (beforeIndex == -1 || afterIndex == -1)
            return true;

        return beforeIndex < afterIndex;
    }
}

public class Line
{
    public int[] Numbers { get; private set; }
    public int Center => this.Numbers[this.centerIndex];
    private int centerIndex;

    public Line(string line)
    {
        this.Numbers = line.Split(",").Select(int.Parse).ToArray();
        this.centerIndex = this.Numbers.Length / 2;
    }

    public int GetIndex(int number)
    {
        return Array.IndexOf(this.Numbers, number);
    }

    public void Sort(Input input)
    {
        this.Numbers = this.Numbers.Order(input.GetComparer()).ToArray();
    }
}

public class NumberComparer : IComparer<int>
{
    private readonly Rule[] rules;

    public NumberComparer(Rule[] rules)
    {
        this.rules = rules;
    }

    public int Compare(int x, int y)
    {
        var beforeRule = this.rules.FirstOrDefault(r => r.Before == x && r.After == y);

        if (beforeRule != null)
            return -1;

        var afterRule = this.rules.FirstOrDefault(r => r.Before == y && r.After == x);

        if (afterRule != null)
            return 1;

        return 0;
    }
}

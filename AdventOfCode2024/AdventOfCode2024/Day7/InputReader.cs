using AdventOfCode2024.Common;

namespace AdventOfCode2024.Day7;

public class InputReader
{
    public static Data Read()
    {
        var input = FileReader.ReadLines("Day7\\input.txt");

        return Read(input);
    }

    public static Data Read(string[] input)
    {
        var data = new Data();

        foreach (var line in input)
        {
            var parts = line.Split(": ");
            var result = parts[0];
            var numbers = parts[1].Split(" ").Select(long.Parse).ToArray();

            data.Calculations.Add(new Calculation
            {
                Numbers = numbers,
                Result = long.Parse(result),
            });
        }

        return data;
    }
}

public class Data
{
    public List<Calculation> Calculations { get; set; } = new();

    public IOperator[] Part1Operators =>
    [
        new AddOperator(),
        new MultiplyOperator(),
    ];

    public IOperator[] Part2Operators =>
    [
        new AddOperator(),
        new MultiplyOperator(),
        new CombineOperator(),
    ];

    public (bool IsValid, IOperator[] Operators) IsValid(Calculation calc)
    {
        var result = calc.Compute(this.Part1Operators, 1, calc.Numbers[0], $"{calc.Numbers[0]}");

        return result;
    }

    public (bool IsValid, IOperator[] Operators) IsValid2(Calculation calc)
    {
        var result = calc.Compute(this.Part2Operators, 1, calc.Numbers[0], $"{calc.Numbers[0]}");

        return result;
    }
}

public class Calculation
{
    public long[] Numbers { get; set; }
    public long Result { get; set; }

    public (bool IsValid, IOperator[] Operators) Compute(IOperator[] operators, int index, long total, string log = "")
    {
        var number = this.Numbers[index];

        foreach (var op in operators)
        {
            var result = op.Compute(total, number);

            // Console.WriteLine($"{log} {op} {number} = {result}");

            if (result > this.Result)
                continue;

            if (result == this.Result && index == this.Numbers.Length - 1)
            {
                return (true, new[] { op });
            }

            if (index + 1 < this.Numbers.Length)
            {
                var (isValid, usedOperators) = this.Compute(operators, index + 1, result, $"{log} {op} {number}");

                if (isValid)
                    return (true, new[] { op }.Concat(usedOperators).ToArray());
            }
        }

        return (false, []);
    }
}

public interface IOperator
{
    public long Compute(long a, long b);
}

public class AddOperator : IOperator
{
    public long Compute(long a, long b)
    {
        return a + b;
    }

    public override string ToString()
    {
        return "+";
    }
}

public class MultiplyOperator : IOperator
{
    public long Compute(long a, long b)
    {
        return a * b;
    }

    public override string ToString()
    {
        return "*";
    }
}

public class CombineOperator : IOperator
{
    public long Compute(long a, long b)
    {
        return long.Parse($"{a}{b}");
    }

    public override string ToString()
    {
        return "";
    }
}

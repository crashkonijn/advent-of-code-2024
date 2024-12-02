namespace AdventOfCode2024.Day1_1;

public class Pair
{
    public int Left { get; init; }
    public int Right { get; init; }

    public int Difference
    {
        get
        {
            var smallest = Math.Min(this.Left, this.Right);
            var largest = Math.Max(this.Left, this.Right);

            return largest - smallest;
        }
    }
}

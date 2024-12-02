using AdventOfCode2024.Common;

namespace AdventOfCode2024.Day2;

public class InputReader
{
    public static Report[] Read()
    {
        var content = FileReader.Read("Day2\\input.txt");
        var lines = content.Split(Environment.NewLine);

        var reports = lines.Select(x => new Report
        {
            Numbers = x.Split(" ").Select(int.Parse).ToArray(),
        }).ToArray();

        return reports;
    }

    public class Report
    {
        public int[] Numbers { get; init; }
        public string Reason { get; set; }

        public Direction Direction => this.GetDirection(this.Numbers[0], this.Numbers[1]);

        public bool IsValid()
        {
            if (this.Direction == Direction.Stale)
                return this.LogReason(false, "Stale direction");

            for (var i = 1; i < this.Numbers.Length; i++)
            {
                var direction = this.GetDirection(this.Numbers[i - 1], this.Numbers[i]);
                if (direction != this.Direction)
                    return this.LogReason(false, $"Invalid direction {direction} {this.Direction}");
                
                var difference = Math.Abs(this.Numbers[i - 1] - this.Numbers[i]);
                if (difference > 3)
                    return this.LogReason(false, $"Invalid difference {difference} ({this.Numbers[i - 1]},{this.Numbers[i]})");
            }

            return true;
        }

        private Direction GetDirection(int a, int b)
        {
            if (a == b)
                return Direction.Stale;

            if (a < b)
                return Direction.Up;

            return Direction.Down;
        }

        private bool LogReason(bool output, string reason)
        {
            this.Reason = reason;

            return output;
        }
    }

    public enum Direction
    {
        Up,
        Down,
        Stale,
    }
}

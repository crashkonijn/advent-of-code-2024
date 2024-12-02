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

        public bool IsValid() => this.IsValid(this.Numbers);

        public bool IsValidDampened()
        {
            if (this.IsValid())
                return true;

            var tempList = new List<int>();
            for (var i = 0; i < this.Numbers.Length; i++)
            {
                tempList.Clear();
                tempList.AddRange(this.Numbers);
                tempList.RemoveAt(i);

                if (this.IsValid(tempList.ToArray()))
                    return true;
            }

            return false;
        }

        private bool IsValid(int[] numbers)
        {
            var direction = this.GetDirection(numbers[0], numbers[1]);

            for (var i = 1; i < numbers.Length; i++)
            {
                if (!this.IsValid(direction, numbers[i - 1], numbers[i]))
                    return false;
            }

            return true;
        }

        private bool IsValid(Direction initialDir, int a, int b)
        {
            var direction = this.GetDirection(a, b);
            if (direction == Direction.Stale)
                return this.LogReason(false, "Stale direction");

            if (direction != initialDir)
                return this.LogReason(false, $"Invalid direction {direction} {this.Direction} ({a}, {b})");

            var difference = Math.Abs(a - b);
            if (difference > 3)
                return this.LogReason(false, $"Invalid difference {difference} ({a}, {b})");

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

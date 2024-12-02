using AdventOfCode2024.Day2;
using FluentAssertions;

namespace AdventOfCode2024.Tests;

public class Day2
{
    [TestCase("7 6 4 2 1", true)]
    [TestCase("1 2 7 8 9", false)]
    [TestCase("9 7 6 2 1", false)]
    [TestCase("1 3 2 4 5", true)]
    [TestCase("8 6 4 4 1", true)]
    [TestCase("1 3 6 7 9", true)]
    public void IsValidDampened(string input, bool safe)
    {
        // Arrange
        var report = new InputReader.Report
        {
            Numbers = input.Split(" ").Select(int.Parse).ToArray(),
        };


        // Act
        var result = report.IsValidDampened();

        // Assert
        result.Should().Be(safe);
    }
}

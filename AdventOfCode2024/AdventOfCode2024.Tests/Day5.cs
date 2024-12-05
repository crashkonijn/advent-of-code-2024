using AdventOfCode2024.Day5;
using FluentAssertions;

namespace AdventOfCode2024.Tests;

public class Day5
{
    private string[] rules =
    [
        "47|53",
        "97|13",
        "97|61",
        "97|47",
        "75|29",
        "61|13",
        "75|53",
        "29|13",
        "97|29",
        "53|29",
        "61|53",
        "97|53",
        "61|29",
        "47|13",
        "75|47",
        "97|75",
        "47|61",
        "75|61",
        "47|29",
        "75|13",
        "53|13",
    ];

    private string[] lines =
    [
        "75,47,61,53,29",
        "97,61,53,29,13",
        "75,29,13",
        "75,97,47,61,53",
        "61,13,29",
        "97,13,75,29,47",
    ];

    [TestCase("75,47,61,53,29", 61, true)]
    [TestCase("97,61,53,29,13", 53, true)]
    [TestCase("75,29,13", 29, true)]
    [TestCase("75,97,47,61,53", 47, false)]
    [TestCase("61,13,29", 13, false)]
    [TestCase("97,13,75,29,47", 75, false)]
    public void Test1(string line, int center, bool valid)
    {
        // Arrange
        var input = InputReader.Read(this.rules, new[] { line });

        // Act
        var parsedLine = input.Lines.First();
        var result = input.IsValid(parsedLine);

        // Assert
        result.Should().Be(valid);
        parsedLine.Center.Should().Be(center);
    }

    [TestCase("75,97,47,61,53", 47)]
    [TestCase("61,13,29", 29)]
    [TestCase("97,13,75,29,47", 47)]
    public void Test2(string line, int center)
    {
        // Arrange
        var input = InputReader.Read(this.rules, new[] { line });

        // Act
        var parsedLine = input.Lines.First();

        var originalValid = input.IsValid(parsedLine);

        parsedLine.Sort(input);

        // Assert
        originalValid.Should().BeFalse();
        input.IsValid(parsedLine).Should().BeTrue();
        parsedLine.Center.Should().Be(center);
    }
}

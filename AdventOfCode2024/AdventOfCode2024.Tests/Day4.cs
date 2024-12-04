using AdventOfCode2024.Day4;
using FluentAssertions;

namespace AdventOfCode2024.Tests;

public class Day4
{
    private string[] input = new string[]
    {
        "MMMSXXMASM",
        "MSAMXMSMSA",
        "AMXSXMAAMM",
        "MSAMASMSMX",
        "XMASAMXAMM",
        "XXAMMXXAMA",
        "SMSMSASXSS",
        "SAXAMASAAA",
        "MAMMMXMMMM",
        "MXMXAXMASX",
    };

    [Test]
    public void IsXmas()
    {
        // Arrange
        var result = InputReader.Read(this.input);

        // Act
        var total = result.GetTotalXmas();

        // Assert
        total.Should().Be(18);
    }

    [Test]
    public void IsMas()
    {
        // Arrange
        var result = InputReader.Read(this.input);

        // Act
        var total = result.GetTotalMas();

        // Assert
        total.Should().Be(9);
    }
}

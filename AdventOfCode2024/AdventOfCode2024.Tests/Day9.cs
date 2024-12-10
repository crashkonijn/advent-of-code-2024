using AdventOfCode2024.Day9;
using FluentAssertions;

namespace AdventOfCode2024.Tests;

public class Day9
{
    private string input = "2333133121414131402";

    [Test]
    public void Example_Import()
    {
        // Arrange
        var disk = InputReader.Read(this.input);

        // Act
        var result = disk.ToString();

        // Assert
        result.Should().Be("00...111...2...333.44.5555.6666.777.888899");
    }

    [Test]
    public void Example_Compress()
    {
        // Arrange
        var disk = InputReader.Read(this.input);

        // Act
        disk.Compress();

        // Assert
        disk.ToString().Should().Be("0099811188827773336446555566..............");
    }

    [Test]
    public void Example_Checksum()
    {
        // Arrange
        var disk = InputReader.Read(this.input);

        // Act
        disk.Compress();

        // Assert
        disk.GetChecksum().Should().Be(1928);
    }

    [Test]
    public void Example_Part2_Compress()
    {
        // Arrange
        var disk = InputReader.Read(this.input);

        // Act
        disk.CompressLarge();

        // Assert
        disk.ToString().Should().Be("00992111777.44.333....5555.6666.....8888..");
    }

    [Test]
    public void Example_Part2_Checksum()
    {
        // Arrange
        var disk = InputReader.Read(this.input);

        // Act
        disk.CompressLarge();

        // Assert
        disk.GetChecksum().Should().Be(2858);
    }
}

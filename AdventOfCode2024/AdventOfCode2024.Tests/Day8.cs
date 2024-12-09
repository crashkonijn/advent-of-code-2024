using AdventOfCode2024.Day8;
using FluentAssertions;

namespace AdventOfCode2024.Tests;

public class Day8
{
    [Test]
    public void SimpleTest()
    {
        // Arrange
        var lines = new string[]
        {
            "......",
            "...x..",
            "...x..",
            "......",
            "......",
            "......",
        };

        var map = InputReader.Read(lines);

        // Act
        map.Compute();
        map.Print();

        // Assert
        map.GetPosition(3, 0)!.IsAntiNode.Should().BeTrue();
        map.GetPosition(3, 3)!.IsAntiNode.Should().BeTrue();
    }

    [Test]
    public void EdgeTest()
    {
        // Arrange
        var lines = new string[]
        {
            "...x..",
            "...x..",
            "......",
            "......",
            "......",
        };

        var map = InputReader.Read(lines);

        // Act
        map.Compute();
        map.Print();

        // Assert
        map.GetPosition(3, 2)!.IsAntiNode.Should().BeTrue();
    }

    [Test]
    public void DiagonalTest()
    {
        // Arrange
        var lines = new string[]
        {
            "......",
            "......",
            "..X...",
            "....X.",
            "......",
            "......",
        };

        var map = InputReader.Read(lines);

        // Act
        map.Compute();
        map.Print();

        // Assert
        map.GetPosition(0, 1)!.IsAntiNode.Should().BeTrue();
    }


    [Test]
    public void ExampleTest()
    {
        // Arrange
        var lines = new string[]
        {
            "............",
            "........0...",
            ".....0......",
            ".......0....",
            "....0.......",
            "......A.....",
            "............",
            "............",
            "........A...",
            ".........A..",
            "............",
            "............",
        };

        var map = InputReader.Read(lines);

        // Act
        map.Compute();
        map.Print();

        // Assert
        map.AntiNodes.Should().HaveCount(14);
    }

    [Test]
    public void Part2Example()
    {
        // Arrange
        var lines = new string[]
        {
            "T.........",
            "...T......",
            ".T........",
            "..........",
            "..........",
            "..........",
            "..........",
            "..........",
            "..........",
            "..........",
        };

        var map = InputReader.Read(lines);

        // Act
        map.Compute2();
        map.Print();

        // Assert
        map.AntiNodes.Should().HaveCount(9);
    }
    
    [Test]
    public void Part2ExampleTest()
    {
        // Arrange
        var lines = new string[]
        {
            "............",
            "........0...",
            ".....0......",
            ".......0....",
            "....0.......",
            "......A.....",
            "............",
            "............",
            "........A...",
            ".........A..",
            "............",
            "............",
        };

        var map = InputReader.Read(lines);

        // Act
        map.Compute2();
        map.Print();

        // Assert
        map.AntiNodes.Should().HaveCount(34);
    }
}

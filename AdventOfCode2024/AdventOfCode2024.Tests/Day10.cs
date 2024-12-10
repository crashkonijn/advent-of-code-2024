using AdventOfCode2024.Day10;
using FluentAssertions;

namespace AdventOfCode2024.Tests;

public class Day10
{
    [Test]
    public void Part1_Example1()
    {
        // Arrange
        var input = new string[]
        {
            "0123",
            "1234",
            "8765",
            "9876",
        };

        // Act
        var map = InputReader.Read(input);
        map.Compute();

        // Assert
        var tile = map.Tiles[0, 0];

        tile.Destinations.Should().HaveCount(1);
    }

    [Test]
    public void Part1_Example2()
    {
        // Arrange
        var input = new string[]
        {
            "...0...",
            "...1...",
            "...2...",
            "6543456",
            "7.....7",
            "8.....8",
            "9.....9",
        };

        // Act
        var map = InputReader.Read(input);
        map.Compute();

        // Assert
        var tile = map.Tiles[3, 0];

        tile.Destinations.Should().HaveCount(2);
    }

    [Test]
    public void Part1_Example3()
    {
        // Arrange
        var input = new string[]
        {
            "..90..9",
            "...1.98",
            "...2..7",
            "6543456",
            "765.987",
            "876....",
            "987....",
        };

        // Act
        var map = InputReader.Read(input);
        map.Compute();

        // Assert
        var tile = map.Tiles[3, 0];

        tile.Destinations.Should().HaveCount(4);
    }

    [Test]
    public void Part1_Example4()
    {
        // Arrange
        var input = new string[]
        {
            "10..9..",
            "2...8..",
            "3...7..",
            "4567654",
            "...8..3",
            "...9..2",
            ".....01",
        };

        // Act
        var map = InputReader.Read(input);
        map.Compute();

        // Assert
        map.Tiles[1, 0].Destinations.Should().HaveCount(1);
        map.Tiles[5, 6].Destinations.Should().HaveCount(2);
    }

    [Test]
    public void Part1_Example()
    {
        // Arrange
        var input = new string[]
        {
            "89010123",
            "78121874",
            "87430965",
            "96549874",
            "45678903",
            "32019012",
            "01329801",
            "10456732",
        };

        // Act
        var map = InputReader.Read(input);
        map.Compute();

        var trailHeads = map.GetTrailheads();

        // Assert
        trailHeads.Should().HaveCount(9);
        map.GetTrailheadScore().Should().Be(36);
    }

    [Test]
    public void Part2_Example1()
    {
        // Arrange
        var input = new string[]
        {
            ".....0.",
            "..4321.",
            "..5..2.",
            "..6543.",
            "..7..4.",
            "..8765.",
            "..9....",
        };

        // Act
        var map = InputReader.Read(input);
        map.Compute();

        var trailHeads = map.GetTrailheads();

        // Assert
        trailHeads.Should().HaveCount(1);
        map.GetTrailheadRating().Should().Be(3);
    }

    [Test]
    public void Part2_Example2()
    {
        // Arrange
        var input = new string[]
        {
            "..90..9",
            "...1.98",
            "...2..7",
            "6543456",
            "765.987",
            "876....",
            "987....",
        };

        // Act
        var map = InputReader.Read(input);
        map.Compute();

        var trailHeads = map.GetTrailheads();

        // Assert
        trailHeads.Should().HaveCount(1);
        map.GetTrailheadRating().Should().Be(13);
    }

    [Test]
    public void Part2_Example3()
    {
        // Arrange
        var input = new string[]
        {
            "012345",
            "123456",
            "234567",
            "345678",
            "4.6789",
            "56789.",
        };

        // Act
        var map = InputReader.Read(input);
        map.Compute();

        var trailHeads = map.GetTrailheads();

        // Assert
        trailHeads.Should().HaveCount(1);
        map.GetTrailheadRating().Should().Be(227);
    }

    [Test]
    public void Part2_Example()
    {
        // Arrange
        var input = new string[]
        {
            "89010123",
            "78121874",
            "87430965",
            "96549874",
            "45678903",
            "32019012",
            "01329801",
            "10456732",
        };

        // Act
        var map = InputReader.Read(input);
        map.Compute();

        var trailHeads = map.GetTrailheads();

        // Assert
        trailHeads.Should().HaveCount(9);
        map.GetTrailheadRating().Should().Be(81);
    }
}

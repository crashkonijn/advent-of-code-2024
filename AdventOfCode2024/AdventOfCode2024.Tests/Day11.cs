using AdventOfCode2024.Day11;
using FluentAssertions;

namespace AdventOfCode2024.Tests;

public class Day11
{
    [Test]
    public void Part1_Test1()
    {
        // Arrange
        var line = "125 17";
        var data = InputReader.Read(line);

        // Act
        data.Step();
        data.GetPrint().Should().Be("253000 1 7");

        data.Step();
        data.GetPrint().Should().Be("253 0 2024 14168");

        data.Step();
        data.GetPrint().Should().Be("512072 1 20 24 28676032");

        data.Step();
        data.GetPrint().Should().Be("512 72 2024 2 0 2 4 2867 6032");

        data.Step();
        data.GetPrint().Should().Be("1036288 7 2 20 24 4048 1 4048 8096 28 67 60 32");

        data.Step();
        data.GetPrint().Should().Be("2097446912 14168 4048 2 0 2 4 40 48 2024 40 48 80 96 2 8 6 7 6 0 3 2");
    }

    [Test]
    public void Part1_Test2()
    {
        // Arrange
        var line = "0 1 10 99 999";
        var data = InputReader.Read(line);

        // Act
        data.Step();
        data.GetPrint().Should().Be("1 2024 1 0 9 9 2021976");
    }

    [Test]
    public void Part1_Test3()
    {
        // Arrange
        var line = "125 17";
        var data = InputReader.Read(line);

        // Act
        data.Simulate(25);
        data.Stones.Should().HaveCount(55312);
    }
}

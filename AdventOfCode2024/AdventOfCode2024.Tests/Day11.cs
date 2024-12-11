using System.Diagnostics;
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
        data.GetCount().Should().Be(3);

        data.Step();
        data.GetCount().Should().Be(4);

        data.Step();
        data.GetCount().Should().Be(5);

        data.Step();
        data.GetCount().Should().Be(9);

        data.Step();
        data.GetCount().Should().Be(13);

        data.Step();
        data.GetCount().Should().Be(22);
    }

    [Test]
    public void Part1_Test2()
    {
        // Arrange
        var line = "0 1 10 99 999";
        var data = InputReader.Read(line);

        // Act
        data.Step();
        data.GetCount().Should().Be(6);
    }

    [Test]
    public void Part1_Test3()
    {
        // Arrange
        var line = "125 17";
        var data = InputReader.Read(line);

        // Act
        var stopwatch = Stopwatch.StartNew();
        data.Simulate(25);
        stopwatch.Stop();
        Console.WriteLine(stopwatch.ElapsedMilliseconds);
        data.GetCount().Should().Be(55312);
    }
}

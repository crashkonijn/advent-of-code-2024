using AdventOfCode2024.Day7;
using FluentAssertions;

namespace AdventOfCode2024.Tests;

public class Day7
{
    private string[] input =
    [
        "190: 10 19",
        "3267: 81 40 27",
        "83: 17 5",
        "156: 15 6",
        "7290: 6 8 6 15",
        "161011: 16 10 13",
        "192: 17 8 14",
        "21037: 9 7 18 13",
        "292: 11 6 16 20",
    ];

    [TestCase("190: 10 19", true)]
    [TestCase("3267: 81 40 27", true)]
    [TestCase("83: 17 5", false)]
    [TestCase("156: 15 6", false)]
    [TestCase("7290: 6 8 6 15", false)]
    [TestCase("161011: 16 10 13", false)]
    [TestCase("192: 17 8 14", false)]
    [TestCase("21037: 9 7 18 13", false)]
    [TestCase("292: 11 6 16 20", true)]
    public void Test1(string line, bool valid)
    {
        // Arrange
        var data = InputReader.Read(new[] { line });

        // Act
        var result = data.IsValid(data.Calculations[0]);

        // Assert
        result.IsValid.Should().Be(valid);

        if (valid)
            result.Operators.Should().HaveCount(data.Calculations[0].Numbers.Length - 1);
    }

    [Test]
    public void Test1_Sum()
    {
        // Arrange
        var data = InputReader.Read(this.input);

        // Act
        var result = data.Calculations.Where(calc => data.IsValid(calc).IsValid).Sum(calc => calc.Result);

        // Assert
        result.Should().Be(3749);
    }

    [Test]
    public void TestCalculations()
    {
        // Arrange
        var data = InputReader.Read();

        // Act

        // Assert
        foreach (var calculation in data.Calculations)
        {
            Console.WriteLine($"Checking number: {calculation.Result}");

            var result = data.IsValid(calculation);

            if (!result.IsValid)
                continue;

            result.Operators.Should().HaveCount(calculation.Numbers.Length - 1);

            var total = calculation.Numbers[0];
            for (var i = 0; i < result.Operators.Length; i++)
            {
                total = result.Operators[i].Compute(total, calculation.Numbers[i + 1]);
            }

            total.Should().Be(calculation.Result);
        }
    }

    [TestCase(1659517050)]
    [TestCase(97828)]
    [TestCase(21316689)]
    [TestCase(4685569)]
    [TestCase(28883667)]
    [TestCase(1219750)]
    [TestCase(6479)]
    [TestCase(10772736)]
    [TestCase(10349128)]
    [TestCase(53712)]
    [TestCase(2456)]
    [TestCase(63002934)]
    [TestCase(904)]
    [TestCase(27725)]
    [TestCase(10093504)]
    [TestCase(444)]
    [TestCase(1480)]
    [TestCase(52299)]
    [TestCase(1404)]
    [TestCase(3200)]
    [TestCase(2297911)]
    [TestCase(13775832)]
    [TestCase(413686)]
    [TestCase(282842410)]
    [TestCase(27658973736)]
    [TestCase(4472775)]
    [TestCase(1306)]
    [TestCase(61001050)]
    [TestCase(82432532)]
    [TestCase(17789)]
    [TestCase(266697)]
    [TestCase(2691)]
    [TestCase(229255550)]
    [TestCase(3306471)]
    [TestCase(1039)]
    [TestCase(1108143400)]
    [TestCase(214620)]
    [TestCase(5857596)]
    [TestCase(8534)]
    [TestCase(2219399700)]
    [TestCase(4724)]
    [TestCase(6911)]
    [TestCase(350000)]
    [TestCase(2342957505)]
    [TestCase(158331)]
    [TestCase(21787920)]
    [TestCase(228460145)]
    [TestCase(13623952)]
    [TestCase(138673080)]
    [TestCase(28392)]
    [TestCase(968240)]
    [TestCase(25557120)]
    [TestCase(1475720)]
    [TestCase(364450)]
    [TestCase(97504)]
    [TestCase(56)]
    [TestCase(68343456)]
    [TestCase(110400)]
    [TestCase(3441866)]
    [TestCase(77968009736)]
    [TestCase(15472406400)]
    [TestCase(722223)]
    [TestCase(70342)]
    [TestCase(31025296)]
    [TestCase(1344960)]
    [TestCase(329843745)]
    [TestCase(13144560)]
    [TestCase(7265904)]
    [TestCase(71005945)]
    [TestCase(199739749)]
    [TestCase(29992246)]
    [TestCase(799462)]
    [TestCase(120995640)]
    [TestCase(5775)]
    [TestCase(43092)]
    [TestCase(18564780)]
    [TestCase(398391)]
    [TestCase(402909)]
    [TestCase(1628618400)]
    [TestCase(790231860)]
    [TestCase(183)]
    [TestCase(3668)]
    [TestCase(14549474087)]
    [TestCase(13198077)]
    [TestCase(4939350532)]
    [TestCase(10746410)]
    [TestCase(59054)]
    [TestCase(7787807)]
    [TestCase(284154)]
    [TestCase(332021340)]
    [TestCase(4794148800)]
    [TestCase(25567104)]
    [TestCase(2005947358)]
    [TestCase(1119093)]
    [TestCase(18932659200)]
    [TestCase(129319250)]
    [TestCase(101223)]
    [TestCase(1859305)]
    [TestCase(1220)]
    [TestCase(450)]
    [TestCase(1131489584)]
    [TestCase(11295907)]
    [TestCase(1710)]
    [TestCase(241818720)]
    [TestCase(826)]
    [TestCase(418672800)]
    [TestCase(32138504)]
    [TestCase(67979828)]
    [TestCase(4399)]
    [TestCase(10035194832)]
    [TestCase(11773248)]
    [TestCase(2076882060)]
    [TestCase(41760)]
    [TestCase(8043173)]
    [TestCase(8766468)]
    [TestCase(1340432800)]
    [TestCase(23243449641)]
    [TestCase(2064)]
    [TestCase(8265915)]
    [TestCase(593)]
    [TestCase(577278)]
    [TestCase(70490)]
    [TestCase(7811160)]
    [TestCase(1412313084)]
    [TestCase(233)]
    [TestCase(96373560)]
    [TestCase(66363)]
    [TestCase(851316)]
    [TestCase(23923291)]
    [TestCase(21509522)]
    [TestCase(504918)]
    [TestCase(104004)]
    [TestCase(1438551730)]
    [TestCase(24129135)]
    [TestCase(45117)]
    [TestCase(102822123)]
    [TestCase(11742805285)]
    [TestCase(2677994)]
    [TestCase(812738)]
    [TestCase(8561)]
    [TestCase(201633635)]
    [TestCase(13042)]
    [TestCase(26124280)]
    [TestCase(247908)]
    [TestCase(32938)]
    [TestCase(1124430)]
    [TestCase(3571500)]
    [TestCase(184768137)]
    [TestCase(16420444)]
    [TestCase(27946032)]
    [TestCase(784044)]
    [TestCase(423915030)]
    [TestCase(318748)]
    [TestCase(84778)]
    [TestCase(29686)]
    [TestCase(25121)]
    [TestCase(129456)]
    [TestCase(132300)]
    [TestCase(1020957)]
    [TestCase(5411863)]
    [TestCase(823472)]
    [TestCase(44720)]
    [TestCase(389719)]
    [TestCase(41440)]
    [TestCase(502018)]
    [TestCase(206016)]
    [TestCase(2509682)]
    [TestCase(54308170)]
    [TestCase(6360)]
    [TestCase(124145392)]
    [TestCase(5654404)]
    [TestCase(217229865)]
    [TestCase(16337908)]
    [TestCase(2351166)]
    [TestCase(12195460)]
    [TestCase(6310362)]
    [TestCase(3144694409)]
    [TestCase(114054736)]
    [TestCase(8070104014)]
    [TestCase(1509840)]
    [TestCase(142040)]
    [TestCase(3568670)]
    [TestCase(1082)]
    [TestCase(92393352)]
    [TestCase(743)]
    [TestCase(6405181)]
    [TestCase(22325)]
    [TestCase(1642568940)]
    [TestCase(11951)]
    [TestCase(346365)]
    [TestCase(17294)]
    [TestCase(1849)]
    [TestCase(19692)]
    [TestCase(5096)]
    [TestCase(1694)]
    [TestCase(304)]
    [TestCase(35246640)]
    [TestCase(81)]
    [TestCase(30438)]
    [TestCase(44352)]
    [TestCase(2089)]
    [TestCase(6755)]
    [TestCase(156366)]
    [TestCase(9757918)]
    [TestCase(9261)]
    [TestCase(4967)]
    [TestCase(127)]
    [TestCase(7980159500)]
    [TestCase(184649)]
    [TestCase(542470680)]
    [TestCase(4386816)]
    [TestCase(558623360)]
    [TestCase(6900)]
    [TestCase(5263)]
    [TestCase(432976)]
    [TestCase(1060920)]
    [TestCase(183084)]
    [TestCase(1769)]
    [TestCase(296056)]
    [TestCase(327571200)]
    [TestCase(14859684)]
    [TestCase(1317)]
    [TestCase(956)]
    [TestCase(2986)]
    [TestCase(7916400)]
    [TestCase(83867652)]
    [TestCase(476676)]
    [TestCase(591226704)]
    [TestCase(6404580000)]
    [TestCase(91509075)]
    [TestCase(118089)]
    [TestCase(93806)]
    [TestCase(338765495)]
    [TestCase(43)]
    [TestCase(5080)]
    [TestCase(65229)]
    [TestCase(51466)]
    [TestCase(99879070)]
    [TestCase(6825076)]
    [TestCase(3759866880)]
    [TestCase(18750438)]
    [TestCase(1884)]
    [TestCase(4262304)]
    public void TestResults(long result)
    {
        // Arrange
        var data = InputReader.Read();

        // Act
        var calculation = data.Calculations.First(calc => calc.Result == result);

        // Assert
        var resultData = data.IsValid(calculation);

        resultData.IsValid.Should().BeTrue();
    }

    [Test]
    public void Test()
    {
        // Arrange
        var data = InputReader.Read();

        // Act
        var calculation = data.Calculations.First(calc => calc.Result == 13042);

        // Assert
        var resultData = data.IsValid(calculation);

        resultData.IsValid.Should().BeTrue();
    }

    [TestCase("190: 10 19", true)]
    [TestCase("3267: 81 40 27", true)]
    [TestCase("83: 17 5", false)]
    [TestCase("156: 15 6", true)]
    [TestCase("7290: 6 8 6 15", true)]
    [TestCase("161011: 16 10 13", false)]
    [TestCase("192: 17 8 14", true)]
    [TestCase("21037: 9 7 18 13", false)]
    [TestCase("292: 11 6 16 20", true)]
    public void Test2(string line, bool valid)
    {
        // Arrange
        var data = InputReader.Read(new[] { line });

        // Act
        var result = data.IsValid2(data.Calculations[0]);

        // Assert
        result.IsValid.Should().Be(valid);

        if (valid)
            result.Operators.Should().HaveCount(data.Calculations[0].Numbers.Length - 1);
    }
}

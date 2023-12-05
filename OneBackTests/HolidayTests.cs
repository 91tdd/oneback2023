#region

using OneBackComboTrainingWeb.Domains.Holiday;

#endregion

namespace OneBackTests;

[TestFixture]
public class HolidayTests
{
    private HolidayForTest _holiday = null!;

    [SetUp]
    public void SetUp()
    {
        _holiday = new HolidayForTest();
    }

    [Test]
    public void today_is_xmas()
    {
        GivenToday(12, 25);
        ThemeShouldBe("Merry Xmas");
    }

    [Test]
    public void today_is_xmas_when_Dec_24()
    {
        GivenToday(12, 24);
        ThemeShouldBe("Merry Xmas");
    }

    [Test]
    public void today_is_not_xmas()
    {
        GivenToday(11, 25);
        ThemeShouldBe("Today is not Xmas");
    }

    [Test]
    public void today_is_not_xmas_when_Oct_24()
    {
        GivenToday(10, 24);
        ThemeShouldBe("Today is not Xmas");
    }

    private void ThemeShouldBe(string expected)
    {
        var theme = _holiday.GetTheme();
        Assert.That(theme, Is.EqualTo(expected));
    }

    private void GivenToday(int month, int day)
    {
        _holiday.Today = new DateTime(2000, month, day);
    }
}

internal class HolidayForTest : Holiday
{
    private DateTime _today;

    public DateTime Today
    {
        set => _today = value;
    }

    protected override DateTime GetToday()
    {
        return _today;
    }
}
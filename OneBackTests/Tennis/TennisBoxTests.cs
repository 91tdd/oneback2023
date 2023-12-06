#region

using OneBackComboTrainingWeb.Domains.Tennis;

#endregion

namespace OneBackTests.Tennis;

[TestFixture]
public class TennisBoxTests
{
    private TennisBox _tennisBox = null!;

    [SetUp]
    public void SetUp()
    {
        _tennisBox = new TennisBox("Eva", "Eric");
    }

    [Test]
    public void love_all()
    {
        ScoreShouldBe("love all");
    }

    [Test(Description = "all to lookup")]
    public void fifteen_love()
    {
        WhenFirstPlayerGoal();
        ScoreShouldBe("fifteen love");
    }

    [Test(Description = "lookup to lookup")]
    public void thirty_love()
    {
        GivenFirstPlayerScore(1);
        WhenFirstPlayerGoal();
        ScoreShouldBe("thirty love");
    }

    [Test(Description = "lookup to lookup")]
    public void forty_love()
    {
        GivenFirstPlayerScore(2);
        WhenFirstPlayerGoal();
        ScoreShouldBe("forty love");
    }

    [Test(Description = "lookup to all")]
    public void fifteen_all()
    {
        GivenFirstPlayerScore(1);
        WhenSecondPlayerGoal();
        ScoreShouldBe("fifteen all");
    }

    [Test(Description = "all to lookup")]
    public void fifteen_thirty()
    {
        GivenFirstPlayerScore(1);
        GivenSecondPlayerScore(1);
        WhenSecondPlayerGoal();
        ScoreShouldBe("fifteen thirty");
    }

    [Test(Description = "lookup to deuce")]
    public void deuce()
    {
        GivenFirstPlayerScore(2);
        GivenSecondPlayerScore(3);
        WhenFirstPlayerGoal();
        ScoreShouldBe("deuce");
    }

    [Test(Description = "deuce to adv")]
    public void first_player_adv()
    {
        GivenDeuce();
        WhenFirstPlayerGoal();
        ScoreShouldBe("Eva adv");
    }

    [Test(Description = "deuce to adv")]
    public void second_player_adv()
    {
        GivenDeuce();
        WhenSecondPlayerGoal();
        ScoreShouldBe("Eric adv");
    }

    [Test(Description = "adv to deuce")]
    public void adv_to_deuce()
    {
        GivenDeuce();
        GivenSecondPlayerScore(1);

        WhenFirstPlayerGoal();
        ScoreShouldBe("deuce");
    }

    [Test(Description = "adv to win")]
    public void adv_to_win()
    {
        GivenDeuce();
        GivenSecondPlayerScore(1);

        WhenSecondPlayerGoal();
        ScoreShouldBe("Eric win");
    }

    [Test(Description = "lookup to win")]
    public void lookup_to_win()
    {
        GivenFirstPlayerScore(3);
        GivenSecondPlayerScore(1);

        WhenFirstPlayerGoal();
        ScoreShouldBe("Eva win");
    }

    private void GivenDeuce()
    {
        GivenFirstPlayerScore(3);
        GivenSecondPlayerScore(3);
    }

    private void GivenSecondPlayerScore(int times)
    {
        for (int i = 0; i < times; i++)
        {
            _tennisBox.SecondPlayerGoal();
        }
    }

    private void WhenSecondPlayerGoal()
    {
        _tennisBox.SecondPlayerGoal();
    }

    private void WhenFirstPlayerGoal()
    {
        _tennisBox.FirstPlayerGoal();
    }

    private void GivenFirstPlayerScore(int times)
    {
        for (int i = 0; i < times; i++)
        {
            _tennisBox.FirstPlayerGoal();
        }
    }

    private void ScoreShouldBe(string expected)
    {
        Assert.AreEqual(expected, _tennisBox.Score());
    }
}
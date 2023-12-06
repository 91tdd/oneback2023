﻿#region

using OneBackComboTrainingWeb.Domains.Tennis;

#endregion

namespace OneBackTests.Tennis;

[TestFixture]
public class TennisGameTests
{
    private TennisGame _tennisGame = null!;

    [SetUp]
    public void SetUp()
    {
        _tennisGame = new TennisGame("Eva", "Eric");
    }

    [Test]
    public void love_all()
    {
        ScoreShouldBe("love all");
    }

    [Test]
    public void fifteen_love()
    {
        GivenFirstPlayerScore(1);
        ScoreShouldBe("fifteen love");
    }

    [Test]
    public void thirty_love()
    {
        GivenFirstPlayerScore(2);
        ScoreShouldBe("thirty love");
    }

    [Test]
    public void forty_love()
    {
        GivenFirstPlayerScore(3);
        ScoreShouldBe("forty love");
    }

    [Test]
    public void love_fifteen()
    {
        GivenSecondPlayerScore(1);
        ScoreShouldBe("love fifteen");
    }

    [Test]
    public void love_thirty()
    {
        GivenSecondPlayerScore(2);
        ScoreShouldBe("love thirty");
    }

    [Test]
    public void fifteen_all()
    {
        GivenFirstPlayerScore(1);
        GivenSecondPlayerScore(1);
        ScoreShouldBe("fifteen all");
    }

    [Test]
    public void thirty_all()
    {
        GivenFirstPlayerScore(2);
        GivenSecondPlayerScore(2);
        ScoreShouldBe("thirty all");
    }

    [Test]
    public void deuce()
    {
        GivenFirstPlayerScore(3);
        GivenSecondPlayerScore(3);
        ScoreShouldBe("deuce");
    }

    [Test]
    public void first_player_adv()
    {
        GivenDeuce();
        GivenFirstPlayerScore(1);
        ScoreShouldBe("Eva adv");
    }

    [Test]
    public void second_player_adv()
    {
        GivenDeuce();
        GivenSecondPlayerScore(1);
        ScoreShouldBe("Eric adv");
    }

    [Test]
    public void second_player_win()
    {
        GivenDeuce();
        GivenSecondPlayerScore(2);
        ScoreShouldBe("Eric win");
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
            _tennisGame.AddSecondPlayerScore();
        }
    }

    private void GivenFirstPlayerScore(int times)
    {
        for (int i = 0; i < times; i++)
        {
            _tennisGame.AddFirstPlayerScore();
        }
    }

    private void ScoreShouldBe(string expected)
    {
        Assert.That(_tennisGame.Score(), Is.EqualTo(expected));
    }
}
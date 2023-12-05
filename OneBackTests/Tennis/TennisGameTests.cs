#region

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
        _tennisGame = new TennisGame();
    }

    [Test]
    public void love_all()
    {
        ScoreShouldBe("love all");
    }

    private void ScoreShouldBe(string expected)
    {
        Assert.That(_tennisGame.Score(), Is.EqualTo(expected));
    }
}
namespace OneBackTests.Tennis;

[TestFixture]
public class TennisGameTests
{
    [Test]
    public void love_all()
    {
        var tennisGame = new TennisGame();
        Assert.AreEqual("love all", tennisGame.Score());
    }
}

public class TennisGame
{
    public string Score()
    {
        throw new NotImplementedException();
    }
}
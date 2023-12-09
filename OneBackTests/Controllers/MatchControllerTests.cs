#region

using FluentAssertions;
using NSubstitute;
using OneBackComboTrainingWeb.Controllers;
using OneBackComboTrainingWeb.Domains;
using OneBackComboTrainingWeb.Enums;
using OneBackComboTrainingWeb.Repos;

#endregion

namespace OneBackTests.Controllers;

[TestFixture]
public class MatchControllerTests
{
    private MatchController _matchController = null!;
    private IMatchRepo _matchRepo = null!;

    [SetUp]
    public void SetUp()
    {
        _matchRepo = Substitute.For<IMatchRepo>();
        _matchController = new MatchController(_matchRepo);
    }

    [Test]
    public void home_goal()
    {
        GivenMatchResultFromRepo(""); 
        AfterEventDisplayScoreShouldBe(Event.HomeGoal, "1:0 (First Half)");
    }

    private void AfterEventDisplayScoreShouldBe(Event @event, string expected)
    {
        int matchId = 91;
        var displayScore = _matchController.UpdateMatchResult(matchId, @event);
        displayScore.Should().Be(expected);
    }

    private void GivenMatchResultFromRepo(string matchResult)
    {
        _matchRepo.GetMatch(91).Returns(new Match() { Id = 91, MatchResult = new MatchResult(matchResult) });
    }
}
#region

using FluentAssertions;
using NSubstitute;
using OneBackComboTrainingWeb.Controllers;
using OneBackComboTrainingWeb.Domains;
using OneBackComboTrainingWeb.Enums;
using OneBackComboTrainingWeb.Exceptions;
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
        RepoShouldUpdateMatchResult("H");
    }

    [Test]
    public void away_goal()
    {
        GivenMatchResultFromRepo("H");
        AfterEventDisplayScoreShouldBe(Event.AwayGoal, "1:1 (First Half)");
        RepoShouldUpdateMatchResult("HA");
    }

    [Test]
    public void next_period()
    {
        GivenMatchResultFromRepo("HA");
        AfterEventDisplayScoreShouldBe(Event.NextPeriod, "1:1 (Second Half)");
        RepoShouldUpdateMatchResult("HA;");
    }

    [Test]
    public void home_goal_when_2nd_period()
    {
        GivenMatchResultFromRepo("HA;");
        AfterEventDisplayScoreShouldBe(Event.HomeGoal, "2:1 (Second Half)");
        RepoShouldUpdateMatchResult("HA;H");
    }

    [Test]
    public void cancel_home_goal()
    {
        GivenMatchResultFromRepo("HA;H");
        AfterEventDisplayScoreShouldBe(Event.CancelHomeGoal, "1:1 (Second Half)");
        RepoShouldUpdateMatchResult("HA;");
    }

    [Test]
    public void cancel_home_goal_fail()
    {
        GivenMatchResultFromRepo("HA;A");
        Action action = () => _matchController.UpdateMatchResult(91, Event.CancelHomeGoal);
        action.Should().Throw<MatchResultException>();
    }

    private void RepoShouldUpdateMatchResult(string matchResult)
    {
        _matchRepo.Received(1).UpdateMatchResult(Arg.Is<Match>(match => match.MatchResult.GetResult() == matchResult));
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
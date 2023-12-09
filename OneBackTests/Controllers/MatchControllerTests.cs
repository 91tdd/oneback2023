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
    [Test]
    public void home_goal()
    {
        var matchRepo = Substitute.For<IMatchRepo>();
        var matchController = new MatchController(matchRepo);

        matchRepo.GetMatch(91).Returns(new Match() { Id = 91, MatchResult = new MatchResult("") });

        int matchId = 91;
        var displayScore = matchController.UpdateMatchResult(matchId, Event.HomeGoal);
        displayScore.Should().Be("1:0 (First Half)");
    }
}
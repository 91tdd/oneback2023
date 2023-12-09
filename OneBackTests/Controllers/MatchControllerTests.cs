#region

using FluentAssertions;
using NSubstitute;
using OneBackComboTrainingWeb.Controllers;
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
        int matchId = 91;
        var displayScore = matchController.UpdateMatchResult(matchId, Event.HomeGoal);
        displayScore.Should().Be("1:0 (First Half)");
    }
}
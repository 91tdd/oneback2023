#region

using FluentAssertions;
using OneBackComboTrainingWeb.Controllers;
using OneBackComboTrainingWeb.Enums;

#endregion

namespace OneBackTests.Controllers;

[TestFixture]
public class MatchControllerTests
{
    [Test]
    public void home_goal()
    {
        var matchController = new MatchController();
        int matchId = 91;
        var displayScore = matchController.UpdateMatchResult(matchId, Event.HomeGoal);
        displayScore.Should().Be("1:0 (First Half)");
    }
}
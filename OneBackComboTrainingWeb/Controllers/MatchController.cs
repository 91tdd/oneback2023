#region

using Microsoft.AspNetCore.Mvc;
using OneBackComboTrainingWeb.Enums;
using OneBackComboTrainingWeb.Repos;

#endregion

namespace OneBackComboTrainingWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchRepo _matchRepo;

        public MatchController(IMatchRepo matchRepo)
        {
            _matchRepo = matchRepo;
        }

        public string UpdateMatchResult(int matchId, Event @event)
        {
            var match = _matchRepo.GetMatch(matchId);
            match.MatchResult.HomeGoal();
            return GetDisplayScore();
        }

        private static string GetDisplayScore()
        {
            var homeScore = "1";
            var awayScore = "0";
            return $"{homeScore}:{awayScore} (First Half)";
        }
    }
}
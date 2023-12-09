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
            if (@event == Event.HomeGoal)
            {
                match.MatchResult.HomeGoal();
            }
            else if (@event == Event.AwayGoal)
            {
                match.MatchResult.AwayGoal();
            }

            _matchRepo.UpdateMatchResult(match);
            return match.MatchResult.GetDisplayScore();
        }
    }
}
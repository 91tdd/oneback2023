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
            switch (@event)
            {
                case Event.HomeGoal:
                    match.MatchResult.HomeGoal();
                    break;
                case Event.AwayGoal:
                    match.MatchResult.AwayGoal();
                    break;
                case Event.NextPeriod:
                    match.MatchResult.NextPeriod();
                    break;
                case Event.CancelHomeGoal:
                    match.MatchResult.CancelHomeGoal();
                    break;
                case Event.CancelAwayGoal:
                    match.MatchResult.CancelAwayGoal();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(@event), @event, null);
            }

            _matchRepo.UpdateMatchResult(match);
            return match.MatchResult.GetDisplayScore();
        }
    }
}
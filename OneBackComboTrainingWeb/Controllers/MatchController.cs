#region

using Microsoft.AspNetCore.Mvc;
using OneBackComboTrainingWeb.Domains;
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
            UpdateBy(@event, match.MatchResult);

            _matchRepo.UpdateMatchResult(match);
            return match.MatchResult.GetDisplayScore();
        }

        private static void UpdateBy(Event @event, MatchResult matchResult)
        {
            switch (@event)
            {
                case Event.HomeGoal:
                    matchResult.HomeGoal();
                    break;
                case Event.AwayGoal:
                    matchResult.AwayGoal();
                    break;
                case Event.NextPeriod:
                    matchResult.NextPeriod();
                    break;
                case Event.CancelHomeGoal:
                    matchResult.CancelHomeGoal();
                    break;
                case Event.CancelAwayGoal:
                    matchResult.CancelAwayGoal();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(@event), @event, null);
            }
        }
    }
}
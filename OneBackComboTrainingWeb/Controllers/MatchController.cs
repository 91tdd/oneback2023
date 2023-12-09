#region

using Microsoft.AspNetCore.Mvc;
using OneBackComboTrainingWeb.Enums;

#endregion

namespace OneBackComboTrainingWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        public string UpdateMatchResult(int matchId, Event @event)
        {
            var homeScore = "1";
            var awayScore = "0";
            return $"{homeScore}:{awayScore} (First Half)";
        }
    }
}
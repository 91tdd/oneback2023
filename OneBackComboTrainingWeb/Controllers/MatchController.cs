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
            return "1:0 (First Half)";
        }
    }
}
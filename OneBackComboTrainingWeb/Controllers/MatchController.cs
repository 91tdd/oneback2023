using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneBackComboTrainingWeb.Enums;

namespace OneBackComboTrainingWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        public string UpdateMatchResult(int matchId, Event @event)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleships.Application;
using Battleships.Application.Game.Commands.StartGame;
using Battleships.Application.Game.Queries;
using Battleships.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Battleships.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : BaseController
    {
        [HttpPost]
        [SwaggerOperation("Start new game")]
        public async Task<ActionResult<int>> StartNewGame(StartNewGameCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
           
        }

        [HttpGet("{gameId}/state")]
        [SwaggerOperation("Get game state")]
        public async Task<IActionResult> GetGameState([FromRoute] int gameId)
        {
            var query = new GetGameStateQuery(gameId);
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}

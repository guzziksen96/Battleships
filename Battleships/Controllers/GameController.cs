using System;
using System.Threading.Tasks;
using Battleships.Application.Game.Commands.FireNewShot;
using Battleships.Application.Game.Commands.StartGame;
using Battleships.Application.Game.Queries;
using Battleships.Application.Game.Queries.GetPendingGameState;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Battleships.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : BaseController
    {
        [HttpPost]
        [OpenApiOperation("Start a new game", "Start a new game")]
        public async Task<ActionResult<Guid>> StartNewGame(StartNewGameCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
           
        }

        //todo - used only when user lost to display computer ships
        [HttpGet("{gameId}/finalState")]
        [OpenApiOperation("Get final game state", "Get final game state")]
        public async Task<IActionResult> GetFinalGameState([FromRoute] Guid gameId)
        {
            var query = new GetFinalGameStateQuery(gameId);
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{gameId}/state")]
        [OpenApiOperation("Get game state", "Get game state")]
        public async Task<IActionResult> GetPendingGameState([FromRoute] Guid gameId)
        {
            var query = new GetPendingGameStateQuery(gameId);
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("{gameId}/shot")]
        [OpenApiOperation("Fire a new shot", "Fire a new shot")]
        public async Task<ActionResult<int>> FireNewShot([FromRoute] Guid gameId, FireNewShotCommand command)
        {
            command.SetGameId(gameId);
            var result = await Mediator.Send(command);
            return Ok(result);

        }
    }
}

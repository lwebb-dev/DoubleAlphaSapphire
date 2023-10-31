using DoubleAlphaSapphire.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System;
using DoubleAlphaSapphire.Data;

namespace DoubleAlphaSapphire.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly ILogger<PlayersController> logger;
        private readonly IPlayerService playerService;

        public PlayersController(ILogger<PlayersController> logger, IPlayerService playerService)
        {
            this.logger = logger;
            this.playerService = playerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayersAsync()
        {
            try
            {
                return Ok(await this.playerService.GetPlayersAsync());
            }
            catch (Exception ex)
            {
                this.logger.LogError("GET ~/api/players/ threw an Exception: {Message}", ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("{playerIdString}")]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayersAsync(string playerIdString)
        {
            if (!Guid.TryParse(playerIdString, out Guid playerId))
            {
                return BadRequest();
            }

            try
            {
                return Ok(await this.playerService.GetPlayerByIdAsync(playerId));
            }
            catch (Exception ex)
            {
                this.logger.LogError("GET ~/api/players/{playerId} threw an Exception: {Message}", playerId, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<int>>> CreatePlayersAsync([FromBody] string[] playerNames)
        {
            try
            {
                return Ok(await this.playerService.CreatePlayersAsync(playerNames));
            }
            catch (Exception ex)
            {
                this.logger.LogError("POST ~/api/players/ threw an Exception: {Message}", ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<IEnumerable<int>>> DeletePlayersByIdsAsync([FromBody] string[] playerIds)
        {
            var parsedPlayerIds = new List<Guid>();

            foreach (string playerId in playerIds)
            {
                if (!Guid.TryParse(playerId, out Guid parsedPlayerId))
                {
                    return BadRequest();
                }

                parsedPlayerIds.Add(parsedPlayerId);
            }

            try
            {
                return Ok(await this.playerService.DeletePlayersByIdsAsync(parsedPlayerIds));
            }
            catch (Exception ex)
            {
                this.logger.LogError("DELETE ~/api/players/ threw an Exception: {Message}", ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}

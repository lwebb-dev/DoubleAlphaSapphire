using DoubleAlphaSapphire.Data;
using DoubleAlphaSapphire.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System;

namespace DoubleAlphaSapphire.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly ILogger<PokemonController> logger;
        private readonly IPokemonService pokemonService;

        public PokemonController(ILogger<PokemonController> logger, IPokemonService pokemonService)
        {
            this.logger = logger;
            this.pokemonService = pokemonService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pokemon>>> GetPokemonAsync()
        {
            try
            {
                return Ok(await this.pokemonService.GetPokemonAsync());
            }
            catch (Exception ex)
            {
                this.logger.LogError("GET ~/api/pokemon/ threw an Exception: {Message}", ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("{dexId}")]
        public async Task<ActionResult<Pokemon>> GetPokemonByDexIdAsync(int dexId)
        {
            try
            {
                return Ok(await this.pokemonService.GetPokemonByDexIdAsync(dexId));
            }
            catch (Exception ex)
            {
                this.logger.LogError("GET ~/api/pokemon/{dexId} threw an Exception: {Message}", dexId, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Player>>> CreatePlayersAsync([FromBody] Pokemon[] pokemon)
        {
            try
            {
                return Ok(await this.pokemonService.CreatePokemonAsync(pokemon));
            }
            catch (Exception ex)
            {
                this.logger.LogError("POST ~/api/pokemon/ threw an Exception: {Message}", ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<IEnumerable<int>>> DeletePokemonByDexIdsAsync([FromBody] int[] dexIds)
        {
            try
            {
                return Ok(await this.pokemonService.DeletePokemonByDexIdsAsync(dexIds));
            }
            catch (Exception ex)
            {
                this.logger.LogError("DELETE ~/api/pokemon/ threw an Exception: {Message}", ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}

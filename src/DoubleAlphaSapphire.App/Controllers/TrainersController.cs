using DoubleAlphaSapphire.Data;
using DoubleAlphaSapphire.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace DoubleAlphaSapphireApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        private readonly ILogger<TrainersController> logger;
        private readonly ITrainerService trainerService;

        public TrainersController(ILogger<TrainersController> logger, ITrainerService trainerService)
        {
            this.logger = logger;
            this.trainerService = trainerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trainer>>> GetTrainersAsync()
        {
            try
            {
                return Ok(await this.trainerService.GetTrainersAsync());
            }
            catch (Exception ex)
            {
                this.logger.LogError("GET ~/api/trainers/ threw an Exception: {Message}", ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("{trainerIdString}")]
        public async Task<ActionResult<IEnumerable<Trainer>>> GetTrainersAsync(string trainerIdString)
        {
            if (!Guid.TryParse(trainerIdString, out Guid trainerId))
            {
                return BadRequest();
            }

            try
            {
                return Ok(await this.trainerService.GetTrainerByIdAsync(trainerId));
            }
            catch (Exception ex)
            {
                this.logger.LogError("GET ~/api/trainers/{trainerId} threw an Exception: {Message}", trainerId, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<int>>> CreateTrainersAsync([FromBody] string[] trainerNames)
        {
            try
            {
                return Ok(await this.trainerService.CreateTrainersAsync(trainerNames));
            }
            catch (Exception ex)
            {
                this.logger.LogError("POST ~/api/trainers/ threw an Exception: {Message}", ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<IEnumerable<int>>> DeleteTrainersByIdsAsync([FromBody] string[] trainerIds)
        {
            var parsedTrainerIds = new List<Guid>();

            foreach (string trainerId in trainerIds)
            {
                if (!Guid.TryParse(trainerId, out Guid parsedTrainerId))
                {
                    return BadRequest();
                }

                parsedTrainerIds.Add(parsedTrainerId);
            }

            try
            {
                return Ok(await this.trainerService.DeleteTrainersByIdsAsync(parsedTrainerIds));
            }
            catch (Exception ex)
            {
                this.logger.LogError("DELETE ~/api/trainers/ threw an Exception: {Message}", ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}

using DoubleAlphaSapphire.Data;
using DoubleAlphaSapphire.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoubleAlphaSapphire.Domain.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly ILogger<ITrainerService> logger;
        private readonly DasDbContext dbContext;

        public TrainerService(ILogger<ITrainerService> logger, DasDbContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Adds a range of Trainers to the database using a collection of supplied names.
        /// </summary>
        /// <param name="trainerNames">Names of Trainers to be added. TrainerId will be auto-generated.</param>
        /// <returns>Count of how many records were added.</returns>
        public async Task<int> CreateTrainersAsync(IEnumerable<string> trainerNames)
        {
            int result = 0;
            var trainers = new List<Trainer>();

            foreach (string trainerName in trainerNames)
            {
                trainers.Add(new Trainer 
                { 
                    TrainerId = Guid.NewGuid(), 
                    TrainerName = trainerName 
                });
            }

            try
            {
                await this.dbContext.Trainers.AddRangeAsync(trainers);
                result = await this.dbContext.SaveChangesAsync();

                if (result <= 0)
                {
                    this.logger.LogWarning($"CreateTrainersAsync resulted in zero changes.");
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError($"CreateTrainersAsync failed to create Trainers: {ex.Message}");
            }

            return result;
        }

        /// <summary>
        /// Removes a range of Trainers from the database using a collection of supplied TrainerIds.
        /// </summary>
        /// <param name="trainerIds">Primary key for the rows that are to be removed.</param>
        /// <returns>Count of how many records were removed.</returns>
        public async Task<int> DeleteTrainersByIdsAsync(IEnumerable<Guid> trainerIds)
        {
            int result = 0;

            try
            {
                IEnumerable<Trainer> removeSet = this.dbContext
                    .Trainers
                    .Where(x => trainerIds.Contains(x.TrainerId));

                this.dbContext
                    .Trainers
                    .RemoveRange(removeSet);

                result = await this.dbContext.SaveChangesAsync();

                if (result <= 0)
                {
                    this.logger.LogWarning($"DeleteTrainersByIdsAsync resulted in zero changes.");
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError($"DeleteTrainersByIdsAsync failed to delete Trainers: {ex.Message}");
            }

            return result;
        }

        /// <summary>
        /// Returns a single trainer using provided TrainerId.
        /// </summary>
        /// <param name="trainerId">Primary key for the trainer row in the database.</param>
        /// <returns>A single NULLABLE Trainer object.</returns>
        public async Task<Trainer> GetTrainerByIdAsync(Guid trainerId)
        {
            Trainer result =  await this.dbContext
                .Trainers
                .FirstOrDefaultAsync(x => x.TrainerId == trainerId);

            if (result == null)
            {
                this.logger.LogWarning($"GetTrainerByIdAsync using trainerId {trainerId} returned null.");
            }

            return result;
        }

        /// <summary>
        /// Returns every Trainer in the database.
        /// TODO: This should utilize pagination at some point.
        /// </summary>
        /// <returns>A collection of all Trainers in the database.</returns>
        public async Task<IEnumerable<Trainer>> GetTrainersAsync()
        {
            Trainer[] result = await this.dbContext
                .Trainers
                .ToArrayAsync();

            if (result.Length <= 0)
            {
                this.logger.LogWarning($"GetTrainersAsync returned an empty set.");
            }

            return result.ToList();
        }
    }
}

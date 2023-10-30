using DoubleAlphaSapphire.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoubleAlphaSapphire.Domain.Services.Interfaces
{
    public interface ITrainerService
    {
        /// <summary>
        /// Returns every Trainer in the database.
        /// TODO: This should utilize pagination at some point.
        /// </summary>
        /// <returns>A collection of all Trainers in the database.</returns>
        Task<IEnumerable<Trainer>> GetTrainersAsync();

        /// <summary>
        /// Returns a single trainer using provided TrainerId.
        /// </summary>
        /// <param name="trainerId">Primary key for the trainer row in the database.</param>
        /// <returns>A single NULLABLE Trainer object.</returns>
        Task<Trainer> GetTrainerByIdAsync(Guid trainerId);

        /// <summary>
        /// Adds a range of Trainers to the database using a collection of supplied names.
        /// </summary>
        /// <param name="trainerNames">Names of Trainers to be added. TrainerId will be auto-generated.</param>
        /// <returns>Count of how many records were added.</returns>
        Task<int> CreateTrainersAsync(IEnumerable<string> trainerNames);

        /// <summary>
        /// Removes a range of Trainers from the database using a collection of supplied TrainerIds.
        /// </summary>
        /// <param name="trainerIds">Primary key for the rows that are to be removed.</param>
        /// <returns>Count of how many records were removed.</returns>
        Task<int> DeleteTrainersByIdsAsync(IEnumerable<Guid> trainerIds);
    }
}

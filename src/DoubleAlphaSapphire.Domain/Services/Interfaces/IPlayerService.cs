using DoubleAlphaSapphire.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoubleAlphaSapphire.Domain.Services.Interfaces
{
    public interface IPlayerService
    {
        /// <summary>
        /// Returns every Player in the database.
        /// TODO: This should utilize pagination at some point.
        /// </summary>
        /// <returns>A collection of all Players in the database.</returns>
        Task<IEnumerable<Player>> GetPlayersAsync();

        /// <summary>
        /// Returns a single Player using provided PlayerId.
        /// </summary>
        /// <param name="PlayerId">Primary key for the Player row in the database.</param>
        /// <returns>A single NULLABLE Player object.</returns>
        Task<Player> GetPlayerByIdAsync(Guid playerId);

        /// <summary>
        /// Adds a range of Players to the database using a collection of supplied names.
        /// </summary>
        /// <param name="PlayerNames">Names of Players to be added. PlayerId will be auto-generated.</param>
        /// <returns>Count of how many records were added.</returns>
        Task<int> CreatePlayersAsync(IEnumerable<string> playerNames);

        /// <summary>
        /// Removes a range of Players from the database using a collection of supplied PlayerIds.
        /// </summary>
        /// <param name="PlayerIds">Primary key for the rows that are to be removed.</param>
        /// <returns>Count of how many records were removed.</returns>
        Task<int> DeletePlayersByIdsAsync(IEnumerable<Guid> playerIds);
    }
}

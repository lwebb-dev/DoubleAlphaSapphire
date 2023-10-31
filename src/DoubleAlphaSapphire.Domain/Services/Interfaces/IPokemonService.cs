using DoubleAlphaSapphire.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleAlphaSapphire.Domain.Services.Interfaces
{
    public interface IPokemonService
    {
        /// <summary>
        /// Returns every Pokemon in the database.
        /// TODO: This should utilize pagination at some point.
        /// </summary>
        /// <returns>A collection of all Pokemon in the database.</returns>
        Task<IEnumerable<Pokemon>> GetPokemonAsync();

        /// <summary>
        /// Returns a single Pokemon using provided DexId.
        /// </summary>
        /// <param name="dexId">Primary key for the Pokemon row in the database.</param>
        /// <returns>A single NULLABLE Pokemon object.</returns>
        Task<Pokemon> GetPokemonByDexIdAsync(int dexId);

        /// <summary>
        /// Adds a range of Pokemon to the database using a collection of supplied Pokemon objects.
        /// </summary>
        /// <param name="pokemon">Pokemon records to be added.</param>
        /// <returns>Count of how many records were added.</returns>
        Task<int> CreatePokemonAsync(IEnumerable<Pokemon> pokemon);

        /// <summary>
        /// Removes a range of Pokemon from the database using a collection of supplied dexIds.
        /// </summary>
        /// <param name="dexIds">Primary key for the rows that are to be removed.</param>
        /// <returns>Count of how many records were removed.</returns>
        Task<int> DeletePokemonByDexIdsAsync(IEnumerable<int> dexIds);

    }
}

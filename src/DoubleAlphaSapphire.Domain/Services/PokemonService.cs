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
    public class PokemonService : IPokemonService
    {
        private readonly ILogger<IPokemonService> logger;
        private readonly DasDbContext dbContext;

        public PokemonService(ILogger<IPokemonService> logger, DasDbContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Pokemon>> GetPokemonAsync()
        {
            Pokemon[] result = await this.dbContext
                .Pokemon
                .ToArrayAsync();

            if (result.Length <= 0)
            {
                this.logger.LogWarning($"GetPokemonAsync returned an empty set.");
            }

            return result.ToList();
        }

        public async Task<Pokemon> GetPokemonByDexIdAsync(int dexId)
        {
            Pokemon result = await this.dbContext
                .Pokemon
                .FirstOrDefaultAsync(x => x.DexId == dexId);

            if (result == null)
            {
                this.logger.LogWarning("GetPokemonByDexIdAsync using DexId {dexId} returned null.", dexId);
            }

            return result;
        }

        public async Task<int> CreatePokemonAsync(IEnumerable<Pokemon> pokemon)
        {
            int result = 0;

            try
            {
                await this.dbContext.Pokemon.AddRangeAsync(pokemon);
                result = await this.dbContext.SaveChangesAsync();

                if (result <= 0)
                {
                    this.logger.LogWarning("CreatePokemonAsync resuted in zerp changes.");
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError("CreatePokemonAsync failed to create Pokemon: {Message}", ex.Message);
            }

            return result;
        }

        public async Task<int> DeletePokemonByDexIdsAsync(IEnumerable<int> dexIds)
        {
            int result = 0;

            try
            {
                IEnumerable<Pokemon> pokemon = this.dbContext
                    .Pokemon
                    .Where(x => dexIds.Contains(x.DexId));

                this.dbContext.Pokemon.RemoveRange(pokemon);
                result = await this.dbContext.SaveChangesAsync();

                if (result <= 0)
                {
                    this.logger.LogWarning("DeletePokemonByDexIdsAsync resulted in zero changes.");
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError("DeletePokemonByDexIdsAsync failed to delete Pokemon: {Message}", ex.Message);
            }

            return result;
        }
    }
}

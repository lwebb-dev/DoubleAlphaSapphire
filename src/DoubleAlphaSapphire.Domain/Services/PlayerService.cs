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
    public class PlayerService : IPlayerService
    {
        private readonly ILogger<IPlayerService> logger;
        private readonly DasDbContext dbContext;

        public PlayerService(ILogger<IPlayerService> logger, DasDbContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        public async Task<int> CreatePlayersAsync(IEnumerable<string> playerNames)
        {
            int result = 0;
            var players = new List<Player>();

            foreach (string playerName in playerNames)
            {
                players.Add(new Player
                {
                    PlayerId = Guid.NewGuid(),
                    PlayerName = playerName
                });
            }

            try
            {
                await this.dbContext.Players.AddRangeAsync(players);
                result = await this.dbContext.SaveChangesAsync();

                if (result <= 0)
                {
                    this.logger.LogWarning($"CreatePlayersAsync resulted in zero changes.");
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError("CreatePlayersAsync failed to create Players: {Message}", ex.Message);
            }

            return result;
        }

        public async Task<int> DeletePlayersByIdsAsync(IEnumerable<Guid> playerIds)
        {
            int result = 0;

            try
            {
                IEnumerable<Player> removeSet = this.dbContext
                    .Players
                    .Where(x => playerIds.Contains(x.PlayerId));

                this.dbContext
                    .Players
                    .RemoveRange(removeSet);

                result = await this.dbContext.SaveChangesAsync();

                if (result <= 0)
                {
                    this.logger.LogWarning($"DeletePlayersByIdsAsync resulted in zero changes.");
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError("DeletePlayersByIdsAsync failed to delete Players: {Message}", ex.Message);
            }

            return result;
        }

        public async Task<Player> GetPlayerByIdAsync(Guid playerId)
        {
            Player result = await this.dbContext
                .Players
                .FirstOrDefaultAsync(x => x.PlayerId == playerId);

            if (result == null)
            {
                this.logger.LogWarning("GetPlayerByIdAsync using PlayerId {PlayerId} returned null.", playerId);
            }

            return result;
        }

        public async Task<IEnumerable<Player>> GetPlayersAsync()
        {
            Player[] result = await this.dbContext
                .Players
                .ToArrayAsync();

            if (result.Length <= 0)
            {
                this.logger.LogWarning($"GetPlayersAsync returned an empty set.");
            }

            return result.ToList();
        }

    }
}

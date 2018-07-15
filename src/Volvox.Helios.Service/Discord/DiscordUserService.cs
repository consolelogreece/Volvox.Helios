﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Volvox.Helios.Domain.Discord;
using Volvox.Helios.Service.Clients;

namespace Volvox.Helios.Service.Discord
{
    public class DiscordUserService : IDiscordUserService
    {
        private readonly DiscordAPIClient _client;

        public DiscordUserService(DiscordAPIClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Get all of the logged in users guilds.
        /// </summary>
        /// <returns>List of all of the logged in users guilds.</returns>
        public async Task<List<Guild>> GetUserGuilds()
        {
            var guilds = await _client.GetUserGuilds();
            
            var b = JsonConvert.DeserializeObject<List<Guild>>(guilds);

            return b;
        }
    }
}
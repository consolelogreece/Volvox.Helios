﻿using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volvox.Helios.Core.Bot;
using Volvox.Helios.Core.Modules.Common;
using Volvox.Helios.Domain.Module.ModerationModule.Common;
using Volvox.Helios.Service.BackgroundJobs;
using Volvox.Helios.Service.EntityService;

namespace Volvox.Helios.Core.Jobs
{
    public class RemoveExpiredWarningsJob
    {
        private IBot _bot;
        private IJobService _jobService;
        private readonly ILogger<IModule> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public RemoveExpiredWarningsJob(IJobService jobService,
            IServiceScopeFactory scopeFactory,
            IBot bot,
            ILogger<IModule> logger)
        {
            _jobService = jobService;
            _scopeFactory = scopeFactory;
            _logger = logger;
            _bot = bot;
        }

        public async Task Run()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var warningService = scope.ServiceProvider.GetRequiredService<IEntityService<Warning>>();

                var warningsToDelete = await warningService.Get(x => x.WarningExpires < DateTimeOffset.Now);

                await warningService.RemoveBulk(warningsToDelete);

                _logger.LogInformation($"Moderation Module: Removed {warningsToDelete.Count} expired warnings.");
            }
        }
    }
}
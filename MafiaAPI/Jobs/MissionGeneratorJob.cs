using System;
using System.Threading.Tasks;
using MafiaAPI.Models;
using MafiaAPI.Repositories;
using MafiaAPI.Service;
using Microsoft.Extensions.Logging;
using Quartz;
using Quartz.Impl;
using Quartz.Xml.JobSchedulingData20;

namespace MafiaAPI.Jobs
{

    [DisallowConcurrentExecution]
    public class MissionGeneratorJob : IJob
    {
        private readonly ILogger<MissionGeneratorJob> _logger;
        private readonly IMissionService _missionService;
        public MissionGeneratorJob(
            ILogger<MissionGeneratorJob> logger,
            IMissionService missionService
            )
        {
            _logger = logger;
            _missionService = missionService;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            JobKey key = context.JobDetail.Key;
            _missionService.GenerateMissions();
        }

        public async static void Start(ISchedulerFactory factory)
        {
            IScheduler scheduler = await factory.GetScheduler();
            IJobDetail job = PrepareJobDetail();
            ITrigger trigger = PrepareTrigger();

            await scheduler.ScheduleJob(job, trigger);
        }

        private static IJobDetail PrepareJobDetail()
        {
            return JobBuilder.Create<MissionJob>()
                .WithIdentity("missionGeneratorJob", "group1")
                .Build();
        }

        private static ITrigger PrepareTrigger()
        {
            return TriggerBuilder.Create()
                .WithIdentity("missionGeneratorTrigger", "group1")
                .StartAt(DateBuilder.EvenMinuteDate(null))
                .WithSimpleSchedule(x => x
                    .WithIntervalInMinutes(5)
                    .RepeatForever())
                .Build();
        }
    }

}
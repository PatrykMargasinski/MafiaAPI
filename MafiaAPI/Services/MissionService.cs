using System;
using MafiaAPI.Jobs;
using MafiaAPI.Models;
using MafiaAPI.Repositories;
using MafiaAPI.Services.Messages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quartz;

namespace MafiaAPI.Service
{
    public class MissionService : IMissionService
    {
        private readonly ISchedulerFactory _scheduler;
        private readonly IMissionRepository _missionRepository;
        private readonly IPerformingMissionService _pmService;
        private readonly IBossRepository _bossRepository;
        private readonly IAgentService _agentService;
        private readonly IReportService _reportService;
        private readonly ILogger<MissionService> _logger;
        public MissionService(ISchedulerFactory scheduler,
                              IPerformingMissionService pmService,
                              IMissionRepository missionRepository,
                              ILogger<MissionService> logger,
                              IBossRepository bossRepository,
                              IAgentService agentService,
                              IReportService reportService)
        {
            _scheduler = scheduler;
            _pmService = pmService;
            _missionRepository = missionRepository;
            _logger = logger;
            _bossRepository = bossRepository;
            _agentService = agentService;
            _reportService = reportService;
        }
        public IActionResult DoMission(long agentId, long missionId)
        {
            Mission mission = _missionRepository.GetById(missionId);
            if (mission == null)
            {
                return new NotFoundObjectResult("Mission with id " + missionId + " not found!");
            }
            if (!_agentService.Exist(agentId))
            {
                return new NotFoundObjectResult("Agent with id " + agentId + " not found!");
            }
            if (!_pmService.IsOnMission(agentId))
            {
                return new BadRequestObjectResult("Agent " + agentId + " is not available.");
            }
            if (!_agentService.HasBoss(agentId))
            {
                return new BadRequestObjectResult("Agent " + agentId + " is without boss");
            }
            DateTime missionFinishTime = DateTime.Now.AddSeconds(mission.Duration);
            long pmId = _pmService.CreateAndGetId(missionId, agentId, missionFinishTime);
            MissionJob.Start(_scheduler, pmId, missionFinishTime);
            _logger.LogInformation(mission.Name + " has started. Duration: " + mission.Duration + "s");
            return new OkResult();
        }
        public void EndMission(long pmId)
        {
            PerformingMission pm = _pmService.GetById(pmId);
            if (pm == null)
            {
                _logger.LogError("No pm with given id " + pmId + "!");
                return;
            }
            Agent agent = pm.Agent;
            Mission mission = pm.Mission;
            if (!agent.HasBoss())
            {
                _logger.LogError("Agent with id " + agent.Id + " has no boss but he went on mission!");
                return;
            }
            long bossId = agent.BossId.Value;
            Boss boss = _bossRepository.GetById(bossId);
            String info = "Agent " + agent.FirstName + " " + agent.LastName +
                " has finished mission: " + mission.Name;
            if (new Random().NextDouble() < CalculateMissionSuccessRate(mission, agent))
            {
                boss.AddMoney(mission.Loot);
                _bossRepository.Update(boss);
                info += "\nMission success! \n";
                info += boss.LastName +
                " family has earned " + mission.Loot+"$";
            }
            else
            {
                info += ("\nMission failed.\n");
            }
            _logger.LogInformation(info);
            _reportService.CreateReport(bossId, "Mission: " + mission.Name, info);
            _pmService.Delete(pm);
        }
        public static double CalculateMissionSuccessRate(Mission mission, Agent agent) =>
             ((11 - mission.DifficultyLevel) +
             agent.Strength + agent.Intelligence + agent.Dexterity)
             * 100 / 44;

        public void GenerateMissions()
        {
            
        }
    }
}

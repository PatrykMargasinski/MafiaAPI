using MafiaAPI.Models;
using MafiaAPI.Repositories;
using System;
using System.Collections.Generic;

namespace MafiaAPI.Service
{
    public class AgentService : IAgentService
    {
        IAgentRepository _agentRepository;
        IAgentForSaleRepository _agentForSaleRepository;
        IBossRepository _bossRepository;

        public AgentService(IAgentRepository agentRepository, IAgentForSaleRepository agentForSaleRepository, IBossRepository bossRepository)
        {
            _agentRepository = agentRepository;
            _agentForSaleRepository = agentForSaleRepository;
            _bossRepository = bossRepository;
        }

        public IList<AgentForSaleDTO> GetAgentsForSale()
        {
            return _agentForSaleRepository.GetAgentsForSale();
        }

        public string RecruitAgent(long bossId, long agentId)
        {
            try
            {
                var recruitedAgent = _agentRepository.GetById(agentId);
                var recrutingBoss = _bossRepository.GetById(bossId);
                var agentOnSale = _agentForSaleRepository.GetByAgentId(agentId);
                if (recrutingBoss.Money < agentOnSale.Price)
                    return "You don't have enough money to buy this agent";
                recrutingBoss.Money -= agentOnSale.Price;
                recruitedAgent.BossId = recrutingBoss.Id;
                _agentForSaleRepository.Delete(agentOnSale);
                _bossRepository.Update(recrutingBoss);
                _agentRepository.Update(recruitedAgent);
                return $"Agent {recruitedAgent.FirstName} {recruitedAgent.LastName} is at your service.";
            }
            catch (Exception ex)
            {
                return "Something happened: " + ex.Message;
            }
        }

        public bool HasBoss(long agentId)
        {
            return _agentRepository
                .GetById(agentId).HasBoss();
        }

        public bool Exist(long agentId)
        {
            return _agentRepository.GetById(agentId) != null;
        }
    }
}
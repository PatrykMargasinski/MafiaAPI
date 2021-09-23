using MafiaAPI.Models;
using MafiaAPI.Repositories;
using System;

namespace MafiaAPI.Factories
{
    public class AgentFactory
    {
        private readonly IFirstNameRepository _firstNameRepository;
        private readonly ILastNameRepository _lastNameRepository;
        public AgentFactory(IFirstNameRepository firstNameRepository, ILastNameRepository lastNameRepository)
        {
            _firstNameRepository = firstNameRepository;
            _lastNameRepository = lastNameRepository;
        }

        public Agent Create(string firstName = null, string lastName = null, int? strength = null, int? dexterity = null, int? intelligence = null, int? income = null)
        {
            var rand = new Random();
            return new Agent()
            {
                FirstName = firstName ?? _firstNameRepository.GetRandom().Name,
                LastName = lastName ?? _lastNameRepository.GetRandom().Name,
                Strength = strength ?? rand.Next(2, 10),
                Dexterity = dexterity ?? rand.Next(2, 10),
                Intelligence = intelligence ?? rand.Next(2, 10),
                Income = income ?? rand.Next(2, 10) * 10
            };
        }
    }
}

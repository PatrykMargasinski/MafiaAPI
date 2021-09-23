using MafiaAPI.Models;
using MafiaAPI.Util;
using System.Collections.Generic;
using System.Linq;

namespace MafiaAPI.Validators
{
    public class RegisterValidator
    {
        public string[] Validate(RegisterDTO model)
        {
            if (model == null)
            {
                return new string[] { "There is no data" };
            }
            IList<string> errors = new List<string>();
            if (model.Nick == "") errors.Add("Nick is empty");
            if (model.Password == "") errors.Add("Password is empty");
            if (model.BossFirstName == "") errors.Add("Boss first name is empty");
            if (!Utils.IsAlphabets(model.BossFirstName)) errors.Add("Boss first name should include only alphabets");
            if (model.BossLastName == "") errors.Add("Boss last name is empty");
            if (!Utils.IsAlphabets(model.BossLastName)) errors.Add("Boss last name should include only alphabets");
            if (model.AgentNames.Length != 3) errors.Add("Wrong number of agent first names");
            for (int i = 0; i < model.AgentNames.Length; i++)
            {
                if (model.AgentNames[i] == "")
                    errors.Add($"Agent{i}'s first name is empty");
                if (!Utils.IsAlphabets(model.AgentNames[i]))
                    errors.Add($"Agent{i}'s first name should include only alphabets");
            }
            return errors.ToArray();
        }
    }
}

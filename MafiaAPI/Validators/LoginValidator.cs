using MafiaAPI.Models;
using MafiaAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Validators
{
    public class LoginValidator
    {
        public string[] Validate(LoginDto model)
        {
            if (model == null)
            {
                return new string[] { "There is no data" };
            }

            IList<string> errors = new List<string>();
            if (model.Nick == "") errors.Add("Nick is empty");
            if (model.Password == "") errors.Add("Password is empty");
            return errors.ToArray();
        }
    }
}

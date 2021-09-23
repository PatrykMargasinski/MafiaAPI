using MafiaAPI.Models;
using System.Collections.Generic;
using System.Linq;

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

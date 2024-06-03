using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Domain.Entities
{
    public class RegisterUser(User user, string rawPassword)
    {
        public string RawPassword { get; set; } = rawPassword;
        public User User { get; set; } = user;
    }
}

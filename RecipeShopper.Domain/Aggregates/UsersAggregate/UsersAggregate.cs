using RecipeShopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Domain.Aggregates.UsersAggregate
{
    public class UsersAggregate
    {
        public UsersAggregate(List<User> users ) {
            Users = users;
        }
        public List<User> Users { get; private set; }

    }
}

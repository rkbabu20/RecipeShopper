using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeShopper.Domain.Aggregates;
using RecipeShopper.Domain.Aggregates.UsersAggregate;

namespace RecipeShopper.Contracts
{
    public interface IUsersRepository
    {
        Task<UsersAggregate> GetAll();
        Task<UsersAggregate> GetUser(string userId);
        Task Add(UsersAggregate user);
        Task Update(UsersAggregate user);
        Task Delete(string userId);
    }
}

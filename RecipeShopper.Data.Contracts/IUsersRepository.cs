using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeShopper.Domain.Aggregates;
using RecipeShopper.Domain.Aggregates.UsersAggregate;
using RecipeShopper.Data.Contracts.BaseContracts;

namespace RecipeShopper.Data.Contracts
{
    /// <summary>
    /// Interface for users repository
    /// </summary>
    public interface IUsersRepository : IGetAllAsync<UsersAggregate>, ICreateUpdateAsyncRepository<UsersAggregate>, IAsynRepository<GenericRequest, UsersAggregate>
    {
        /// <summary>
        /// Find user by email
        /// </summary>
        /// <param name="email">email</param>
        /// <returns>UsersAggregate</returns>
       Task<UsersAggregate> GetUserByEmailAsync(string email);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeShopper.Domain.Aggregates;
using RecipeShopper.Domain.Aggregates.UsersAggregate;
using RecipeShopper.Contracts.BaseContracts;

namespace RecipeShopper.Contracts
{
    /// <summary>
    /// Interface for users repository
    /// </summary>
    public interface IUsersRepository : IGetAllAsync<UsersAggregate>, ICreateUpdateAsyncRepository<UsersAggregate>, IAsynRepository<GenericRequest, UsersAggregate>;
}

using RecipeShopper.Contracts;
using RecipeShopper.Domain.Aggregates;
using RecipeShopper.Domain.Aggregates.LoginAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Data.Repositories
{
    /// <summary>
    /// Login repository
    /// </summary>
    public class LoginRepository : ILoginRepository
    {
        public Task DeleteAsync(GenericRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<LogInAggregate> GetAsync(GenericRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

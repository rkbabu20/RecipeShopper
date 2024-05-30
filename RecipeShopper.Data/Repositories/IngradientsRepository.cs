using RecipeShopper.Contracts;
using RecipeShopper.Domain.Aggregates;
using RecipeShopper.Domain.Aggregates.IngradientsAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Data.Repositories
{
    /// <summary>
    /// Ingradient repository
    /// </summary>
    public class IngradientsRepository : IIngradientsRepository
    {
        public Task AddAsync(IngradientsAggrigate request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(GenericRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<IngradientsAggrigate> GetAsync(GenericRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<IngradientsAggrigate> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(IngradientsAggrigate request)
        {
            throw new NotImplementedException();
        }
    }
}

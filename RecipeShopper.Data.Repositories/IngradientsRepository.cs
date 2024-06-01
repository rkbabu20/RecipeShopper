using RecipeShopper.Data.Contracts;
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
        public Task AddAsync(StockIngradientsAggrigate request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(GenericRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<StockIngradientsAggrigate> GetAsync(GenericRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<StockIngradientsAggrigate> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(StockIngradientsAggrigate request)
        {
            throw new NotImplementedException();
        }
    }
}

using RecipeShopper.Data.Contracts;
using RecipeShopper.Domain.Aggregates;
using RecipeShopper.Domain.Aggregates.OrdersAggrigate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Data.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        public Task AddAsync(OrdersAggregate request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(GenericRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<OrdersAggregate> GetAsync(GenericRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<OrdersAggregate> GetAllAsync(GenericRequest request)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(OrdersAggregate request)
        {
            throw new NotImplementedException();
        }
    }
}

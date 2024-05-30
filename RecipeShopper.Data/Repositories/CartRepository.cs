using RecipeShopper.Contracts;
using RecipeShopper.Domain.Aggregates;
using RecipeShopper.Domain.Aggregates.CartAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Data.Repositories
{
    /// <summary>
    /// Cart repository
    /// </summary>
    public class CartRepository : ICartRepository
    {
        public Task AddAsync(CartAggregate request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(GenericRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<CartAggregate> GetAsync(GenericRequest request)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CartAggregate request)
        {
            throw new NotImplementedException();
        }
    }
}

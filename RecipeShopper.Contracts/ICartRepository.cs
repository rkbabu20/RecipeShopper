using RecipeShopper.Domain.Aggregates.CartAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Contracts
{
    public interface ICartRepository
    {
        Task<CartAggregate> Get(string userId);
        Task Delete(string userId);
        Task Add(CartAggregate aggregate);
        Task Update(CartAggregate aggregate);

    }
}

using RecipeShopper.Domain.Aggregates.IngradientsAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Contracts
{
    public interface IIngradientRepository
    {
        Task<IngradientsAggrigate> GetAll();
        Task Delete(string ingradientId);
        Task Add(IngradientsAggrigate ingradientAggregate);
        Task Update(IngradientsAggrigate ingradientAggregate);
    }
}

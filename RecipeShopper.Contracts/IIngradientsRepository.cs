using RecipeShopper.Contracts.BaseContracts;
using RecipeShopper.Domain.Aggregates;
using RecipeShopper.Domain.Aggregates.IngradientsAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Contracts
{
    /// <summary>
    /// Ingradients Repository interface
    /// </summary>
    public interface IIngradientsRepository : IGetAllAsync<IngradientsAggrigate>,ICreateUpdateAsyncRepository<IngradientsAggrigate>,IAsynRepository<GenericRequest,IngradientsAggrigate>;
}

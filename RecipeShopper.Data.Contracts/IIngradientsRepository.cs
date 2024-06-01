using RecipeShopper.Data.Contracts.BaseContracts;
using RecipeShopper.Domain.Aggregates;
using RecipeShopper.Domain.Aggregates.IngradientsAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Data.Contracts
{
    /// <summary>
    /// Ingradients Repository interface
    /// </summary>
    public interface IIngradientsRepository : IGetAllAsync<StockIngradientsAggrigate>,ICreateUpdateAsyncRepository<StockIngradientsAggrigate>,IAsynRepository<GenericRequest,StockIngradientsAggrigate>;
}

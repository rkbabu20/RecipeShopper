using RecipeShopper.Data.Contracts.BaseContracts;
using RecipeShopper.Domain.Aggregates;
using RecipeShopper.Domain.Aggregates.IngradientsAggregate;
using RecipeShopper.Domain.Aggregates.UsersAggregate;
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
    public interface IStockIngradientsRepository : IGetAllAsync<StockIngradientsAggrigate>,ICreateUpdateAsyncRepository<StockIngradientsAggrigate>,IAsynRepository<GenericRequest,StockIngradientsAggrigate>
    {
        /// <summary>
        /// Find StockIngradient by Name
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>UsersAggregate</returns>
        Task<StockIngradientsAggrigate> GetByNameAsync(string name);

        Task Patch(StockIngradientsAggrigate request);
    }
}

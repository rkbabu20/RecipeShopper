using RecipeShopper.Application.Contracts;
using RecipeShopper.DBContexts.DatabaseContext;
using RecipeShopper.Domain.Aggregates;
using RecipeShopper.Domain.Aggregates.IngradientsAggregate;


namespace RecipeShopper.Data.Repositories
{
    /// <summary>
    /// Ingradient repository
    /// </summary>
    /// <remarks>
    /// User repository
    /// </remarks>
    /// <param name="dbContext">dbcontext</param>
    public class StockIngradientsRepository(RecipeShopperDbContext dbContext) : IStockIngradientsRepository
    {

        #region Private variables
        RecipeShopperDbContext _dbContext = dbContext;
        #endregion

        /// <summary>
        /// Add stock ingrdients
        /// </summary>
        /// <param name="request">StockIngradientsAggrigate</param>
        /// <returns></returns>
        public async Task AddAsync(StockIngradientsAggrigate request)
        {
            if (request != null && request.StockIngradient != null)
            {
                _dbContext.StockIngradients.Add(request.StockIngradient);
                request.IsAdded = _dbContext.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Bulk add
        /// </summary>
        /// <param name="request">StockIngradientsAggrigate</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task BulkAddAsync(StockIngradientsAggrigate request)
        {
            if (request != null && request.StockIngradients != null && request.StockIngradients.Any())
            {
                // Step 1 : Add each ingradient to 
                request.StockIngradients.ForEach(sIng => _dbContext.StockIngradients.Add(sIng));
                // Step 2 : Save changes
                request.IsAdded = _dbContext.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Delete async
        /// </summary>
        /// <param name="request">GenericRequest</param>
        /// <returns></returns>
        public async Task DeleteAsync(GenericRequest request)
        {
            if (request != null && request.RequestId != Guid.Empty)
            {
                // Step 1 : Get stockingradient to remove
                var aggregate = await GetAsync(request).ConfigureAwait(false);
                if (aggregate != null && aggregate.StockIngradient != null)
                {
                    // Step 2 : Remove stock ingradient
                    _dbContext.StockIngradients.Remove(aggregate.StockIngradient!);
                    // Step 3 : Save db changes
                    _dbContext.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Get async
        /// </summary>
        /// <param name="request">GenericRequest</param>
        /// <returns>StockIngradientsAggrigate</returns>
        public async Task<StockIngradientsAggrigate> GetAsync(GenericRequest request)
        {
            return new StockIngradientsAggrigate(_dbContext.StockIngradients.Find(request.RequestId));
        }

        /// <summary>
        /// Get all stock ingradients
        /// </summary>
        /// <returns>StockIngradientsAggrigate</returns>
        public async Task<StockIngradientsAggrigate> GetAllAsync()
        {
            return new StockIngradientsAggrigate(_dbContext.StockIngradients.ToList());
        }

        /// <summary>
        /// Update stock ingradient
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task UpdateAsync(StockIngradientsAggrigate request)
        {
            if (request != null && request.StockIngradient != null)
            {
                // Step 1: Get stock ingradient
                var aggregate = await GetAsync(new GenericRequest() { RequestId = request.StockIngradient.StockIngradientId }).ConfigureAwait(false);
                if (aggregate != null && aggregate.StockIngradient != null)
                {
                    // Step 2 : Update the existing ingradient with new data
                    aggregate.StockIngradient.AvailableQuantity = request.StockIngradient.AvailableQuantity;
                    aggregate.StockIngradient.QuantityType = request.StockIngradient.QuantityType;
                    aggregate.StockIngradient.Description = request.StockIngradient.Description;
                    aggregate.StockIngradient.Name= request.StockIngradient.Name;
                    aggregate.StockIngradient.ModifiedDate = DateTime.Now;
                    // Step 3 : Save db changes
                    request.IsUpdated = _dbContext.SaveChanges()>0;
                }
            }
        }

        /// <summary>
        /// Get the stock ingradent by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<StockIngradientsAggrigate> GetByNameAsync(string name)
        {
            var stockIngradientAggregate = new StockIngradientsAggrigate(stockIngradient: null!);
            try
            {
                // Step 1 : Get stock ingradient by name
                stockIngradientAggregate = new StockIngradientsAggrigate(_dbContext.StockIngradients.ToList().First(u => u.Name == name));
            }
            catch { }//Exception ignored intentionally
            return stockIngradientAggregate!;
        }

        /// <summary>
        /// Path the stock ingradent to update the available quantity
        /// </summary>
        /// <param name="request">StockIngradientsAggrigate</param>
        /// <returns></returns>
        public async Task PatchAsync(StockIngradientsAggrigate request)
        {
            if (request != null && request.StockIngradient != null)
            {
                var aggregate = await GetAsync(new GenericRequest() { RequestId = request.StockIngradient.StockIngradientId }).ConfigureAwait(false);
                if (aggregate != null && aggregate.StockIngradient != null)
                {
                    aggregate.StockIngradient.AvailableQuantity = request.StockIngradient.AvailableQuantity;
                    aggregate.StockIngradient.ModifiedDate = DateTime.Now;
                   request.IsPatched = _dbContext.SaveChanges()>0;
                }
            }
        }// End Patch
    }
}

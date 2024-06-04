using Azure.Core;
using Microsoft.EntityFrameworkCore;
using RecipeShopper.Application.Contracts;
using RecipeShopper.DBContexts.DatabaseContext;
using RecipeShopper.Domain.Aggregates;
using RecipeShopper.Domain.Aggregates.IngradientsAggregate;
using RecipeShopper.Domain.Aggregates.UsersAggregate;
using RecipeShopper.Domain.Entities;
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
    /// <remarks>
    /// User repository
    /// </remarks>
    /// <param name="dbContext">dbcontext</param>
    public class StockIngradientsRepository(RecipeShopperDbContext dbContext) : IStockIngradientsRepository
    {

        #region Private variables
        RecipeShopperDbContext _dbContext = dbContext;
        #endregion

        public async Task AddAsync(StockIngradientsAggrigate request)
        {
            if (request != null && request.StockIngradient != null)
            {
                request.StockIngradient.CreateDate = DateTime.Now;
                request.StockIngradient.ModifiedDate = DateTime.Now;
                _dbContext.StockIngradients.Add(request.StockIngradient);
                request.IsAdded = _dbContext.SaveChanges() > 0;
            }
        }

        public async Task DeleteAsync(GenericRequest request)
        {
            if (request != null && request.RequestId != Guid.Empty)
            {
                var aggregate = await GetAsync(request).ConfigureAwait(false);
                if (aggregate != null && aggregate.StockIngradient != null)
                {
                    _dbContext.StockIngradients.Remove(aggregate.StockIngradient!);
                    _dbContext.SaveChanges();
                }
            }
        }

        public async Task<StockIngradientsAggrigate> GetAsync(GenericRequest request)
        {
            return new StockIngradientsAggrigate(_dbContext.StockIngradients.Find(request.RequestId));
        }

        public async Task<StockIngradientsAggrigate> GetAllAsync()
        {
            return new StockIngradientsAggrigate(_dbContext.StockIngradients.ToList());
        }

        public async Task UpdateAsync(StockIngradientsAggrigate request)
        {
            if (request != null && request.StockIngradient != null)
            {
                var aggregate = await GetAsync(new GenericRequest() { RequestId = request.StockIngradient.StockIngradientId }).ConfigureAwait(false);
                if (aggregate != null && aggregate.StockIngradient != null)
                {
                    aggregate.StockIngradient.AvailableQuantity = request.StockIngradient.AvailableQuantity;
                    aggregate.StockIngradient.QuantityType = request.StockIngradient.QuantityType;
                    aggregate.StockIngradient.Description = request.StockIngradient.Description;
                    aggregate.StockIngradient.Name= request.StockIngradient.Name;
                    aggregate.StockIngradient.ModifiedDate = DateTime.Now;
                    request.IsUpdated = _dbContext.SaveChanges()>0;
                }
            }
        }

        public async Task<StockIngradientsAggrigate> GetByNameAsync(string name)
        {
            var stockIngradientAggregate = new StockIngradientsAggrigate(stockIngradient: null!);
            try
            {
                stockIngradientAggregate = new StockIngradientsAggrigate(_dbContext.StockIngradients.ToList().First(u => u.Name == name));
            }
            catch { }//Exception ignored intentionally
            return stockIngradientAggregate!;
        }

        public async Task Patch(StockIngradientsAggrigate request)
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
        }
    }
}

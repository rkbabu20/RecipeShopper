using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Data.Contracts.BaseContracts
{
    /// <summary>
    /// Create update async repository
    /// </summary>
    /// <typeparam name="Trequest"></typeparam>
    public interface ICreateUpdateAsyncRepository<TRequest> 
        where TRequest : class
    {
        Task AddAsync(TRequest request);
        Task UpdateAsync(TRequest request);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Contracts.BaseContracts
{
    /// <summary>
    /// Get all by request
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public interface IGetAllByRequestAsyncRepository<TRequest, TResult>
        where TRequest : class
        where TResult : class
    {
        Task<TResult> GetAllAsync(TRequest request);
    }
}

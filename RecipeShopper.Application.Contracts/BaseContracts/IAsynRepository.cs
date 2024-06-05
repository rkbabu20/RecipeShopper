using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Contracts.BaseContracts
{
    /// <summary>
    /// IAsynRepository
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public interface IAsynRepository<TRequest, TResult>
        where TRequest : class
        where TResult : class
    {
        Task DeleteAsync(TRequest request);
        Task<TResult> GetAsync(TRequest request);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Contracts.BaseContracts
{
    public interface IGetAllByRequestAsyncRepository<TRequest, TResult>
        where TRequest : class
        where TResult : class
    {
        Task<TResult> GetAllAsync(TRequest request);
    }
}

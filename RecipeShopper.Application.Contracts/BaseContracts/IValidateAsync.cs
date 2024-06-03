using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Contracts.BaseContracts
{
    /// <summary>
    /// Validate
    /// </summary>
    /// <typeparam name="Trequest"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public interface IValidateAsync<Trequest, TResult> 
        where Trequest : class
        where TResult : class
    {
        /// <summary>
        /// Validate 
        /// </summary>
        /// <param name="request">Trequest</param>
        /// <returns>TResult</returns>
        Task<TResult> ValidateAsync(Trequest request);
    }
}

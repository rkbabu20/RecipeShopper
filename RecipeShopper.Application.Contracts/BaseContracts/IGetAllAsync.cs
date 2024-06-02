using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Contracts.BaseContracts
{
    /// <summary>
    /// Get all async
    /// </summary>
    public interface IGetAllAsync<Tresult> where Tresult : class
    {
        Task<Tresult> GetAllAsync();
    }// End
}

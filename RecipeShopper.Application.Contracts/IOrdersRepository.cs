using RecipeShopper.Application.Contracts.BaseContracts;
using RecipeShopper.Domain.Aggregates;
using RecipeShopper.Domain.Aggregates.CartAggregate;
using RecipeShopper.Domain.Aggregates.OrdersAggrigate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Contracts
{ 
    /// <summary>
    /// Orders interface
    /// </summary>
    public interface IOrdersRepository : IGetAllByRequestAsyncRepository<GenericRequest, OrdersAggregate>, IAsynRepository<GenericRequest, OrdersAggregate>
    {
        Task SubmitAsync(OrdersAggregate ordersAggregate);

    }

}

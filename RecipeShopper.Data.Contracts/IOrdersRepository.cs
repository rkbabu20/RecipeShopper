﻿using RecipeShopper.Data.Contracts.BaseContracts;
using RecipeShopper.Domain.Aggregates;
using RecipeShopper.Domain.Aggregates.CartAggregate;
using RecipeShopper.Domain.Aggregates.OrdersAggrigate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Data.Contracts
{
    /// <summary>
    /// Orders interface
    /// </summary>
    public interface IOrdersRepository : IGetAllByRequestAsyncRepository<GenericRequest, OrdersAggregate>, ICreateUpdateAsyncRepository<OrdersAggregate>, IAsynRepository<GenericRequest, OrdersAggregate>;

}

﻿using RecipeShopper.Application.Contracts.BaseContracts;
using RecipeShopper.Domain.Aggregates;
using RecipeShopper.Domain.Aggregates.CartAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Contracts
{
    /// <summary>
    /// Cart repository interface
    /// </summary>
    public interface ICartRepository : IAsynRepository<GenericRequest, CartAggregate>, ICreateUpdateAsyncRepository<CartAggregate>;
}

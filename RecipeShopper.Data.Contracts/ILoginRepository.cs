﻿using RecipeShopper.Data.Contracts.BaseContracts;
using RecipeShopper.Domain.Aggregates;
using RecipeShopper.Domain.Aggregates.LoginAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Data.Contracts
{
    public interface ILoginRepository : IAsynRepository<GenericRequest,LogInAggregate>;
}

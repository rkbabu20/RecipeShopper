using MediatR;
using RecipeShopper.CommandQuery.DTOs;
using RecipeShopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.CommandQuery.Commands.StockIngradients.AddStockIngradientCommand
{
    /// <summary>
    /// Add stock ingradient command
    /// </summary>
    public class AddStockIngradientCommand(StockIngradientDTO stockIngradient) : IRequest<AddStockIngradientCommandResponse>
    {

        public StockIngradientDTO? StockIngradient { get; set; } = stockIngradient;
    }
}

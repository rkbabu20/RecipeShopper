using AutoMapper;
using RecipeShopper.Api.Controllers.Requests.StockIngradientsRequests;
using RecipeShopper.CommandQuery.Commands.StockIngradients.AddStockIngradientCommand;
using RecipeShopper.CommandQuery.Commands.StockIngradients.PatchStockIngradientCommand;
using RecipeShopper.CommandQuery.Commands.StockIngradients.UpdateStockIngradientCommand;
using RecipeShopper.CommandQuery.DTOs;

namespace RecipeShopper.Api.Controllers.AutoMapperProfiles
{
    /// <summary>
    /// Stock ingradient profile mapping
    /// </summary>
    public class StockIngradientProfileMapping : Profile
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public StockIngradientProfileMapping()
        {
            CreateMap<StockIngradientAddRequest, StockIngradientDTO>();
            CreateMap<StockIngradientUpdateRequest, StockIngradientDTO>();
            CreateMap<StockIngradientPatchRequest, PatchStockIngradientCommand>();
        }
    }
}

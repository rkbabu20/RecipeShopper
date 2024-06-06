using AutoMapper;
using RecipeShopper.Api.Controllers.Requests.StockIngradientsRequests;
using RecipeShopper.Application.Services.DTOs;
using RecipeShopper.Application.Services.FunctionalFeature.StockIngradients.Commands.BulkAddStockIngradientCommand;
using RecipeShopper.Application.Services.FunctionalFeature.StockIngradients.Commands.PatchStockIngradientCommand;

namespace RecipeShopper.Api.Controllers.AutoMapperProfiles
{
    /// <summary>
    /// Stock ingradient profile mapping
    /// </summary>
    public class StockIngradientProfileMapping : Profile
    {
        /// <summary>
        /// StockIngradientProfileMapping
        /// </summary>
        public StockIngradientProfileMapping()
        {
            CreateMap<BulkAddStockIngradientCommand, BulkStockIngradientAddRequest>().ReverseMap();
            CreateMap<StockIngradientAddRequest, StockIngradientDTO>();
            CreateMap<StockIngradientUpdateRequest, StockIngradientDTO>();
            CreateMap<StockIngradientPatchRequest, PatchStockIngradientCommand>();
        }
    }
}

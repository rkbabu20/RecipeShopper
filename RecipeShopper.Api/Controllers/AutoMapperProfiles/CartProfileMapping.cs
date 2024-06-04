using AutoMapper;
using RecipeShopper.Api.Controllers.Requests.CartRequests;
using RecipeShopper.Api.Controllers.Requests.Enums;
using RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartAddIngradientCommand;
using RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartAddRecipeCommand;
using ServiceDTO = RecipeShopper.Application.Services.DTOs;
using ServiceEnum = RecipeShopper.Application.Services.Enums;

namespace RecipeShopper.Api.Controllers.AutoMapperProfiles
{
    /// <summary>
    /// Cart profile mapping
    /// </summary>
    public class CartProfileMapping : Profile
    {
        public CartProfileMapping()
        {
            #region Cart Add request mappint
            CreateMap<CartAddRequest, ServiceDTO.CartDTO>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.TotalPrice, opt => opt.Ignore())
              .ForMember(dest => dest.IsOrderComplete, opt => opt.Ignore())
              .ForMember(dest => dest.User, opt => opt.Ignore())
              .ForMember(dest => dest.Recipes, opt => opt.MapFrom(src => src.Recipies))
              .ReverseMap();
            #endregion

            #region Cart Recipe Add Request
            CreateMap<CartAddRecipeRequest, CartAddRecipeCommand>()
              .ReverseMap();
            #endregion

            #region CartIngradientAddRequest
            CreateMap<CartAddIngradientRequest, CartAddIngradientCommand>()
              .ReverseMap();
            #endregion

            #region Common mappings
            CreateMap<RecipeRequest, ServiceDTO.RecipeDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Ingradients, opt => opt.MapFrom(src => src.Ingredients))
                .ReverseMap();

            CreateMap<CartIngradientRequest, ServiceDTO.CartIngradientDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.QuantityType, opt => opt.MapFrom(src => src.QuantityType))
                .ForMember(dest => dest.OrderedQuantity, opt => opt.MapFrom(src => src.OrderedQuantity))
                .ForMember(dest => dest.StockIngradientId, opt => opt.MapFrom(src => src.StockIngradientId))
                .ForMember(dest => dest.CartIngradientId, opt => opt.MapFrom(src => src.CartIngradientId))
                .ReverseMap();

            CreateMap<IngradientQuantityType, ServiceEnum.IngradientQuantityType>().ReverseMap();
            #endregion
        }
    }
}

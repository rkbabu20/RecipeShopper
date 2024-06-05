using AutoMapper;
using RecipeShopper.Api.Controllers.Requests.CartRequests;
using RecipeShopper.Api.Controllers.Requests.Enums;
using RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartAddIngradientCommand;
using RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartAddRecipeCommand;
using RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartDeleteIngradientCommand;
using RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartDeleteRecipeCommand;
using RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartUpdateIngradientCommand;
using RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartUpdateRecipeCommand;
using ServiceDTO = RecipeShopper.Application.Services.DTOs;
using ServiceEnum = RecipeShopper.Application.Services.Enums;

namespace RecipeShopper.Api.Controllers.AutoMapperProfiles
{
    /// <summary>
    /// Cart profile mapping
    /// </summary>
    public class CartProfileMapping : Profile
    {
        /// <summary>
        /// Cart profile mapping
        /// </summary>
        public CartProfileMapping()
        {
            #region Cart Add request mappint
            CreateMap<CartAddRequest, ServiceDTO.CartDTO>()
              .ForMember(dest => dest.CartId, opt => opt.Ignore())
              .ForMember(dest => dest.TotalPrice, opt => opt.Ignore())
              .ForMember(dest => dest.IsOrderComplete, opt => opt.Ignore())
              .ForMember(dest => dest.Recipes, opt => opt.MapFrom(src => src.Recipies))
              .ReverseMap();
            #endregion

            #region Cart Recipe Add Request
            CreateMap<CartAddRecipeRequest, CartAddRecipeCommand>()
              .ReverseMap();
            #endregion

            #region Cart Recipe update Request
            CreateMap<CartUpdateRecipeRequest, CartUpdateRecipeCommand>()
              .ReverseMap();
            #endregion

            #region Cart Recipe Delete Request
            CreateMap<CartDeleteRecipeRequest, CartDeleteRecipeCommand>()
              .ReverseMap();
            #endregion

            #region CartIngradientAddRequest
            CreateMap<CartAddIngradientRequest, CartAddIngradientCommand>()
              .ReverseMap();
            #endregion

            #region CartIngradientDeleteRequest
            CreateMap<CartDeleteIngradientRequest, CartDeleteIngradientCommand>()
              .ReverseMap();
            #endregion
            #region CartIngradientUpdaeRequest
            CreateMap<CartUpdateIngradientRequest, CartUpdateIngradientCommand>()
              .ReverseMap();
            #endregion
            
            #region Common mappings
            CreateMap<RecipeRequest, ServiceDTO.RecipeDTO>()
                .ForMember(dest => dest.RecipeId, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Ingradients, opt => opt.MapFrom(src => src.Ingredients))
                .ReverseMap();

            CreateMap<RecipeRequestWithId, ServiceDTO.RecipeDTO>()
                .ForMember(dest => dest.RecipeId, opt => opt.MapFrom(src=>src.RecipeId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Ingradients, opt => opt.MapFrom(src => src.Ingredients))
                .ReverseMap();

            CreateMap<CartIngradientRequest, ServiceDTO.CartIngradientDTO>()
                .ForMember(dest => dest.Name, opt => opt.Ignore())
                .ForMember(dest => dest.QuantityType, opt => opt.Ignore())
                .ForMember(dest => dest.OrderedQuantity, opt => opt.MapFrom(src => src.OrderedQuantity))
                .ForMember(dest => dest.StockIngradientId, opt => opt.MapFrom(src => src.StockIngradientId))
                .ForMember(dest => dest.CartIngradientId, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<IngradientUOMType, ServiceEnum.IngradientQuantityUnitOfMeasure>().ReverseMap();
            #endregion
        }
    }
}

using AutoMapper;
using RecipeShopper.Application.Services.DTOs;
using RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartAddCommand;
using RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartAddIngradientCommand;
using RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartAddRecipeCommand;
using RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartDeleteCommand;
using RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartDeleteIngradientCommand;
using RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartUpdateIngradientCommand;
using RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartUpdateRecipeCommand;
using RecipeShopper.Application.Services.FunctionalFeature.Cart.Quaries.GetCartQuery;
using RecipeShopper.Application.Services.FunctionalFeature.Orders.Quaries.GetOrderQuery;
using RecipeShopper.Domain.Aggregates.CartAggregate;
using RecipeShopper.Domain.Aggregates.OrdersAggrigate;
using RecipeShopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.MapperProfiles
{
    public class CartProfileMapping : Profile
    {
        public CartProfileMapping() {

            #region Cart response mappings
            // CartQuery mapping
            CreateMap<GetCartQueryResponse, CartAggregate>()
                .ForMember(dest => dest.Cart, opt => opt.MapFrom(src => src.Cart))
                .ForMember(dest => dest.IsPatched, opt => opt.Ignore())
                .ForMember(dest => dest.IsUpdated, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.IsAdded, opt => opt.Ignore())
                .ReverseMap();

            // CartAddCommand
            CreateMap<CartAddCommandResponse, CartAggregate>()
                .ForMember(dest => dest.Cart, opt => opt.Ignore())
                .ForMember(dest => dest.IsPatched, opt => opt.Ignore())
                .ForMember(dest => dest.IsUpdated, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.IsAdded, opt => opt.Ignore())
                .ReverseMap();

            // CartAddRecipeCommandResponse
            CreateMap<CartAddRecipeCommandResponse, CartAggregate>()
                .ForMember(dest => dest.Cart, opt => opt.Ignore())
                .ForMember(dest => dest.IsPatched, opt => opt.Ignore())
                .ForMember(dest => dest.IsUpdated, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.IsAdded, opt => opt.Ignore())
                .ReverseMap();
            // CartUpdateRecipeCommandResponse
            CreateMap<CartUpdateRecipeCommandResponse, CartAggregate>()
                .ForMember(dest => dest.Cart, opt => opt.Ignore())
                .ForMember(dest => dest.IsPatched, opt => opt.Ignore())
                .ForMember(dest => dest.IsUpdated, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.IsAdded, opt => opt.Ignore())
                .ReverseMap();

            // CartDeleteCommandResponse
            CreateMap<CartDeleteCommandResponse, CartAggregate>()
                .ForMember(dest => dest.Cart, opt => opt.Ignore())
                .ForMember(dest => dest.IsPatched, opt => opt.Ignore())
                .ForMember(dest => dest.IsUpdated, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.IsAdded, opt => opt.Ignore())
                .ReverseMap();
            // CartAddIngradientCommandResponse
            CreateMap<CartAddIngradientCommandResponse, CartAggregate>()
                .ForMember(dest => dest.Cart, opt => opt.Ignore())
                .ForMember(dest => dest.IsPatched, opt => opt.Ignore())
                .ForMember(dest => dest.IsUpdated, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.IsAdded, opt => opt.Ignore())
                .ReverseMap();
            // CartDeleteIngradientCommandResponse
            CreateMap<CartDeleteIngradientCommandResponse, CartAggregate>()
                .ForMember(dest => dest.Cart, opt => opt.Ignore())
                .ForMember(dest => dest.IsPatched, opt => opt.Ignore())
                .ForMember(dest => dest.IsUpdated, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.IsAdded, opt => opt.Ignore())
                .ReverseMap();

            // CartUpdateIngradientCommandResponse
            CreateMap<CartUpdateIngradientCommandResponse, CartAggregate>()
                .ForMember(dest => dest.Cart, opt => opt.Ignore())
                .ForMember(dest => dest.IsPatched, opt => opt.Ignore())
                .ForMember(dest => dest.IsUpdated, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.IsAdded, opt => opt.Ignore())
                .ReverseMap();
            // CartUpdateRecipeCommandResponse
            CreateMap<CartDeleteIngradientCommandResponse, CartAggregate>()
                .ForMember(dest => dest.Cart, opt => opt.Ignore())
                .ForMember(dest => dest.IsPatched, opt => opt.Ignore())
                .ForMember(dest => dest.IsUpdated, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.IsAdded, opt => opt.Ignore())
                .ReverseMap();
            #endregion

            #region Common mappings
            CreateMap<Cart, CartDTO>().ReverseMap();
            CreateMap<CartIngradient, CartIngradientDTO>().ReverseMap();
            CreateMap<Recipe, RecipeDTO>().ReverseMap();
            #endregion
        }
    }
}

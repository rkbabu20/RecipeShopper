using AutoMapper;
using RecipeShopper.Application.Services.DTOs;
using RecipeShopper.Application.Services.FunctionalFeature.Orders.Commands.SubmitOrderCommand;
using RecipeShopper.Application.Services.FunctionalFeature.Orders.Quaries.GetAllOrdersQuery;
using RecipeShopper.Application.Services.FunctionalFeature.Orders.Quaries.GetOrderQuery;
using RecipeShopper.Domain.Aggregates.OrdersAggrigate;
using RecipeShopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.MapperProfiles
{
    /// <summary>
    /// Orders profile mapping
    /// </summary>
    public class OrdersProfileMapping : Profile
    {
        /// <summary>
        /// Orders profile mapping
        /// </summary>
        public OrdersProfileMapping() 
        {
            #region OrdersAggregate
            CreateMap<GetOrderQueryResponse, OrdersAggregate>()
                .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order))
                .ForMember(dest => dest.Orders, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<GetAllOrdersQueryResponse, OrdersAggregate>()
                .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders))
                .ForMember(dest => dest.Order, opt => opt.Ignore())
                .ReverseMap();

           CreateMap<SubmitOrderCommandResponse, OrdersAggregate>()
                .ForMember(dest => dest.Orders, opt => opt.Ignore())
                .ForMember(dest => dest.Order, opt => opt.Ignore())
                .ReverseMap();
            #endregion


            #region Common mappings
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Recipe, RecipeDTO>().ReverseMap();
            CreateMap<CartIngradient, CartIngradientDTO>().ReverseMap();
            #endregion
        }// End OrdersProfileMapping
    }
}

using AutoMapper;
using RecipeShopper.CommandQuery.Commands.StockIngradients.PatchStockIngradientCommand;
using RecipeShopper.CommandQuery.Commands.StockIngradients.UpdateStockIngradientCommand;
using RecipeShopper.CommandQuery.DTOs;
using RecipeShopper.CommandQuery.Quaries.StockIngradients.AllStockIngradients;
using RecipeShopper.CommandQuery.Quaries.StockIngradients.GetStockIngradient;
using RecipeShopper.Domain.Aggregates.IngradientsAggregate;
using RecipeShopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.CommandQuery.AutoMapperProfiles
{
    /// <summary>
    /// Ingradient profile mapping
    /// </summary>
    public class StockIngradientAggregateProfileMapping : Profile
    {
        public StockIngradientAggregateProfileMapping() {
            // GetAllUsersResponse mapping
            CreateMap<StockIngradientsAggrigate, GetAllStockIngradientResponse>()
                .ForMember(dest => dest.StockIngradients, opt => opt.MapFrom(src => src.StockIngradients))
                .ForMember(dest => dest.Messages, opt => opt.Ignore())
                .IncludeAllDerived()
                .ReverseMap();

            // GetUserResponse mapping
            CreateMap<StockIngradientsAggrigate, GetStockIngradientResponse>()
               .ForMember(dest => dest.StockIngradient, opt => opt.MapFrom(src => src.StockIngradient))
               .ForMember(dest => dest.Messages, opt => opt.Ignore())
               .IncludeAllDerived()
               .ReverseMap();

            CreateMap<StockIngradient, StockIngradientDTO>().ReverseMap();
            CreateMap<StockIngradient, UpdateStockIngradientCommand>().ReverseMap();
            CreateMap<StockIngradient, PatchStockIngradientCommand>().ReverseMap();
        }
    }
}

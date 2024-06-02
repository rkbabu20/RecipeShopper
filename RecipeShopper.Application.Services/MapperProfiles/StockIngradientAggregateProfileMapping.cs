using AutoMapper;
using RecipeShopper.Application.Services.DTOs;
using RecipeShopper.Application.Services.FunctionalFeature.StockIngradients.Commands.PatchStockIngradientCommand;
using RecipeShopper.Application.Services.FunctionalFeature.StockIngradients.Commands.UpdateStockIngradientCommand;
using RecipeShopper.Application.Services.FunctionalFeature.StockIngradients.Quaries.AllStockIngradients;
using RecipeShopper.Application.Services.FunctionalFeature.StockIngradients.Quaries.GetStockIngradient;
using RecipeShopper.Domain.Aggregates.IngradientsAggregate;
using RecipeShopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.MapperProfiles
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

using AutoMapper;
using RecipeShopper.Application.Services.FunctionalFeature.StockIngradients.Commands.DeleteStockIngradientCommand;
using RecipeShopper.Application.Services.FunctionalFeature.StockIngradients.Quaries.GetStockIngradient;
using RecipeShopper.Application.Services.FunctionalFeature.Users.Commands.DeleteUserCommand;
using RecipeShopper.Application.Services.FunctionalFeature.Users.Quaries.GetUserQuery;
using RecipeShopper.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.MapperProfiles
{
    internal class GenericRequestProfileMapping : Profile
    {
        public GenericRequestProfileMapping()
        {
            // DeleteUser command
            CreateMap<DeleteUserCommand, GenericRequest>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();

            // GetUserQuery
            CreateMap<GetUserQuery, GenericRequest>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();

            // GetStockIngradientQuery
            CreateMap<GetStockIngradientQuery, GenericRequest>()
                .ForMember(dest => dest.RequestId, opt => opt.MapFrom(src => src.StockIngradientId)).ReverseMap();

            // GetStockIngradientQuery
            CreateMap<DeleteStockIngradientCommand, GenericRequest>()
                .ForMember(dest => dest.RequestId, opt => opt.MapFrom(src => src.StockIngradientId)).ReverseMap();

        }
    }
}

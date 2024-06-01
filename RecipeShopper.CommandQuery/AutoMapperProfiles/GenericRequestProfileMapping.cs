using AutoMapper;
using RecipeShopper.CommandQuery.Commands.Users.DeleteUserCommand;
using RecipeShopper.CommandQuery.Quaries.Users.GetUserQuery;
using RecipeShopper.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.CommandQuery.AutoMapperProfiles
{
    internal class GenericRequestProfileMapping : Profile
    {
        public GenericRequestProfileMapping()
        {
            // DeleteUser command
            CreateMap<DeleteUserCommand, GenericRequest>()
                .ForMember(dest => dest.RequestId, opt => opt.MapFrom(src => src.UserId)).ReverseMap();

            // GetUserQuery
            CreateMap<GetUserQuery, GenericRequest>()
                .ForMember(dest => dest.RequestId, opt => opt.MapFrom(src => src.UserId)).ReverseMap();

        }
    }
}

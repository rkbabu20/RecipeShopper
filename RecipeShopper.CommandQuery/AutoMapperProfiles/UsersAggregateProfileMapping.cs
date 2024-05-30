using AutoMapper;
using RecipeShopper.CommandQuery.DTOs;
using CommandQuiriesEums = RecipeShopper.CommandQuery.Enums;
using RecipeShopper.Domain.Aggregates.UsersAggregate;
using RecipeShopper.Domain.Entities;
using DomainEnum = RecipeShopper.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeShopper.CommandQuery.Quaries.Users.AllUsersQuery;
using RecipeShopper.CommandQuery.Quaries.Users.GetUserQuery;

namespace RecipeShopper.CommandQuery.AutoMapperProfiles
{
    /// <summary>
    /// User aggregate profile mapping
    /// </summary>
    public class UsersAggregateProfileMapping : Profile
    {
        public UsersAggregateProfileMapping() {

            // GetAllUsersResponse mapping
            CreateMap<UsersAggregate, GetAllUsersResponse>()
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users))
                .ForMember(dest => dest.Messages, opt => opt.Ignore())
                .IncludeAllDerived()
                .ReverseMap();

            // GetUserResponse mapping
            CreateMap<UsersAggregate, GetUserResponse>()
               .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
               .ForMember(dest => dest.Messages, opt => opt.Ignore())
               .IncludeAllDerived()
               .ReverseMap();

            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<DomainEnum.UserRoleEnum, CommandQuiriesEums.UserRoleEnum>().ReverseMap();
        }
    }
}

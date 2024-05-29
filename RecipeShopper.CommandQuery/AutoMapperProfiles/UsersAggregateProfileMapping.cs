using AutoMapper;
using RecipeShopper.CommandQuery.DTOs;
using CommandQuiriesEums = RecipeShopper.CommandQuery.Enums;
using RecipeShopper.CommandQuery.Quaries.Users;
using RecipeShopper.Domain.Aggregates.UsersAggregate;
using RecipeShopper.Domain.Entities;
using DomainEnum=RecipeShopper.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.CommandQuery.AutoMapperProfiles
{
    /// <summary>
    /// User aggregate profile mapping
    /// </summary>
    public class UsersAggregateProfileMapping : Profile
    {
        public UsersAggregateProfileMapping() {
            CreateMap<UsersAggregate, UsersResponse>()
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users))
                .ForMember(dest => dest.Message, opt => opt.Ignore())
                .ForMember(dest => dest.Messages, opt => opt.Ignore())
                .IncludeAllDerived()
                .ReverseMap();

            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<DomainEnum.UserRoleEnum, CommandQuiriesEums.UserRoleEnum>().ReverseMap();
        }
    }
}

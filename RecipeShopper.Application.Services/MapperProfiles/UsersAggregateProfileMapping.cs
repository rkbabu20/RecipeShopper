using AutoMapper;

using RecipeShopper.Domain.Aggregates.UsersAggregate;
using RecipeShopper.Domain.Entities;
using DomainEnum = RecipeShopper.Domain.Enums;
using CommandQuiriesEums = RecipeShopper.Application.Services.Enums;
using RecipeShopper.Application.Services.FunctionalFeature.Users.Quaries.AllUsersQuery;
using RecipeShopper.Application.Services.FunctionalFeature.Users.Quaries.GetUserQuery;
using RecipeShopper.Application.Services.DTOs;

namespace RecipeShopper.Application.Services.MapperProfiles
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
            CreateMap<User, ViewUserDTO>().ReverseMap();
            CreateMap<DomainEnum.UserRoleEnum, CommandQuiriesEums.UserRoleEnum>().ReverseMap();
        }
    }
}

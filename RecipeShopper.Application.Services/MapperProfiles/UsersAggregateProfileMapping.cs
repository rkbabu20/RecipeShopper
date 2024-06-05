using AutoMapper;

using RecipeShopper.Domain.Aggregates.UsersAggregate;
using RecipeShopper.Domain.Entities;
using DomainEnum = RecipeShopper.Domain.Enums;
using CommandQuiriesEums = RecipeShopper.Application.Services.Enums;
using RecipeShopper.Application.Services.FunctionalFeature.Users.Quaries.AllUsersQuery;
using RecipeShopper.Application.Services.FunctionalFeature.Users.Quaries.GetUserQuery;
using RecipeShopper.Application.Services.DTOs;
using RecipeShopper.Application.Services.FunctionalFeature.Users.Commands.AddUserCommand;

namespace RecipeShopper.Application.Services.MapperProfiles
{
    /// <summary>
    /// User aggregate profile mapping
    /// </summary>
    public class UsersAggregateProfileMapping : Profile
    {
        public UsersAggregateProfileMapping() {

            // GetAllUsersResponse mapping
            CreateMap<UsersAggregate, GetAllUsersQueryResponse>()
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users))
                .ForMember(dest => dest.Messages, opt => opt.Ignore())
                .IncludeAllDerived()
                .ReverseMap();

            // GetUserResponse mapping
            CreateMap<UsersAggregate, GetUserQueryResponse>()
               .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
               .ForMember(dest => dest.Messages, opt => opt.Ignore())
               .IncludeAllDerived()
               .ReverseMap();

            // User DTO mapping
            CreateMap<User, AddUserCommand>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.UserName))
                .ReverseMap();

            // User DTO mapping
            CreateMap<User, UserDTO>()
                .ForMember(dest=>dest.Id,opt=>opt.MapFrom(src=>src.Id))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.UserName))
                .ReverseMap();

            CreateMap<User, ViewUserDTO>().ReverseMap();
            CreateMap<DomainEnum.UserRoleEnum, CommandQuiriesEums.RegisterUserRoleEnum>().ReverseMap();
        }
    }
}

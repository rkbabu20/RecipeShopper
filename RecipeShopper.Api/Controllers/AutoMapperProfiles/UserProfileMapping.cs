using AutoMapper;
using RecipeShopper.Api.Controllers.Requests.UserRequests;
using RecipeShopper.Application.Services.DTOs;
using RecipeShopper.Application.Services.FunctionalFeature.Users.Commands.AddUserCommand;

namespace RecipeShopper.Api.Controllers.AutoMapperProfiles
{
    /// <summary>
    /// User profile mapping
    /// </summary>
    public class UserProfileMapping : Profile
    {
        /// <summary>
        /// User profile mapping
        /// </summary>
       public UserProfileMapping()
        {
            CreateMap<UserAddRequest, AddUserCommand>().ReverseMap();
            CreateMap<UserUpdateRequest, UserDTO>()
                .ForMember(dest=>dest.Id, src=>src.MapFrom(c=>c.UserId))
                .ReverseMap();
        }
    }
}

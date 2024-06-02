using AutoMapper;
using RecipeShopper.Api.Controllers.Requests.UserRequests;
using RecipeShopper.Application.Services.DTOs;

namespace RecipeShopper.Api.Controllers.AutoMapperProfiles
{
    public class UserProfileMapping : Profile
    {
       public UserProfileMapping()
        {
            CreateMap<UserAddRequest, UserDTO>().ReverseMap();
            CreateMap<UserUpdateRequest, UserDTO>().ReverseMap();
        }
    }
}

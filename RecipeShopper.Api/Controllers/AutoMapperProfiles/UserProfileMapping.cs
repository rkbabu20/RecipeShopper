using AutoMapper;
using RecipeShopper.Api.Controllers.Requests;
using RecipeShopper.CommandQuery.DTOs;

namespace RecipeShopper.Api.Controllers.AutoMapperProfiles
{
    public class UserProfileMapping : Profile
    {
       public UserProfileMapping()
        {
            CreateMap<UserAddRequest, UserDTO>().ReverseMap();
        }
    }
}

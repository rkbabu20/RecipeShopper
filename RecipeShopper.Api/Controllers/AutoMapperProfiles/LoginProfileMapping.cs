using AutoMapper;
using RecipeShopper.Api.Controllers.Requests;
using RecipeShopper.Application.Services.DTOs;
using RecipeShopper.Application.Services.FunctionalFeature.Login.Quaries.Login;

namespace RecipeShopper.Api.Controllers.AutoMapperProfiles
{
    public class LoginProfileMapping : Profile
    {
        public LoginProfileMapping() {
            CreateMap<AuthenticationRequest, LoginDTO>().ReverseMap();
        }
    }
}

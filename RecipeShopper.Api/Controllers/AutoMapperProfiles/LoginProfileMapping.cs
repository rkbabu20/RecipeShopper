using AutoMapper;
using RecipeShopper.Api.Controllers.Requests;
using RecipeShopper.Application.Services.DTOs;
using RecipeShopper.Application.Services.FunctionalFeature.Login.Quaries.Login;

namespace RecipeShopper.Api.Controllers.AutoMapperProfiles
{
    /// <summary>
    /// Login profile mapping
    /// </summary>
    public class LoginProfileMapping : Profile
    {
        /// <summary>
        /// Login profile mapping
        /// </summary>
        public LoginProfileMapping() {
            CreateMap<AuthenticationRequest, LoginDTO>().ReverseMap();
        }
    }
}

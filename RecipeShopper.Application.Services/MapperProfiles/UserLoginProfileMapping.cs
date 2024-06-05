using AutoMapper;
using RecipeShopper.Application.Services.DTOs;
using RecipeShopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.MapperProfiles
{
    /// <summary>
    /// User login profile mapping
    /// </summary>
    public class UserLoginProfileMapping : Profile
    {
        /// <summary>
        /// User login profile mapping
        /// </summary>
        public UserLoginProfileMapping()
        {
            CreateMap<LoginDTO, Login>().ReverseMap();
        }
    }
}

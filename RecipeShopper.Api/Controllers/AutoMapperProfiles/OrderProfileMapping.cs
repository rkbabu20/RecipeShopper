using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipeShopper.Api.Controllers.Requests.OrderRequests;
using RecipeShopper.Application.Services.FunctionalFeature.Orders.Commands.SubmitOrderCommand;

namespace RecipeShopper.Api.Controllers.AutoMapperProfiles
{
    public class OrderProfileMapping : Profile
    {
        public OrderProfileMapping()
        {
            CreateMap<SubmitOrderCommand, SubmitOrderRequest>().ReverseMap();
        }
    }
}

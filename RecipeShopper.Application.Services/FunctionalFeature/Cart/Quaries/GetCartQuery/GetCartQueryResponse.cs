using RecipeShopper.Application.Services.Base;
using RecipeShopper.Application.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.FunctionalFeature.Cart.Quaries.GetCartQuery
{
    /// <summary>
    /// Cart dto
    /// </summary>
    public class GetCartQueryResponse : BaseResponse
    {
        /// <summary>
        /// Cart
        /// </summary>
        public CartDTO? Cart { get; set; }   
    }
}

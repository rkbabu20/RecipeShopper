﻿using RecipeShopper.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.DTOs.Base
{
    /// <summary>
    /// Base ingradient dto
    /// </summary>
    public class BaseIngradientDTO
    {
        /// <summary>In gradient name</summary>
        public string? Name { get; set; }
        /// <summary>Ingradient description</summary>
        public string? Description { get; set; }

        /// <summary>Price per quantity</summary>
        public decimal PricePerQuantity { get; set; }

        /// <summary>Ingradient quantity type</summary>
        public IngradientQuantityType QuantityType { get; set; }
    }
}

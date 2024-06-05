using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.Enums
{
    /// <summary>
    /// Ingradient quantity type
    /// </summary>
    public enum IngradientQuantityUnitOfMeasure
    {
        Unspecified = 0,
        Pieces = 1,
        MilliLiters = 2,
        Grams = 3
    };
}

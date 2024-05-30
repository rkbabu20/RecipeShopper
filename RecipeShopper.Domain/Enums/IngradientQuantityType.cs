using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Domain.Enums
{
    /// <summary>
    /// Ingradient quantity type
    /// </summary>
    public enum IngradientQuantityType
    {
        Unspecified = 0,
        Pieces = 1,
        MilliLiters = 2,
        Grams = 3
    };
}

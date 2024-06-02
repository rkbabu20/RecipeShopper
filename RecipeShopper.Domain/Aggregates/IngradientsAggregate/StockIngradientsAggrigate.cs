using RecipeShopper.Domain.Aggregates.Base;
using RecipeShopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Domain.Aggregates.IngradientsAggregate
{
    /// <summary>
    /// Ingradient aggregate
    /// </summary>
    public class StockIngradientsAggrigate : BaseAggregate
    {
        #region constructor
        /// <summary>
        /// Stock ingradient aggregate
        /// </summary>
        /// <param name="stockIngradients"></param>
        public StockIngradientsAggrigate(List<StockIngradient> stockIngradients)
        {
            StockIngradients = stockIngradients;
        }
        /// <summary>
        /// Stock ingradient aggregate
        /// </summary>
        /// <param name="stockIngradient"></param>
        public StockIngradientsAggrigate(StockIngradient stockIngradient)
        {
           StockIngradient = stockIngradient;
        }
        #endregion

        #region Properties
        /// <summary>Ingradient</summary>
        public StockIngradient? StockIngradient { get; set; }
        /// <summary>Ingradients</summary>
        public List<StockIngradient>? StockIngradients { get; set; }

        #endregion
    }
}

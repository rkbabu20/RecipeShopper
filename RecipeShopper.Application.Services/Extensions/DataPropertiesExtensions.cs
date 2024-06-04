using RecipeShopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.Extensions
{
    public static class DataPropertiesExtensions
    {
        /// <summary>
        /// Data properties extension
        /// </summary>
        /// <param name="dataProperties">DataProperties</param>
        /// <param name="applyCreateDate">applyCreateDate</param>
        /// <param name="applyUpdateDate">applyUpdateDate</param>
        public static void ApplyDateProperties(this DataProperties dataProperties, bool applyCreateDate, bool applyModifiedDate)
        {
            if(dataProperties!=null)
            {
                if (applyCreateDate) dataProperties.CreateDate = DateTime.Now;
                if (applyModifiedDate) dataProperties.ModifiedDate = DateTime.Now;
            }
        }
    }
}

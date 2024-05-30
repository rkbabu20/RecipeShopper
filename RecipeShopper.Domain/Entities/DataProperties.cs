using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Domain.Entities
{
    /// <summary>
    /// Standard data properties common across all tables
    /// </summary>
    public class DataProperties
    {
        /// <summary>Create date</summary>
        public DateTime CreateDate { get; set; }
        /// <summary>Modified date</summary>
        public DateTime ModifiedDate { get; set; }
    }// End DataProperties
}

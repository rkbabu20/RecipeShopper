using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Domain.Aggregates.Base
{
    /// <summary>
    /// Public base aggregate
    /// </summary>
    public class BaseAggregate
    {
        public BaseAggregate() { ApplicationErrors = new List<string>(); ValidationErrors = new List<string>(); }
        #region Properties
        /// <summary>Status to know if entity is added in db</summary>
        public bool IsAdded { get; set; }
        /// <summary>Status to know if entity is deleted from db</summary>
        public bool IsDeleted { get; set; }
        /// <summary>Status to know if entity is updated in db</summary>
        public bool IsUpdated { get; set; }
        /// <summary>Status to know if entity is partially updated</summary>
        public bool IsPatched { get; set; }
        /// <summary>Application errors</summary>
        public List<string> ApplicationErrors { get; set; }
        /// <summary>Validation errors</summary>
        public List<string> ValidationErrors { get; set; }
        #endregion

    }//End BaseAggregate
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Domain.Aggregates
{
    /// <summary>
    /// Generic request 
    /// </summary>
    public class GenericRequest
    {
        /// <summary>Request id</summary>
        public Guid RequestId { get; set; }
        public string Id { get; set; }
    }
}

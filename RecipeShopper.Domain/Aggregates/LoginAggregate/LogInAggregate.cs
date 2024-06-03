using RecipeShopper.Domain.Aggregates.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Domain.Aggregates.LoginAggregate
{
    /// <summary>
    /// Login aggregate
    /// </summary>
    public class LogInAggregate 
    {
        public bool IsLoginSuccess { get; set; }
        public string? Token { get; set; }
       
    }
}

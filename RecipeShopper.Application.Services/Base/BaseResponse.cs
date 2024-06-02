using RecipeShopper.Application.Services.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.Base
{
    /// <summary>
    /// Base response
    /// </summary>
    public class BaseResponse
    {
        /// <summary>
        /// Base Response
        /// </summary>
        public BaseResponse() 
        {
            Status = StatusTypeEnum.Success;
            Messages = new List<Message>();
        }
        public StatusTypeEnum Status { get; set; }
        public List<Message> Messages { get; set; }
    }
}

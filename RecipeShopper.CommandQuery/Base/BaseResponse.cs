using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.CommandQuery.Base
{
    /// <summary>
    /// Base response
    /// </summary>
    public class BaseResponse
    {
        public BaseResponse() { }

        public Message Message { get; set; }
        public List<Message> Messages { get; set; }
    }
}

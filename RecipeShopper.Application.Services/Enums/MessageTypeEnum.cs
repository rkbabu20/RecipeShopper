using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.Enums
{
    /// <summary>
    /// Status type
    /// </summary>
    public enum MessageTypeEnum
    {
        Unspecified,
        ValidationError,
        ApplicationError,
        NoResourceFoundError,
        Warning,
        Information
    };
}

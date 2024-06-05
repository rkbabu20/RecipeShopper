using RecipeShopper.Application.Services.Base;
using RecipeShopper.Application.Services.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.Extensions
{
    /// <summary>
    /// Messages extension
    /// </summary>
    static class MessagesExtension
    {
        #region private variables
        static List<MessageTypeEnum> _failureMessageTypes = null;
        #endregion

        #region Constructor
        /// <summary>
        /// Messages
        /// </summary>
        static MessagesExtension()
        {
            _failureMessageTypes = new List<MessageTypeEnum>()
            {
                MessageTypeEnum.ApplicationError,
                MessageTypeEnum.ValidationError,
                MessageTypeEnum.NoResourceFoundError
            };
        }
        #endregion

        #region Extension methods
        /// <summary>
        /// Get status type
        /// </summary>
        /// <param name="messages">Messages</param>
        /// <returns>StatusTypeEnum</returns>
        public static StatusTypeEnum DetermineResponseStatus(this List<Message> messages)
        {
            var statusType = StatusTypeEnum.Success;
            if(messages != null && messages.Any())
            {
                statusType = messages.Any(m => _failureMessageTypes.Contains(m.MessageType))
                    ? StatusTypeEnum.Failure 
                    : (messages.Any(m => m.MessageType == MessageTypeEnum.Warning) 
                        ? StatusTypeEnum.PartialSuccess 
                        : StatusTypeEnum.Success);
            }
            return statusType;
        }
        #endregion
    }
}

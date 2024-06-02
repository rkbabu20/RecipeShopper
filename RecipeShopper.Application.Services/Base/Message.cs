using RecipeShopper.Application.Services.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.Base
{
    /// <summary>
    /// Message
    /// </summary>
    public class Message
    {
        #region Constructors
        /// <summary>Message</summary>
        public Message() { }

        /// <summary>
        /// Message
        /// </summary>
        /// <param name="message">Message</param>
        public Message(string message)
        {
            this.message = message;
            this.MessageType = MessageTypeEnum.Information;
        }//Message 

        /// <summary>
        /// Message
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="messageType">Message type</param>
        public Message(string message, MessageTypeEnum messageType)
        {
            this.message = message;
            this.MessageType = messageType;
        }//End Message
        #endregion

        #region Properties
        /// <summary>Message</summary>
        public string? message { get; set; }
        /// <summary>Message Type</summary>
        public MessageTypeEnum MessageType { get; set; }
        #endregion
    }
}

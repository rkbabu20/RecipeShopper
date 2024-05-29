using RecipeShopper.CommandQuery.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.CommandQuery.Base
{
    /// <summary>
    /// Message
    /// </summary>
    public class Message
    {
        #region Constructors
        public Message() { }
        public Message(string message)
        {
            this.message = message;
            this.MessageCode = string.Empty;
            this.MessageType = MessageTypeEnum.Information;
        }
        public Message(string message, string messageCode)
        {
            this.message = message;
            this.MessageCode = messageCode;
            this.MessageType = MessageTypeEnum.Information;
        }
        public Message(string message, MessageTypeEnum messageType)
        {
            this.message = message;
            this.MessageType = messageType;
        }
        public Message(string message, string messageCode, MessageTypeEnum messageType)
        {
            this.message = message;
            this.MessageCode = messageCode;
            this.MessageType = messageType;
        }
        #endregion

        #region Properties
        public string? message { get; set; }
        public string? MessageCode { get; set; }
        public MessageTypeEnum MessageType { get; set; }
        #endregion
    }
}

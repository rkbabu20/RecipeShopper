using RecipeShopper.Application.Services.Enums;
using RecipeShopper.Application.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.Base
{
    /// <summary>
    /// Base handler
    /// </summary>
    public abstract class BaseHandler<TRequest, TResponse>
        where TRequest : class
        where TResponse : class
    {
        #region public members
        /// <summary>
        /// Handle message
        /// </summary>
        /// <param name="response"></param>
        /// <param name="message"></param>
        /// <param name="messageType"></param>
        protected void HandleMessage(BaseResponse response, string message)
        {
            HandleMessage(response, message, MessageTypeEnum.Information);
        }

        /// <summary>
        /// Handle message
        /// </summary>
        /// <param name="response"></param>
        /// <param name="message"></param>
        /// <param name="messageType"></param>
        protected void HandleMessage(BaseResponse response, string message, MessageTypeEnum messageType)
        {
            // Step 1 : Initialize response
            InitializeBaseResponse(response);

            // Step 2 : Add message
            response.Messages.Add(new Message(message, messageType));

            // Step 3 : Set response status
            response.Status = response.Messages.DetermineResponseStatus();
        }

        protected void HandleException(BaseResponse response,Exception ex)
        {
            HandleMessage(response, ConstructExceptionMessage(ex), MessageTypeEnum.ApplicationError);
        }

        #endregion

        #region Abstract members
        /// <summary>
        /// Validations
        /// </summary>
        /// <param name="request">Request entity</param>
        /// <param name="response">Response entity</param>
        protected abstract Task Validate(TRequest request, TResponse response);

        #endregion

        #region Private members
        /// <summary>
        /// Initialize base response
        /// </summary>
        /// <param name="response"></param>
        private void InitializeBaseResponse(BaseResponse response)
        {
            if (response == null)
                response = new BaseResponse();
            if (response.Messages == null)
                response.Messages = new List<Message>();
        }

        private string ConstructExceptionMessage(Exception ex)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if(ex!=null)
            {
                stringBuilder.Append($"Exception : {ex.Message}");
                stringBuilder.Append($"StackTrace : {ex.StackTrace}");
            }
            return stringBuilder.ToString();
        }

        #endregion
    }
}

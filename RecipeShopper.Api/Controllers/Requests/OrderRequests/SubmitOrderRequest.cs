namespace RecipeShopper.Api.Controllers.Requests.OrderRequests
{
    /// <summary>
    /// Submit order request
    /// </summary>
    public class SubmitOrderRequest
    {
        /// <summary>User Id</summary>
        public string UserId {  get; set; }
        /// <summary>Cart Id</summary>
        public string CartId { get; set; }
    }
}

namespace RecipeShopper.Api.Controllers.Requests.OrderRequests
{
    /// <summary>
    /// Submit order request
    /// </summary>
    public class SubmitOrderRequest
    {
        public string UseId {  get; set; }
        public string CartId { get; set; }
    }
}

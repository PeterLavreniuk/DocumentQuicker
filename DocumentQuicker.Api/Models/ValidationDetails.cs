namespace DocumentQuicker.Api.Models
{
    public class ValidationDetails
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
        public string AttemptedValue { get; set; }
    }
}
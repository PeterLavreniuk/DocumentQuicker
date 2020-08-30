namespace DocumentQuicker.Api.Models
{
    public sealed class ValidationDetails
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
        public string AttemptedValue { get; set; }
    }
}
namespace DocumentQuicker.Api.Models.Requests
{
    public class AuthenticateRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
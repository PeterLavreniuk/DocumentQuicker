using System;

namespace DocumentQuicker.DataProvider.Models
{
    public class UserCredentialsEf
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
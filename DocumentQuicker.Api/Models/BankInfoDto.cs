using System;

namespace DocumentQuicker.Api.Models
{
    public sealed class BankInfoDto
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set;}
        public DateTime EditDate { get; set;}
        public bool IsActive { get; set;}
        public string Description { get; set;}
        public string Bic { get; set;}
        public string CorrAccount { get; set;}
    }
}
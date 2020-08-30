using System;

namespace DocumentQuicker.Api.Models.Dto
{
    public class RequisiteDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        public string City { get; set; }
        public string RawAddress { get; set; }
        public string BankAccount { get; set; }
        public BankDto Bank { get; set; }
        public DateTime CreationDate { get; set;}
        public DateTime EditDate { get; set;}
        public bool IsActive { get; set;}
    }
}
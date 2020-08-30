using System;

namespace DocumentQuicker.Api.Models.Dto
{
    //todo append validator 
    public class ShortRequisiteDto
    {
        public string Name { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        public string City { get; set; }
        public string RawAddress { get; set; }
        public string BankAccount { get; set; }
        public Guid? BankId { get; set; }
    }
}
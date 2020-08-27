using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentQuicker.DataProvider.Models
{
    //todo set attributes for properties
    //todo rename?!
    public class BankDetailsEf : IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EditDate { get; set; }
        public bool IsActive { get; set; }
        public EntityType Type => EntityType.BankDetailsEntity;
        public string Account { get; set; }
        public BankInfoEf BankInfo { get; set; }
        public RequisiteEf Requisite { get; set; }
        [ForeignKey("Requisite")]
        public Guid RequisiteId { get; set; }
    }
}
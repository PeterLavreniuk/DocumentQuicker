using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentQuicker.DataProvider.Models
{
    //todo set attributes for properties
    public class RequisiteEf : IBaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EditDate { get; set; }
        public bool IsActive { get; set; }
        [NotMapped]
        public EntityType Type => EntityType.RequisiteEntity;
        public string Name { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        public AddressEf Address { get; set; }
        public BankDetailsEf BankDetails { get; set; }
    }
}
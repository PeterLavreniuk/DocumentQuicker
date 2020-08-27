using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentQuicker.DataProvider.Models
{
    //todo set attributes for properties
    //todo rename?
    public class AddressEf : IBaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EditDate { get; set; }
        public bool IsActive { get; set; }
        public EntityType Type => EntityType.AddressEntity;
        public string City { get; set; }
        public string RawAddress { get; set; }
        public RequisiteEf Requisite { get; set; }
        [ForeignKey("Requisite")]
        public Guid RequisiteId { get; set; }
    }
}
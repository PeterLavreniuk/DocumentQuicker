using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentQuicker.DataProvider.Models
{
    //todo set attributes for properties
    [Table("Requisites")]
    public class RequisiteEf : IBaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        public string City { get; set; }
        public string RawAddress { get; set; }        
        public string BankAccount { get; set; }
        public BankEf Bank { get; set; }
        [ForeignKey("Bank")]
        public Guid? BankId { get; set; }

        //IBaseEntity fields: 
        public DateTime CreationDate { get; set; }
        public DateTime EditDate { get; set; }
        public bool IsActive { get; set; }
        [NotMapped]
        public EntityType Type => EntityType.RequisiteEntity;
    }
}
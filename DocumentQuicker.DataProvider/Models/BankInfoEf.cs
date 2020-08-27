using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentQuicker.DataProvider.Models
{
    //todo set attributes for properties
    //todo rename?
    public class BankInfoEf : IBaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string BankDescription { get; set; }
        [Required]
        public string Bic { get; set; }
        [Required]
        public string CorrAccount { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [NotMapped] 
        public EntityType Type => EntityType.BankInfoEntity;
        public DateTime CreationDate { get; set; }
        public DateTime EditDate { get; set; }
    }
}
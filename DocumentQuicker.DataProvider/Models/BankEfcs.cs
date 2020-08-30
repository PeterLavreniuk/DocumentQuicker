using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentQuicker.DataProvider.Models
{
    //todo set attributes for properties
    [Table("Banks")]
    public class BankEf : IBaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Bic { get; set; }
        [Required]
        public string CorrAccount { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [NotMapped] 
        public EntityType Type => EntityType.BankEntity;
        public DateTime CreationDate { get; set; }
        public DateTime EditDate { get; set; }
    }
}
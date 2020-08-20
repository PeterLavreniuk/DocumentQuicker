using System;
using System.ComponentModel.DataAnnotations;

namespace DocumentQuicker.DataProvider.Models
{
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
        public DateTime CreationDate { get; set; }
        public DateTime EditDate { get; set; }
    }
}
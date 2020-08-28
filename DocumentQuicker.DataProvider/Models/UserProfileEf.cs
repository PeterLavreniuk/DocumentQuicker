using System;
using System.ComponentModel.DataAnnotations;

namespace DocumentQuicker.DataProvider.Models
{
    public class UserProfileEf : IBaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EditDate { get; set; }
        public bool IsActive { get; set; }
        public EntityType Type { get; }
        public string UserName { get; set; }
    }
}
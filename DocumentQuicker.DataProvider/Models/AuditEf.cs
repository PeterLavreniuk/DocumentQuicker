using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DocumentQuicker.DataProvider.Models
{
    /// <summary>
    /// This class does not implement IBaseEntity - that is correct
    /// </summary>
    public class AuditEf
    {
        public Guid Id { get; set; }
        public EntityType Type { get; set; }
        public AuditActionType Action { get; set; }
        public DateTime AuditDate { get; set; }
        public Guid ItemId { get; set; }

        [NotMapped]
        public PropertyEntry PrimaryKeyHolder { get; set; }
    }
}
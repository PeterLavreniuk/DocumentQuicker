using System;

namespace DocumentQuicker.DataProvider.Models
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
        DateTime CreationDate { get; set; }
        DateTime EditDate { get; set; }
        bool IsActive { get; set; }
        EntityType Type { get; }
    }
}
using System;

namespace DocumentQuicker.BusinessLayer.Models
{
    public class EntityBase
    {
        public Guid Id { get; }
        public DateTime CreationDate { get; }
        public DateTime EditDate { get; }
        public bool IsActive { get; }
        
        public EntityBase(Guid id, 
                          DateTime creationDate, 
                          DateTime editDate,
                          bool isActive)
        {
            Id = id;
            CreationDate = creationDate;
            EditDate = editDate;
            IsActive = isActive;
        }
    }
}
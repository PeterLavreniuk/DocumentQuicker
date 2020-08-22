using System;

namespace DocumentQuicker.BusinessLayer.Models
{
    public sealed class BankDetails : EntityBase
    {
        public string Account { get; }
        public BankDetails Info { get; }

        public BankDetails(string account, 
                           BankDetails info,
                           Guid id, 
                           DateTime creationDate, 
                           DateTime editDate, 
                           bool isActive) : base(id, 
                                                 creationDate, 
                                                 editDate, 
                                                 isActive)
        {
            Account = account;
            Info = info ?? throw new ArgumentNullException(nameof(Info));
        }
    }
}
using System;

namespace DocumentQuicker.BusinessLayer.Models
{
    public class Requisite : EntityBase
    {
        public Address Address { get; }
        public BankDetails BankDetails { get; }
        public string Name { get; }
        // ReSharper disable once InconsistentNaming
        public string INN { get; }
        // ReSharper disable once InconsistentNaming
        public string KPP { get; }
        

        public Requisite(Address address,
                         BankDetails bankDetails,
                         string name,
                         string inn,
                         string kpp,
                         Guid id, 
                         DateTime creationDate, 
                         DateTime editDate,
                         bool isActive) : base(id, 
                                               creationDate, 
                                               editDate,
                                               isActive)
        {
            Address = address ?? throw new ArgumentNullException(nameof(Address));
            BankDetails = bankDetails ?? throw new ArgumentNullException(nameof(BankDetails));
            Name = name;
            INN = inn;
            KPP = kpp;
        }
    }
}
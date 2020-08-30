using System;

namespace DocumentQuicker.BusinessLayer.Models
{
    public sealed class Requisite : EntityBase
    {
        public string Name { get; }
        // ReSharper disable once InconsistentNaming
        public string INN { get; }
        // ReSharper disable once InconsistentNaming
        public string KPP { get; }
        public string City { get; }
        public string RawAddress { get; }        
        public string BankAccount { get; }
        public Guid? BankId { get; }
        public Bank Bank { get; }

        public Requisite(string name, string inn, string kpp,
                         string city, string rawAddress, string bankAccount,
                         Guid? bankId, Bank bank, Guid id, 
                         DateTime creationDate, DateTime editDate, bool isActive) 
                            : base(id, creationDate, editDate,
                                   isActive)
        {
            Name = name;
            INN = inn;
            KPP = kpp;
            City = city;
            RawAddress = rawAddress;
            BankAccount = bankAccount;
            BankId = bankId;
            Bank = bank;
        }
    }
}
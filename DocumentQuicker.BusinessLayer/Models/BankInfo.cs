using System;

namespace DocumentQuicker.BusinessLayer.Models
{
    public sealed class BankInfo : EntityBase
    {
        /// <summary>
        /// bank city, name of the bank etc.
        /// </summary>
        public string Description { get; }
        public string Bic { get; }
        public string CorrAccount { get; }

        public BankInfo(string description,
                        string bic,
                        string corrAccount,
                        Guid id, 
                        DateTime creationDate, 
                        DateTime editDate, 
                        bool isActive) : base(id, 
                                              creationDate, 
                                              editDate, 
                                              isActive)
        {
            Description = description;
            Bic = bic;
            CorrAccount = corrAccount;
        }
    }
}
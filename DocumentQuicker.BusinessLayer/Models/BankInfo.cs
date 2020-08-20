using System;

namespace DocumentQuicker.BusinessLayer.Models
{
    public class BankInfo : EntityBase
    {
        /// <summary>
        /// bank city, name of the bank etc.
        /// </summary>
        public string BankDescription { get; }
        public string Bic { get; }
        public string CorrAccount { get; }

        public BankInfo(string bankDescription,
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
            BankDescription = bankDescription;
            Bic = bic;
            CorrAccount = corrAccount;
        }
    }
}
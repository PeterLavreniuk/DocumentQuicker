using System;

namespace DocumentQuicker.BusinessLayer.Models
{
    public class Address : EntityBase
    {
        public string City { get; }
        /// <summary>
        /// street/house number/postal code etc.
        /// </summary>
        public string RawAddress { get; }

        public Address(string city,
                       string rawAddress,
                       Guid id, 
                       DateTime creationDate, 
                       DateTime editDate,
                       bool isActive): base(id, 
                                            creationDate, 
                                            editDate,
                                            isActive)
        {
            City = city;
            RawAddress = rawAddress;
        }
    }
}
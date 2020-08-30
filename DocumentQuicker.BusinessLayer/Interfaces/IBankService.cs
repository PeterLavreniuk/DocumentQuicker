using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DocumentQuicker.BusinessLayer.Models;

namespace DocumentQuicker.BusinessLayer.Interfaces
{
    public interface IBankService
    {
        Task<Bank> Create(string description,
                          string bic,
                          string corrAccount);
        Task<Bank> Update(Guid id,
                          string description,
                          string bic,
                          string corrAccount);
        Task<Bank> Get(Guid id);
        Task<bool> Delete(Guid id);
        Task<IList<Bank>> Get() => Get(count: Int32.MaxValue, offset: 0);
        Task<IList<Bank>> Get(int count) => Get(count: count, offset: 0);
        Task<IList<Bank>> Get(int count, int offset);
    }
}
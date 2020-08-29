using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DocumentQuicker.BusinessLayer.Models;

namespace DocumentQuicker.BusinessLayer.Interfaces
{
    public interface IBankService
    {
        Task<Bank> Create(Bank bankInfo);
        Task<Bank> Update(Bank bankInfo);
        Task<IList<Bank>> Get();
        Task<IList<Bank>> Get(int count) => Get(count: count, offset: 0);
        Task<IList<Bank>> Get(int count, int offset);
        Task<Bank> Get(Guid id);
        Task<bool> Delete(Guid id);
    }
}
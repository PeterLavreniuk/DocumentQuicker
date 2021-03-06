using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DocumentQuicker.BusinessLayer.Models;

namespace DocumentQuicker.BusinessLayer.Interfaces
{
    public interface IRequisiteService
    {
        Task<Requisite> Create(string name, string inn, string kpp,
                               string city, string rawAddress, string bankAccount,
                               Guid? bankId);
        Task<Requisite> Update(Guid id, string name, string inn,
                               string kpp, string city, string rawAddress,
                               string bankAccount, Guid? bankId);
        Task<Requisite> Get(Guid id);
        Task<bool> Delete(Guid id);
        Task<IList<Requisite>> Get() => Get(count: Int32.MaxValue, offset: 0);
        Task<IList<Requisite>> Get(int count) => Get(count: count, offset: 0);
        Task<IList<Requisite>> Get(int count, int offset);
    }
}
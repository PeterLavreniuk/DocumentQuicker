using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DocumentQuicker.BusinessLayer.Interfaces;
using DocumentQuicker.BusinessLayer.Models;
using DocumentQuicker.DataProvider;
using DocumentQuicker.DataProvider.Models;
using Microsoft.EntityFrameworkCore;

namespace DocumentQuicker.BusinessLayer.Services
{
    internal class RequisiteService : IRequisiteService
    {
        private readonly DocumentQuickerContext _documentQuickerContext;
        private readonly IMapper _mapper;

        public RequisiteService(DocumentQuickerContext documentQuickerContext,
                                IMapper mapper)
        {
            _documentQuickerContext = documentQuickerContext ??
                                      throw new ArgumentNullException(nameof(_documentQuickerContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }

        public async Task<Requisite> Create(string name, string inn, string kpp, 
                                      string city, string rawAddress, string bankAccount, 
                                      Guid? bankId)
        {
            if (bankId != null && bankId != Guid.Empty)
            {
                var bankEf = await _documentQuickerContext.BankInfos.FirstOrDefaultAsync(x => x.Id == bankId && x.IsActive);
                if(bankEf == null)
                    throw new KeyNotFoundException($"Bank with : {bankId} not found");
            }

            var requisiteEf = new RequisiteEf()
            {
                Name = name,
                INN = inn,
                KPP = kpp,
                City = city,
                RawAddress = rawAddress,
                BankAccount = bankAccount,
                BankId = bankId == null ? null : bankId == Guid.Empty ? null : bankId
            };

            await _documentQuickerContext.Requisites.AddAsync(requisiteEf);
            await _documentQuickerContext.SaveChangesAsync();
            
            return _mapper.Map<Requisite>(requisiteEf);
        }

        public async Task<Requisite> Update(Guid id, string name, string inn, 
                                      string kpp, string city, string rawAddress, 
                                      string bankAccount, Guid? bankId)
        {
            if (bankId != null && bankId != Guid.Empty)
            {
                var bankEf = await _documentQuickerContext.BankInfos.FirstOrDefaultAsync(x => x.Id == bankId && x.IsActive);
                if(bankEf == null)
                    throw new KeyNotFoundException($"Bank with : {bankId} not found");
            }

            var requisiteEf = await _documentQuickerContext.Requisites.FirstOrDefaultAsync(x => x.Id == id);
            if(requisiteEf == null)
                throw new KeyNotFoundException($"Requisite with :{id} not found");

            requisiteEf.Name = name;
            requisiteEf.INN = inn;
            requisiteEf.KPP = kpp;
            requisiteEf.City = city;
            requisiteEf.RawAddress = rawAddress;
            requisiteEf.BankAccount = bankAccount;
            requisiteEf.BankId = bankId == null ? null : bankId == Guid.Empty ? null : bankId;

            _documentQuickerContext.Requisites.Update(requisiteEf);
            await _documentQuickerContext.SaveChangesAsync();
            
            return _mapper.Map<Requisite>(requisiteEf);
        }

        public async Task<Requisite> Get(Guid id)
        {
            var requisiteEf = await _documentQuickerContext.Requisites.FirstOrDefaultAsync(x => x.Id == id && x.IsActive);
            if (requisiteEf == null)
                throw new KeyNotFoundException($"Requisite with : {id} not found");

            return _mapper.Map<Requisite>(requisiteEf);
        }

        public async Task<bool> Delete(Guid id)
        {
            var requisiteEf = await _documentQuickerContext.Requisites.FirstOrDefaultAsync(x => x.Id == id && x.IsActive);
            if (requisiteEf == null)
                throw new KeyNotFoundException($"Requisite with : {id} not found");

            _documentQuickerContext.Requisites.Remove(requisiteEf);
            await _documentQuickerContext.SaveChangesAsync();

            return true;
        }

        public async Task<IList<Requisite>> Get(int count, int offset)
        {
            var result = await _documentQuickerContext.Requisites.Where(x => x.IsActive)
                .OrderByDescending(x => x.EditDate).Skip(offset).Take(count).ToListAsync();

            return result.Select(x => _mapper.Map<Requisite>(x)).ToList();
        }
    }
}
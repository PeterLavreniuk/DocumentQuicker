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
    internal class BankService : IBankService
    {
        private readonly DocumentQuickerContext _documentQuickerContext;
        private readonly IMapper _mapper;

        public BankService(DocumentQuickerContext documentQuickerContext,
                           IMapper mapper)
        {
            _documentQuickerContext = documentQuickerContext ??
                                      throw new ArgumentNullException(nameof(_documentQuickerContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }
        
        public async Task<Bank> Create(string description, string bic, string corrAccount)
        {
            var bankEf = new BankEf()
            {
                Description = description,
                Bic = bic,
                CorrAccount = corrAccount
            };
            
            await _documentQuickerContext.BankInfos.AddAsync(bankEf);
            await _documentQuickerContext.SaveChangesAsync();

            return _mapper.Map<Bank>(bankEf);
        }

        public async Task<Bank> Update(Guid id, string description, string bic, string corrAccount)
        {
            var bankEf = await _documentQuickerContext.BankInfos.FirstOrDefaultAsync(x => x.Id == id);
            if(bankEf == null)
                throw new KeyNotFoundException($"Bank with : {id} not found");

            bankEf.Description = description;
            bankEf.Bic = bic;
            bankEf.CorrAccount = corrAccount;

            _documentQuickerContext.BankInfos.Update(bankEf);
            await _documentQuickerContext.SaveChangesAsync();
            
            return _mapper.Map<Bank>(bankEf);
        }

        public async Task<Bank> Get(Guid id)
        {
            var bankEf = await _documentQuickerContext.BankInfos.FirstOrDefaultAsync(x => x.Id == id && x.IsActive);
            if (bankEf == null)
                throw new KeyNotFoundException($"Bank with : {id} not found");

            return _mapper.Map<Bank>(bankEf);
        }

        public async Task<bool> Delete(Guid id)
        {
            var bankEf = await _documentQuickerContext.BankInfos.FirstOrDefaultAsync(x => x.Id == id);
            if (bankEf == null)
                throw new KeyNotFoundException($"Bank with : {id} not found");
            _documentQuickerContext.BankInfos.Remove(bankEf);
            await _documentQuickerContext.SaveChangesAsync();
            return true;
        }
        
        public async Task<IList<Bank>> Get(int count, int offset)
        {
            var result = await _documentQuickerContext.BankInfos.Where(x => x.IsActive)
                .OrderByDescending(x => x.EditDate).Skip(offset).Take(count).ToListAsync();
            
            return result.Select(x => _mapper.Map<Bank>(x)).ToList();
        }
    }
}
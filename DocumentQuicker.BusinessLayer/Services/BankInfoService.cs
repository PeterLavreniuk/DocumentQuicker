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
    public class BankInfoService : IBankInfoService
    {
        private readonly DocumentQuickerContext _documentQuickerContext;
        private readonly IMapper _mapper;

        public BankInfoService(DocumentQuickerContext documentQuickerContext,
                               IMapper mapper)
        {
            _documentQuickerContext = documentQuickerContext ??
                                      throw new ArgumentNullException(nameof(_documentQuickerContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }

        public async Task<BankInfo> Create(BankInfo bankInfo)
        {
            var bankInfoEf = _mapper.Map<BankInfoEf>(bankInfo);
            await _documentQuickerContext.BankInfos.AddAsync(bankInfoEf);
            await _documentQuickerContext.SaveChangesAsync();

            return _mapper.Map<BankInfo>(bankInfoEf);
        }

        public async Task<BankInfo> Update(BankInfo bankInfo)
        {
            var bankInfoEf = await _documentQuickerContext.BankInfos.FirstOrDefaultAsync(x => x.Id == bankInfo.Id);
            if(bankInfoEf == null)
                throw new KeyNotFoundException($"Entity with : {bankInfo.Id} not found");

            bankInfoEf.BankDescription = bankInfo.Description;
            bankInfoEf.Bic = bankInfo.Bic;
            bankInfoEf.CorrAccount = bankInfo.CorrAccount;

            _documentQuickerContext.BankInfos.Update(bankInfoEf);
            await _documentQuickerContext.SaveChangesAsync();
            
            return _mapper.Map<BankInfo>(bankInfoEf);
        }

        public async Task<IList<BankInfo>> Get()
        {
            var result = await _documentQuickerContext.BankInfos.Where(x => x.IsActive)
                .OrderByDescending(x => x.EditDate).ToListAsync();

            return result.Select(x => _mapper.Map<BankInfo>(x)).ToList();
        }

        public async Task<IList<BankInfo>> Get(int count, int offset)
        {
            var result = await _documentQuickerContext.BankInfos.Where(x => x.IsActive)
                .OrderByDescending(x => x.EditDate).Skip(offset).Take(count).ToListAsync();
            
            return result.Select(x => _mapper.Map<BankInfo>(x)).ToList();
        }

        public async Task<BankInfo> Get(Guid id)
        {
            var bankInfo = await _documentQuickerContext.BankInfos.FirstOrDefaultAsync(x => x.Id == id && x.IsActive);
            if (bankInfo == null)
                throw new KeyNotFoundException($"Entity with : {id} not found");

            return _mapper.Map<BankInfo>(bankInfo);
        }

        public async Task<bool> Delete(Guid id)
        {
            var bankInfo = await _documentQuickerContext.BankInfos.FirstOrDefaultAsync(x => x.Id == id);
            if (bankInfo == null)
                throw new KeyNotFoundException($"Entity with : {id} not found");
            _documentQuickerContext.BankInfos.Remove(bankInfo);
            await _documentQuickerContext.SaveChangesAsync();
            return true;
        }
    }
}
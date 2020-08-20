using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DocumentQuicker.BusinessLayer.Interfaces;
using DocumentQuicker.BusinessLayer.Models;
using DocumentQuicker.DataProvider;
using DocumentQuicker.DataProvider.Models;

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

        public async Task<BankInfo> Create(string description, string bic, string corrAccount)
        {
            var bankInfoEf = new BankInfoEf()
            {
                BankDescription = description,
                Bic = bic,
                CorrAccount = corrAccount
            };
            await _documentQuickerContext.BankInfos.AddAsync(bankInfoEf);
            await _documentQuickerContext.SaveChangesAsync();

            return _mapper.Map<BankInfo>(bankInfoEf);
        }

        public Task<BankInfo> Edit(BankInfo info)
        {
            throw new NotImplementedException();
        }

        public Task<IList<BankInfo>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<IList<BankInfo>> Get(int count, int offset)
        {
            throw new NotImplementedException();
        }

        public Task<BankInfo> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
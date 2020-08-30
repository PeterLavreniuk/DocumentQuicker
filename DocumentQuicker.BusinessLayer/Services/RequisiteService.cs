using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DocumentQuicker.BusinessLayer.Interfaces;
using DocumentQuicker.BusinessLayer.Models;
using DocumentQuicker.DataProvider;

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
        
        
        public Task<Requisite> Create(Requisite requisite)
        {
            throw new NotImplementedException();
        }

        public Task<Requisite> Update(Requisite requisite)
        {
            throw new NotImplementedException();
        }

        public Task<Requisite> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Requisite>> Get(int count, int offset)
        {
            throw new NotImplementedException();
        }
    }
}
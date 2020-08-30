using System;
using AutoMapper;
using DocumentQuicker.Api.Models;
using DocumentQuicker.Api.Models.Dto;
using DocumentQuicker.BusinessLayer.Models;

namespace DocumentQuicker.Api.MapperProfiles
{
    public sealed class DtoToBl : Profile
    {
        public DtoToBl()
        {
            CreateMap<ShortBankDto, Bank>()
                .ConstructUsing((x, ctx) => 
                    new Bank(description: x.Description,
                             bic: x.Bic,
                             corrAccount: x.CorrAccount,
                             id: Guid.Empty,
                             creationDate: DateTime.MinValue,
                             editDate: DateTime.MinValue,
                             isActive: true));
        }
    }
}
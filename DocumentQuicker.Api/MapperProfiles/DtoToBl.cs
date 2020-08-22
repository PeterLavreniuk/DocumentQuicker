using System;
using AutoMapper;
using DocumentQuicker.Api.Models;
using DocumentQuicker.BusinessLayer.Models;

namespace DocumentQuicker.Api.MapperProfiles
{
    public sealed class DtoToBl : Profile
    {
        public DtoToBl()
        {
            CreateMap<ShortBankInfoDto, BankInfo>()
                .ConstructUsing((x, ctx) => new BankInfo(description: x.Description,
                                                                                            bic: x.Bic,
                                                                                            corrAccount: x.CorrAccount,
                                                                                            id: Guid.Empty,
                                                                                            creationDate: DateTime.MinValue,
                                                                                            editDate: DateTime.MinValue,
                                                                                            isActive: true));
        }
    }
}
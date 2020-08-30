using AutoMapper;
using DocumentQuicker.BusinessLayer.Models;
using DocumentQuicker.DataProvider.Models;

namespace DocumentQuicker.BusinessLayer.MapperProfiles
{
    public sealed class DataProviderToBl : Profile
    {
        public DataProviderToBl()
        {
            CreateMap<BankEf, Bank>()
                .ConstructUsing((x, ctx) =>
                    new Bank(id: x.Id,
                             description: x.Description,
                             bic: x.Bic,
                             creationDate: x.CreationDate,
                             editDate: x.EditDate,
                             corrAccount: x.CorrAccount,
                             isActive: x.IsActive));

            CreateMap<RequisiteEf, Requisite>()
                .ConstructUsing((x, ctx) =>
                    new Requisite(name: x.Name,
                                  inn: x.INN,
                                  kpp: x.KPP,
                                  city: x.City,
                                  rawAddress: x.RawAddress,
                                  bankAccount: x.BankAccount,
                                  bankId: x.BankId,
                                  bank: x.Bank != null 
                                      ? ctx.Mapper.Map<Bank>(x.Bank) 
                                      : null,
                                  id: x.Id,
                                  creationDate: x.CreationDate,
                                  editDate: x.EditDate,
                                  isActive: x.IsActive));
        }
    }
}
using AutoMapper;
using DocumentQuicker.BusinessLayer.Models;
using DocumentQuicker.DataProvider.Models;

namespace DocumentQuicker.BusinessLayer.MapperProfiles
{
    public sealed class DataProviderToBL : Profile
    {
        public DataProviderToBL()
        {
            CreateMap<BankInfoEf, BankInfo>()
                .ConstructUsing((x,ctx) => new BankInfo(id: x.Id,
                                                                                      description: x.BankDescription,
                                                                                      bic: x.Bic,
                                                                                      creationDate: x.CreationDate,
                                                                                      editDate: x.EditDate,
                                                                                      corrAccount: x.CorrAccount,
                                                                                      isActive: x.IsActive));
        }
    }
}
using AutoMapper;
using DocumentQuicker.BusinessLayer.Models;
using DocumentQuicker.DataProvider.Models;

namespace DocumentQuicker.BusinessLayer.MapperProfiles
{
    public class DataProviderToBL : Profile
    {
        public DataProviderToBL()
        {
            CreateMap<BankInfoEf, BankInfo>()
                .ConstructUsing((x,ctx) => new BankInfo(id: x.Id,
                                                                                      bankDescription: x.BankDescription,
                                                                                      bic: x.Bic,
                                                                                      creationDate: x.CreationDate,
                                                                                      editDate: x.EditDate,
                                                                                      corrAccount: x.CorrAccount,
                                                                                      isActive: x.IsActive));
        }
    }
}
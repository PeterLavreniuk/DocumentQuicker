using AutoMapper;
using DocumentQuicker.BusinessLayer.Models;
using DocumentQuicker.DataProvider.Models;

namespace DocumentQuicker.BusinessLayer.MapperProfiles
{
    public sealed class BlToDataProvider : Profile
    {
        public BlToDataProvider()
        {
            CreateMap<BankInfo, BankInfoEf>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(scr => scr.Id))
                .ForMember(
                    dest => dest.Bic,
                    opt => opt.MapFrom(scr => scr.Bic))
                .ForMember(
                    dest => dest.BankDescription,
                    opt => opt.MapFrom(scr => scr.Description))
                .ForMember(
                    dest => dest.CorrAccount,
                    opt => opt.MapFrom(scr => scr.CorrAccount))
                .ForMember(
                    dest => dest.CreationDate,
                    opt => opt.MapFrom(scr => scr.CreationDate))
                .ForMember(
                    dest => dest.EditDate,
                    opt => opt.MapFrom(scr => scr.EditDate))
                .ForMember(
                    dest => dest.IsActive,
                    opt => opt.MapFrom(scr => scr.IsActive));
        }
    }
}
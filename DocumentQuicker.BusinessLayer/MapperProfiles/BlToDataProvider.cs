using AutoMapper;
using DocumentQuicker.BusinessLayer.Models;
using DocumentQuicker.DataProvider.Models;

namespace DocumentQuicker.BusinessLayer.MapperProfiles
{
    public sealed class BlToDataProvider : Profile
    {
        public BlToDataProvider()
        {
            CreateMap<Bank, BankEf>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(
                    dest => dest.Bic,
                    opt => opt.MapFrom(src => src.Bic))
                .ForMember(
                    dest => dest.Description,
                    opt => opt.MapFrom(src => src.Description))
                .ForMember(
                    dest => dest.CorrAccount,
                    opt => opt.MapFrom(src => src.CorrAccount));

            CreateMap<Requisite, RequisiteEf>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.INN,
                    opt => opt.MapFrom(src => src.INN))
                .ForMember(dest => dest.KPP,
                    opt => opt.MapFrom(src => src.KPP))
                .ForMember(dest => dest.City,
                    opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.RawAddress,
                    opt => opt.MapFrom(src => src.RawAddress))
                .ForMember(dest => dest.BankAccount,
                    opt => opt.MapFrom(src => src.BankAccount))
                .ForMember(dest => dest.BankId,
                    opt => opt.MapFrom(src => src.BankId));
        }
    }
}
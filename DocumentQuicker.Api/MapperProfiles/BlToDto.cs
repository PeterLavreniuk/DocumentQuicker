using AutoMapper;
using DocumentQuicker.Api.Models;
using DocumentQuicker.BusinessLayer.Models;

namespace DocumentQuicker.Api.MapperProfiles
{
    public sealed class BlToDto : Profile
    {
        public BlToDto()
        {
            CreateMap<Bank, BankInfoDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(scr => scr.Id))
                .ForMember(
                    dest => dest.Bic,
                    opt => opt.MapFrom(scr => scr.Bic))
                .ForMember(
                    dest => dest.Description,
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
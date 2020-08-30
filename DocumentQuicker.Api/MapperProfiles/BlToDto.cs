using AutoMapper;
using DocumentQuicker.Api.Models.Dto;
using DocumentQuicker.BusinessLayer.Models;

namespace DocumentQuicker.Api.MapperProfiles
{
    public sealed class BlToDto : Profile
    {
        public BlToDto()
        {
            CreateMap<Bank, BankDto>()
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
                    opt => opt.MapFrom(src => src.CorrAccount))
                .ForMember(
                    dest => dest.CreationDate,
                    opt => opt.MapFrom(src => src.CreationDate))
                .ForMember(
                    dest => dest.EditDate,
                    opt => opt.MapFrom(src => src.EditDate))
                .ForMember(
                    dest => dest.IsActive,
                    opt => opt.MapFrom(src => src.IsActive));

            CreateMap<Requisite, RequisiteDto>()
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
                .ForMember(dest => dest.Bank,
                    opt => opt.MapFrom(src => src.Bank))
                .ForMember(dest => dest.CreationDate,
                    opt => opt.MapFrom(src => src.CreationDate))
                .ForMember(dest => dest.EditDate,
                    opt => opt.MapFrom(src => src.EditDate))
                .ForMember(dest => dest.IsActive,
                    opt => opt.MapFrom(src => src.IsActive));
        }
    }
}
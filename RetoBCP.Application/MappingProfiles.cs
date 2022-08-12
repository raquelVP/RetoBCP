using AutoMapper;
using RetoBCP.Application.DTO;
using RetoBCP.Domain;

namespace RetoBCP.Application
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ExchangeRate, GetAllExchangeRateResponse>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.AmountExchangeRate, o => o.MapFrom(s => s.AmountExchangeRate))
                .ForMember(d=> d.ExchangeRateType, o=> o.MapFrom(s => s.ExchangeRateType))
                .ForMember(d => d.IsActive, o => o.MapFrom(s => s.IsActive))
                .ForMember(d => d.Date, o => o.MapFrom(s => s.CreatedOn))
                ;
            CreateMap<ExchangeRate, UpdateExchangeRateResponse>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.AmountExchangeRate, o => o.MapFrom(s => s.AmountExchangeRate))
                .ForMember(d => d.ExchangeRateType, o => o.MapFrom(s => s.ExchangeRateType))
                .ForMember(d => d.Date, o => o.MapFrom(s => s.CreatedOn))
                ;

        }
    }
}

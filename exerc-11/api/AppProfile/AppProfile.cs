using Api.Domain;
using Api.Domain.Dto;
using AutoMapper;

namespace Api.AppProfile;

public class AppProfile : Profile
{
    
    public AppProfile()
    {
        CreateMap<Quotes, CreateQuoteDto>().ReverseMap();
        CreateMap<Quotes, UpdateQuoteDto>().ReverseMap();
        CreateMap<Quotes, ResponseQuoteDto>().ReverseMap();
    }
}
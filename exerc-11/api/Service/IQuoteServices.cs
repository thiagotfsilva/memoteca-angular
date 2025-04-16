using Api.Domain;
using Api.Domain.Dto;

namespace Api.Service;

public interface IQuoteServices
{
    Task<bool> AddQuote(CreateQuoteDto quote);
    Task<ResponseQuoteDto> GetQuoteById(int id);
    Task<RetornoPaginado<ResponseQuoteDto>> GetAllQuotes(int page, int quantity);
    Task<bool> UpdateQuote(UpdateQuoteDto quote);
    Task<bool> DeleteQuote(int id);
}
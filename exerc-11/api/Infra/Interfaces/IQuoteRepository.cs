using Api.Domain;

namespace Api.Infra.Interfaces;

public interface IQuoteRepository
{    
    Task<bool> AddQuote(Quotes quote);
    Task<Quotes> GetQuoteById(int id);
    Task<List<Quotes>> GetAllQuotes(int page, int quantity);
    Task<bool> UpdateQuote(Quotes quote);
    Task<bool> DeleteQuote(int id);
    Task<int> TotalQuotes();
}
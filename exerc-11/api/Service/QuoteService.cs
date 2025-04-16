using Api.Domain;
using Api.Domain.Dto;
using Api.Infra.Interfaces;
using AutoMapper;

namespace Api.Service;

public class QuoteService : IQuoteServices
{
    private readonly IQuoteRepository _repository;
    private readonly IMapper _mapper;

    public QuoteService(IQuoteRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<bool> AddQuote(CreateQuoteDto quote)
    {
        try
        {
            var quoteCreated = _mapper.Map<Quotes>(quote);
            var result = await _repository.AddQuote(quoteCreated);
            return result;
        }
        catch (Exception) { throw; }
    }

    public Task<bool> DeleteQuote(int id)
    {
        try
        {
            return _repository.DeleteQuote(id);
        }
        catch (Exception) { throw; }
    }

    public async Task<RetornoPaginado<ResponseQuoteDto>> GetAllQuotes(int page, int quantity)
    {
        try
        {
           
            var quotes = await _repository.GetAllQuotes(page, quantity);
            var quoteList = _mapper.Map<List<ResponseQuoteDto>>(quotes);
            
            int totalQuotes = await _repository.TotalQuotes();

            return new RetornoPaginado<ResponseQuoteDto>
            {
                Pagina = page,
                QtdPagina = quantity,
                TotalRegistros = totalQuotes,
                ListaDados = quoteList
            };
        }
        catch (Exception){ throw; }
    }

    public async Task<ResponseQuoteDto> GetQuoteById(int id)
    {
        try
        {
            Quotes quote = await _repository.GetQuoteById(id);
            return _mapper.Map<ResponseQuoteDto>(quote);
        }
        catch (Exception){ throw; }
    }

    public async Task<bool> UpdateQuote(UpdateQuoteDto quote)
    {
        try
        {
            Quotes quoteUpdated = _mapper.Map<Quotes>(quote);
            var result = await _repository.UpdateQuote(quoteUpdated);
            return result;
        }
        catch (Exception){ throw; }
    }
}
using System.Threading.Tasks;
using Api.Domain.Dto;
using Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller;
[ApiController]
[Route("api/[controller]")]
public class QuoteController : ControllerBase
{
    private readonly IQuoteServices _quoteServices;

    public QuoteController(IQuoteServices quoteServices)
    {
        _quoteServices = quoteServices;
    }


    [HttpGet("{pagina}/{quantidade}")]
    public async Task<IActionResult> GetQuotes(int pagina, int quantidade)
    {
        try
        {
            var quotes = await _quoteServices.GetAllQuotes(pagina, quantidade);
            return Ok(quotes);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetQuoteById(int id) 
    {
        try
        {
            var result = await _quoteServices.GetQuoteById(id);  
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddQuote([FromBody] CreateQuoteDto quote)
    {
        try
        {
            var result = await _quoteServices.AddQuote(quote);  
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }        
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteQuote(int id)
    {
        try
        {
            var result = await _quoteServices.DeleteQuote(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateQuote([FromBody] UpdateQuoteDto quote)
    {
        try
        {
            var result = await _quoteServices.UpdateQuote(quote);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}

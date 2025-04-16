using System.Data;
using System.Threading.Tasks;
using Api.Domain;
using Api.Infra.Interfaces;
using Dapper;

namespace Api.Infra.Repositories;

public class QuoteRepositoy : IQuoteRepository
{
    private readonly IDbConnection _conn;

    public QuoteRepositoy(IDbConnection conn)
    {
        _conn = conn;
    }

    public async Task<bool> AddQuote(Quotes quote)
    {
        try
        {
            string sql = "INSERT INTO QUOTES VALUES (@PENSAMENTO, @AUTOR, @MODELO)";
            var parametros = new
            {
                PENSAMENTO = quote.Pensamento,
                AUTOR = quote.Autor,
                MODELO = quote.Modelo
            };

            var result = await _conn.ExecuteAsync(sql, parametros);

            return result > 0;
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> DeleteQuote(int id)
    {
        try
        {
            string sql = @"DELETE FROM QUOTES WHERE ID = @ID";
            var parameters = new { ID = id };
            var result = await _conn.ExecuteAsync(sql, parameters);
            return result > 0;
        }
        catch (Exception) { throw; }
    }

    public async Task<List<Quotes>> GetAllQuotes(int page, int quantity)
    {
        try
        {
            string sql = "SELECT * FROM QUOTES ORDER BY ID OFFSET @OFFSET ROWS FETCH NEXT @QUANTIDADE ROWS ONLY";

            var parameters = new
            {
                OFFSET = (page - 1) * quantity,
                QUANTIDADE = quantity
            };

            var result =  await _conn.QueryAsync<Quotes>(sql, parameters);

            return result.ToList();
        }
        catch (Exception) { throw; }
    }

    public async Task<int> TotalQuotes() 
    {
        string sql = "SELECT COUNT(*) FROM QUOTES";
        var totalQuotes = await _conn.ExecuteScalarAsync<int>(sql);
        return totalQuotes;
    }

    public async Task<Quotes> GetQuoteById(int id)
    {
        try
        {
            string sql = "SELECT TOP 1 * FROM QUOTES WHERE ID = @ID";
            var parameters = new { ID = id };
            var quote = await _conn.QueryFirstOrDefaultAsync<Quotes>(sql, parameters);   
            return quote!;
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> UpdateQuote(Quotes quote)
    {
        try
        {
            string sql = @"UPDATE QUOTES SET PENSAMENTO = @PENSAMENTO, AUTOR = @AUTOR, MODELO = @MODELO WHERE ID = @ID";
            
            var parameters = new
            {
                PENSAMENTO = quote.Pensamento,
                AUTOR = quote.Autor,
                MODELO = quote.Modelo,
                ID = quote.Id
            };
            
            int result = await _conn.ExecuteAsync(sql, parameters);

            return result > 0;
        }
        catch (Exception) { throw; }
    }
}
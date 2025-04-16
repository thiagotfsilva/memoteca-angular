namespace Api.Domain.Dto;

public class ResponseQuoteDto
{
    public int Id { get; set; }
    public string? Pensamento { get; set; }
    public string? Autor { get; set; }
    public int Modelo { get; set; }
}
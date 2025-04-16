namespace Api.Domain.Dto;

public class CreateQuoteDto
{
    public string? Pensamento { get; set; }
    public string? Autor { get; set; }
    public int Modelo { get; set; }
}
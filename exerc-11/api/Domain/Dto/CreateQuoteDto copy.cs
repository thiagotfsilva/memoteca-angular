using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dto;

public class UpdateQuoteDto
{
    public int Id { get; set; }

    [Required]
    [MaxLength(300)]
    public string? Pensamento { get; set; }

    [Required]
    [MaxLength(50)]
    public string? Autor { get; set; }

    [Required]
    public int Modelo { get; set; }
}
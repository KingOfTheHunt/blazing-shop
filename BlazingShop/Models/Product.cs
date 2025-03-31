using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazingShop.Models;

[Table("Product")]
public class Product
{
    [Key]
    [Required(ErrorMessage = "Id é obrigatório.")]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Título é obrigatório.")]
    [MaxLength(150, ErrorMessage = "O Título deve ter no máximo 150 caracteres.")]
    [MinLength(5, ErrorMessage = "O Título deve ter no mínimo 5 caracteres.")]
    public string Title { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "O Preço é obrigatório.")]
    [DataType(DataType.Currency)]
    [Range(1, 9999, ErrorMessage = "O Preço deve estar entre 1 e 9999.")]
    public decimal Price { get; set; }
    
    [Required(ErrorMessage = "A Categoria é obrigatória.")]
    [Range(1, 9999, ErrorMessage = "A Categoria deve estar entre 1 e 9999.")]
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}

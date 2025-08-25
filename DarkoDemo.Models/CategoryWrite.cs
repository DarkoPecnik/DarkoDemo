using System.ComponentModel.DataAnnotations;

namespace DarkoDemo.Models;

public class CategoryWrite
{
    [Required]
    public string Name { get; set; } = default!;
}
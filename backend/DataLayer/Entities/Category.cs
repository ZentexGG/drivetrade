using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities;

public class Category
{
    [Key]
    public int ID { get; set; }
    [Required]
    public string Name { get; set; }
}
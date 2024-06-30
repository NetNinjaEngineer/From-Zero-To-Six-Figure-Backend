using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

[Table("Companies", Schema = "dbo")]
public class Company
{
    [Column("CompanyId")]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Name is Required.")]
    [MaxLength(50, ErrorMessage = "Maximum lenght for the name is 50 characters.")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "Address is Required.")]
    [MaxLength(60, ErrorMessage = "Maximum lenght for the Address is 60 characters.")]
    public string? Address { get; set; }

    [Required(ErrorMessage = "Country is Required.")]
    public string? Country { get; set; }

    public ICollection<Employee> Employees { get; set; } = [];
}

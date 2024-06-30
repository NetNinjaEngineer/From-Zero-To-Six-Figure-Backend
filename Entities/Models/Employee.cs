using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;
[Table("Employees", Schema = "dbo")]
public class Employee
{
    [Column("EmployeeId ")]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Name is Required.")]
    [MaxLength(30, ErrorMessage = "Maximum lenght for the Name is 30 characters.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Age is Required.")]
    public int Age { get; set; }
    [Required(ErrorMessage = "Position is Required.")]
    [MaxLength(20, ErrorMessage = "The Maximum lenght for the position is 20 characters.")]
    public string? Position { get; set; }
    [ForeignKey(nameof(Company))]
    public Guid? CompanyId { get; set; }
    public Company? Company { get; set; }
}

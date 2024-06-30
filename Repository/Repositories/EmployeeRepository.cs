using Contracts;
using Entities.Models;

namespace Repository.Repositories;

public class EmployeeRepository(ApplicationDbContext context)
    : GenericRepository<Employee>(context), IEmployeeRepository
{
}

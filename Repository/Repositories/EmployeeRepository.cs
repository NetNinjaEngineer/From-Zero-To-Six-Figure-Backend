using Contracts;
using Entities.Models;

namespace Repository.Repositories;

public class EmployeeRepository(ApplicationDbContext context)
    : GenericRepository<Employee>(context), IEmployeeRepository
{
    public void CreateEmployeeForCompany(Guid companyId, Employee employee)
    {
        employee.CompanyId = companyId;
        Create(employee);
    }

    public async Task<IEnumerable<Employee>> GetEmployeesForCompany(
        Guid companyId, bool trackChanges)
    {
        var employees = await FindByCondition(employee =>
            employee.CompanyId.Equals(companyId), trackChanges);
        return employees;
    }

    public async Task<Employee> GetSingleEmployeeForCompany(Guid companyId, Guid id)
    {
        var employees = await FindByCondition(e =>
            e.CompanyId.Equals(companyId) && e.Id.Equals(id), false);
        return employees.SingleOrDefault()!;
    }
}

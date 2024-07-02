using Contracts;
using Entities.Models;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository.Repositories;

public class EmployeeRepository(ApplicationDbContext context)
    : GenericRepository<Employee>(context), IEmployeeRepository
{
    public void CreateEmployeeForCompany(Guid companyId, Employee employee)
    {
        employee.CompanyId = companyId;
        Create(employee);
    }

    public void DeleteEmployee(Employee employee) => Delete(employee);

    public async Task<IEnumerable<Employee>> GetEmployeesForCompany(
        Guid companyId, bool trackChanges)
    {
        var employees = await FindByCondition(employee =>
            employee.CompanyId.Equals(companyId), trackChanges);
        return employees;
    }

    public async Task<PagedList<Employee>> GetEmployeesForCompany(Guid companyId, EmployeeParameters parameters, bool trackChanges)
    {
        var employees = await FindByCondition(e =>
            e.CompanyId.Equals(companyId), trackChanges);

        var result = employees
        .FilterEmployees(parameters.MinAge, parameters.MaxAge)
        .Search(parameters.SearchTerm!);

        return PagedList<Employee>.ToPagedList(result, parameters.PageNumber, parameters.PageSize);

    }

    public async Task<Employee> GetSingleEmployeeForCompany(Guid companyId, Guid id)
    {
        var employees = await FindByCondition(e =>
            e.CompanyId.Equals(companyId) && e.Id.Equals(id), false);
        return employees.SingleOrDefault()!;
    }

    public void UpdateEmployee(Employee employee) => Update(employee);
}

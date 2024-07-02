using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;
public interface IEmployeeRepository : IGenericRepository<Employee>
{
    Task<IEnumerable<Employee>> GetEmployeesForCompany(Guid companyId, bool trackChanges);
    Task<PagedList<Employee>> GetEmployeesForCompany(Guid companyId,
        EmployeeParameters parameters, bool trackChanges);
    Task<Employee> GetSingleEmployeeForCompany(Guid companyId, Guid id);
    void CreateEmployeeForCompany(Guid companyId, Employee employee);
    void DeleteEmployee(Employee employee);
    void UpdateEmployee(Employee employee);
}

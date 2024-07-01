using Entities.Models;

namespace Contracts;
public interface IEmployeeRepository : IGenericRepository<Employee>
{
    Task<IEnumerable<Employee>> GetEmployeesForCompany(Guid companyId, bool trackChanges);
    Task<Employee> GetSingleEmployeeForCompany(Guid companyId, Guid id);
    void CreateEmployeeForCompany(Guid companyId, Employee employee);
}

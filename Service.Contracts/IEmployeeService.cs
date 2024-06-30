using Shared.DataTransferObjects;

namespace Service.Contracts;
public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDto>> GetEmployeesForCompany(Guid companyId, bool trackChanges);
    Task<EmployeeDto> GetEmployeeForCompany(Guid companyId, Guid employeeId);
}

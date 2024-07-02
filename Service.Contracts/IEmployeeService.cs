using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service.Contracts;
public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDto>> GetEmployeesForCompany(Guid companyId, bool trackChanges);
    Task<EmployeeDto> GetEmployeeForCompany(Guid companyId, Guid employeeId);
    Task<EmployeeDto> CreateEmployeeForCompany(Guid companyId, EmployeeForCreationDto employee);
    Task DeleteEmployeeForCompany(Guid companyId, Guid id);
    Task UpdateEmployeeForCompany(Guid companyId, Guid id, EmployeeForUpdateDto employeeModel);
    Task<(IEnumerable<EmployeeDto> employees, MetaData metaData)> GetEmployeesForCompany(Guid companyId,
        EmployeeParameters parameters, bool trackChanges);

}

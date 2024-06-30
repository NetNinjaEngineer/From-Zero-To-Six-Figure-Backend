using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service;
public sealed class ServiceManager(
    IRepositoryManager repository,
    IMapper mapper) : IServiceManager
{
    private readonly Lazy<ICompanyService> _companyService = new(
        () => new CompanyService(mapper, repository));

    private readonly Lazy<IEmployeeService> _employeeService = new(
        () => new EmployeeService(mapper, repository));
    private readonly IRepositoryManager _repository = repository;

    public ICompanyService CompanyService => _companyService.Value;

    public IEmployeeService EmployeeService => _employeeService.Value;
}

using Contracts;
using Microsoft.Extensions.Logging;
using Service.Contracts;

namespace Service;
public sealed class ServiceManager(ILogger logger, IRepositoryManager repository) : IServiceManager
{
    private readonly ILogger _logger = logger;

    private readonly Lazy<ICompanyService> _companyService = new(
        () => new CompanyService(repository, logger));

    private readonly Lazy<IEmployeeService> _employeeService = new(
        () => new EmployeeService(repository, logger));
    private readonly IRepositoryManager _repository = repository;

    public ICompanyService CompanyService => _companyService.Value;

    public IEmployeeService EmployeeService => _employeeService.Value;
}

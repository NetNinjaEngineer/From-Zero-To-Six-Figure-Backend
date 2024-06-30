using Contracts;

namespace Repository.Repositories;
public sealed class RepositoryManager(ApplicationDbContext context) : IRepositoryManager
{
    private readonly ApplicationDbContext _context = context;

    private readonly Lazy<IEmployeeRepository> _employeeRepository = new(() =>
            new EmployeeRepository(context));

    private readonly Lazy<ICompanyRepository> _companyRepository = new(() =>
            new CompanyRepository(context));

    public IEmployeeRepository EmployeeRepository => _employeeRepository.Value;

    public ICompanyRepository CompanyRepository => _companyRepository.Value;

    public void Save() => _context.SaveChanges();
}

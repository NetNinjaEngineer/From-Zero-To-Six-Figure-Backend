namespace Contracts;
public interface IRepositoryManager
{
    IEmployeeRepository EmployeeRepository { get; }
    ICompanyRepository CompanyRepository { get; }
    void Save();
}

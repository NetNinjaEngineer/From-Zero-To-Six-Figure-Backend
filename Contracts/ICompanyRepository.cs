using Entities.Models;

namespace Contracts;
public interface ICompanyRepository : IGenericRepository<Company>
{
    Task<IEnumerable<Company>> GetAllCompanies(bool trackChanges);
    Task<Company?> GetCompany(Guid id);
    void CreateCompany(Company company);
    Task<IEnumerable<Company>> GetCompaniesByIds(IEnumerable<Guid> ids);
}

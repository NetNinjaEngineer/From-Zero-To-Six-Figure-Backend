using Entities.Models;

namespace Contracts;
public interface ICompanyRepository : IGenericRepository<Company>
{
    Task<IEnumerable<Company>> GetAllCompanies(bool trackChanges);
}

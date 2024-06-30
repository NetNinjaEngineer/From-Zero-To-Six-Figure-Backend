using Contracts;
using Entities.Models;

namespace Repository.Repositories;
public sealed class CompanyRepository(ApplicationDbContext context)
    : GenericRepository<Company>(context), ICompanyRepository
{
    public async Task<IEnumerable<Company>> GetAllCompanies(bool trackChanges)
        => await (GetAll(trackChanges));

    public async Task<Company?> GetCompany(Guid id)
        => await (GetById(id));
}

using Contracts;
using Entities.Models;

namespace Repository.Repositories;
public sealed class CompanyRepository(ApplicationDbContext context)
    : GenericRepository<Company>(context), ICompanyRepository
{
    public void CreateCompany(Company company) => Create(company);

    public async Task<IEnumerable<Company>> GetAllCompanies(bool trackChanges)
        => await (GetAll(trackChanges));

    public async Task<IEnumerable<Company>> GetCompaniesByIds(IEnumerable<Guid> ids)
    {
        var companies = await FindByCondition(x => ids.Contains(x.Id), false);
        return companies;
    }
    public async Task<Company?> GetCompany(Guid id)
        => await (GetById(id));
}

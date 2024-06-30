using Contracts;
using Entities.Models;

namespace Repository.Repositories;
public class CompanyRepository(ApplicationDbContext context)
    : GenericRepository<Company>(context), ICompanyRepository
{
}

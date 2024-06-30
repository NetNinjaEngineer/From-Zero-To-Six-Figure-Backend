using Shared.DataTransferObjects;

namespace Service.Contracts;
public interface ICompanyService
{
    Task<IEnumerable<CompanyDto>> GetCompanies(bool trackChanges);
}

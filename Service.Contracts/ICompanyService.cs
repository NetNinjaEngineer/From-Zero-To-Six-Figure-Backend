using Shared.DataTransferObjects;

namespace Service.Contracts;
public interface ICompanyService
{
    Task<IEnumerable<CompanyDto>> GetCompanies(bool trackChanges);
    Task<CompanyDto?> GetCompany(Guid companyId);
    CompanyDto CreateCompany(CompanyForCreationDto company);
    Task<IEnumerable<CompanyDto>> GetCompaniesByIds(IEnumerable<Guid> ids);
    (IEnumerable<CompanyDto> companies, string ids) CreateCompanyCollection
        (IEnumerable<CompanyForCreationDto> companyCollection);

    Task DeleteCompany(Guid companyId);
    Task UpdateCompany(Guid companyid, CompanyForUpdateDto companyForUpdate);


}

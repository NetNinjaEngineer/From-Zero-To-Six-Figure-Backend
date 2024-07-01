using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

public sealed class CompanyService : ICompanyService
{
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repositoryManager;

    public CompanyService(IMapper mapper,
        IRepositoryManager repositoryManager)
    {
        _mapper = mapper;
        _repositoryManager = repositoryManager;
    }

    public CompanyDto CreateCompany(CompanyForCreationDto company)
    {
        var companyForCreation = _mapper.Map<Company>(company);
        _repositoryManager.CompanyRepository.CreateCompany(companyForCreation);
        _repositoryManager.Save();
        var companyToReturn = _mapper.Map<CompanyDto>(companyForCreation);
        return companyToReturn;
    }

    public (IEnumerable<CompanyDto> companies, string ids) CreateCompanyCollection(IEnumerable<CompanyForCreationDto> companyCollection)
    {
        if (companyCollection is null)
            throw new CompanyCollectionBadRequestException();

        var companyEntities = _mapper.Map<IEnumerable<Company>>(companyCollection);
        foreach (var companyEntity in companyEntities)
        {
            _repositoryManager.CompanyRepository.Create(companyEntity);
        }

        _repositoryManager.Save();

        var companyCollectionToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);
        var ids = string.Join(",", companyCollectionToReturn.Select(c => c.Id));

        return (companyCollectionToReturn, ids);
    }

    public async Task<IEnumerable<CompanyDto>> GetCompanies(bool trackChanges)
    {
        var companies = await _repositoryManager.CompanyRepository.GetAllCompanies(trackChanges);
        return _mapper.Map<IEnumerable<CompanyDto>>(companies);
    }

    public async Task<IEnumerable<CompanyDto>> GetCompaniesByIds(IEnumerable<Guid> ids)
    {
        if (ids is null)
            throw new IdParamtersBadRequestException();
        var companyEntities = await _repositoryManager.CompanyRepository.GetCompaniesByIds(ids);
        if (ids.Count() != companyEntities.Count())
            throw new CollectionByIdsBadRequestException();
        var companiesToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);
        return companiesToReturn;
    }

    public async Task<CompanyDto?> GetCompany(Guid companyId)
    {
        var company = await _repositoryManager.CompanyRepository.GetCompany(companyId);
        if (company is not null)
            return _mapper.Map<CompanyDto>(company);
        throw new CompanyNotFoundException(companyId);
    }
}

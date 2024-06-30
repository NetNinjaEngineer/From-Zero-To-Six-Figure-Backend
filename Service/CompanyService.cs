using AutoMapper;
using Contracts;
using Entities.Exceptions;
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

    public async Task<IEnumerable<CompanyDto>> GetCompanies(bool trackChanges)
    {
        var companies = await _repositoryManager.CompanyRepository.GetAllCompanies(trackChanges);
        return _mapper.Map<IEnumerable<CompanyDto>>(companies);
    }

    public async Task<CompanyDto?> GetCompany(Guid companyId)
    {
        var company = await _repositoryManager.CompanyRepository.GetCompany(companyId);
        if (company is not null)
            return _mapper.Map<CompanyDto>(company);
        throw new NotFoundException($"Company with '{companyId}' was not found.");
    }
}

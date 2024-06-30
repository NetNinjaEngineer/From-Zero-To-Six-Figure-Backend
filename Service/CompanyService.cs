using AutoMapper;
using Contracts;
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
}

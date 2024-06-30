using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service;

public sealed class EmployeeService : IEmployeeService
{
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repositoryManager;

    public EmployeeService(IMapper mapper,
        IRepositoryManager repositoryManager)
    {
        _mapper = mapper;
        _repositoryManager = repositoryManager;
    }
}
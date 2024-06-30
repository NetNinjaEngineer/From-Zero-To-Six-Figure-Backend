using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

public sealed class EmployeeService(
    IMapper mapper,
    IRepositoryManager repository
    ) : IEmployeeService
{
    private readonly IMapper _mapper = mapper;
    private readonly IRepositoryManager _repository = repository;

    public async Task<EmployeeDto> GetEmployeeForCompany(Guid companyId, Guid employeeId)
    {
        if (!await CheckValidCompany(companyId))
            throw new CompanyNotFoundException(companyId);

        var employee = await _repository.EmployeeRepository
            .GetSingleEmployeeForCompany(companyId, employeeId)
            ?? throw new EmployeeNotFoundException(employeeId);

        return _mapper.Map<EmployeeDto>(employee);
    }

    public async Task<IEnumerable<EmployeeDto>> GetEmployeesForCompany(
        Guid companyId, bool trackChanges)
    {
        if (!await CheckValidCompany(companyId))
            throw new CompanyNotFoundException(companyId);

        var employees = await _repository.EmployeeRepository
            .GetEmployeesForCompany(companyId, trackChanges);

        return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
    }

    private async Task<bool> CheckValidCompany(Guid companyId)
    {
        var company = await _repository.CompanyRepository.GetById(companyId);
        return company != null;
    }
}
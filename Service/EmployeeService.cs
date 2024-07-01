using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
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

    public async Task<EmployeeDto> CreateEmployeeForCompany(Guid companyId,
        EmployeeForCreationDto employee)
    {
        if (!await CheckValidCompany(companyId))
            throw new CompanyNotFoundException(companyId);
        var employeeForCreation = _mapper.Map<Employee>(employee);
        _repository.EmployeeRepository.CreateEmployeeForCompany(companyId, employeeForCreation);
        _repository.Save();
        var employeeToReturn = _mapper.Map<EmployeeDto>(employeeForCreation);
        return employeeToReturn;
    }

    public async Task DeleteEmployeeForCompany(Guid companyId, Guid id)
    {
        if (!await CheckValidCompany(companyId))
            throw new CompanyNotFoundException(companyId);

        var employeeForCompany = await _repository.EmployeeRepository
            .GetSingleEmployeeForCompany(companyId, id)
            ?? throw new EmployeeNotFoundException(id);

        _repository.EmployeeRepository.Delete(employeeForCompany);
        _repository.Save();
    }

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

    public async Task UpdateEmployeeForCompany(Guid companyId, Guid id,
        EmployeeForUpdateDto employeeModel)
    {
        if (!await CheckValidCompany(companyId))
            throw new CompanyNotFoundException(companyId);

        var existingEmployee = await _repository
            .EmployeeRepository
            .GetSingleEmployeeForCompany(companyId, id);

        if (existingEmployee is not null)
        {
            _mapper.Map(employeeModel, existingEmployee);
            _repository.EmployeeRepository.Update(existingEmployee);
            _repository.Save();
        }
        else
            throw new EmployeeNotFoundException(id);

    }

    private async Task<bool> CheckValidCompany(Guid companyId)
    {
        var company = await _repository.CompanyRepository.GetById(companyId);
        return company != null;
    }
}
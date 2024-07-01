using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace CompanyEmployees.Controllers;
[Route("api/companies/{companyId:guid}/employees")]
[ApiController]
public class EmployeesController(IServiceManager service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetEmployeesForCompany(Guid companyId)
    {
        var employee = await service.EmployeeService
            .GetEmployeesForCompany(companyId, false);
        return Ok(employee);
    }

    [HttpGet("{employeeId:guid}", Name = "EmployeeById")]
    public async Task<IActionResult> GetEmployeeForCompany(Guid companyId, Guid employeeId)
    {
        var employee = await service.EmployeeService.GetEmployeeForCompany(companyId, employeeId);
        return Ok(employee);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee(Guid companyId,
        [FromBody] EmployeeForCreationDto employee)
    {
        if (employee == null)
            return BadRequest($"{nameof(EmployeeForCreationDto)} is null");
        var createdEmployee = await service.EmployeeService.CreateEmployeeForCompany(companyId, employee);
        return CreatedAtRoute("EmployeeById", new { companyId, employeeId = createdEmployee.Id },
            createdEmployee);
    }
}

using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

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

    [HttpGet("{employeeId:guid}")]
    public async Task<IActionResult> GetEmployeeForCompany(Guid companyId, Guid employeeId)
    {
        var employee = await service.EmployeeService.GetEmployeeForCompany(companyId, employeeId);
        return Ok(employee);
    }

}

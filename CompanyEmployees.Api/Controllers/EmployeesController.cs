﻿using CompanyEmployees.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Text.Json;

namespace CompanyEmployees.Controllers;
[Route("api/companies/{companyId:guid}/employees")]
[ApiController]
public class EmployeesController(IServiceManager service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetEmployeesForCompany(Guid companyId,
        [FromQuery] EmployeeParameters employeeParameters)
    {
        var pagedResult = await service.EmployeeService.GetEmployeesForCompany(companyId,
         employeeParameters, trackChanges: false);

        Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

        return Ok(pagedResult.employees);
    }

    [HttpGet("{employeeId:guid}", Name = "EmployeeById")]
    public async Task<IActionResult> GetEmployeeForCompany(Guid companyId, Guid employeeId)
    {
        var employee = await service.EmployeeService.GetEmployeeForCompany(companyId, employeeId);
        return Ok(employee);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationActionFilter))]
    public async Task<IActionResult> CreateEmployee(Guid companyId,
        [FromBody] EmployeeForCreationDto employee)
    {
        var createdEmployee = await service.EmployeeService.CreateEmployeeForCompany(companyId, employee);
        return CreatedAtRoute("EmployeeById", new { companyId, employeeId = createdEmployee.Id },
            createdEmployee);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteEmployeeForCompany(Guid companyId, Guid id)
    {
        await service.EmployeeService.DeleteEmployeeForCompany(companyId, id);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationActionFilter))]
    public async Task<IActionResult> UpdateEmployeeForCompany(
        Guid companyId,
        Guid id,
        EmployeeForUpdateDto employeeModel)
    {
        await service.EmployeeService.UpdateEmployeeForCompany(companyId, id, employeeModel);
        return NoContent();

    }
}

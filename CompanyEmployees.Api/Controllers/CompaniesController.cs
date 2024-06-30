using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace CompanyEmployees.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CompaniesController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetCompanies(bool trackChanges)
    {
        var companies = await serviceManager.CompanyService.GetCompanies(trackChanges);
        return Ok(companies);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCompany(Guid id)
    {
        var company = await serviceManager.CompanyService.GetCompany(id);
        return Ok(company);
    }
}
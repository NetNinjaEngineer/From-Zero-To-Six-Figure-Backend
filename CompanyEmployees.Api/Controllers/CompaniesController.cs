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
        try
        {
            var companies = await serviceManager.CompanyService.GetCompanies(trackChanges);
            return Ok(companies);
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal server error");
        }
    }
}

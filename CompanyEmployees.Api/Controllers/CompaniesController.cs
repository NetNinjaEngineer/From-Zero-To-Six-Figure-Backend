using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace CompanyEmployees.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CompaniesController(IServiceManager service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetCompanies(bool trackChanges)
        => Ok(await service.CompanyService.GetCompanies(trackChanges));


    [HttpGet("{id:guid}", Name = "CompanyById")]
    public async Task<IActionResult> GetCompany(Guid id)
        => Ok(await service.CompanyService.GetCompany(id));

    [HttpPost]
    public IActionResult CreateCompany([FromBody] CompanyForCreationDto company)
    {
        if (company is null)
            return BadRequest("CompanyForCreationDto object is null");
        var createdCompany = service.CompanyService.CreateCompany(company);
        return CreatedAtRoute("CompanyById", new { id = createdCompany.Id }, createdCompany);
    }


}
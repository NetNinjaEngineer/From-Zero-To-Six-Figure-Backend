using CompanyEmployees.ModelBinders;
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

    [HttpGet("collection/({ids})", Name = "CompanyCollection")]
    public async Task<IActionResult> GetCompaniesCollection(
        [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
    {
        var companies = await service.CompanyService.GetCompaniesByIds(ids);
        return Ok(companies);
    }

    [HttpPost("collection")]
    public IActionResult CreateCompanyCollection(IEnumerable<CompanyForCreationDto> companies)
    {
        var result = service.CompanyService.CreateCompanyCollection(companies);
        return CreatedAtRoute("CompanyCollection", new { result.ids }, new { result.companies });
    }
}
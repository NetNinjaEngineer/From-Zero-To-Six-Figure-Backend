using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace CompanyEmployees.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmployeesController(IServiceManager serviceManager) : ControllerBase
{


}

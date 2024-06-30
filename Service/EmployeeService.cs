using Contracts;
using Microsoft.Extensions.Logging;
using Service.Contracts;

namespace Service;

public sealed class EmployeeService(
    IRepositoryManager repository,
    ILogger logger) : IEmployeeService
{

}
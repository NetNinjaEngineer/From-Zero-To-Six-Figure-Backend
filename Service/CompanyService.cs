using Contracts;
using Microsoft.Extensions.Logging;
using Service.Contracts;

namespace Service;

public sealed class CompanyService(
    IRepositoryManager repository,
    ILogger logger) : ICompanyService
{

}

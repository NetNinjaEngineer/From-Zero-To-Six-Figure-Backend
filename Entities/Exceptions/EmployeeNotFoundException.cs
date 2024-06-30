namespace Entities.Exceptions;
public class EmployeeNotFoundException(Guid id)
    : NotFoundException($"The employee with id: '{id}' was not founded.")
{
}

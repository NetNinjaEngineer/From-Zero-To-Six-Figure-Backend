namespace Shared.RequestFeatures;
public class EmployeeParameters : RequestParamters
{
    public int MinAge { get; set; }
    public int MaxAge { get; set; } = int.MaxValue;
    public bool ValidAgeRange => MaxAge > MinAge;

    public string? SearchTerm { get; set; }
}

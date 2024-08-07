﻿using Entities.Models;

namespace CompanyEmployees.Extensions;
public static class RepositoryEmployeeExtensions
{
    public static IEnumerable<Employee> FilterEmployees(
        this IEnumerable<Employee> employees, int minAge, int maxAge)
        => employees.Where(e => e.Age >= minAge && e.Age <= maxAge);

    public static IEnumerable<Employee> Search(this IEnumerable<Employee> employees,
        string searchTerm)
        => string.IsNullOrEmpty(searchTerm)
        ? employees :
        employees.Where(e => e.Name!.Equals(searchTerm,
            StringComparison.OrdinalIgnoreCase));
}
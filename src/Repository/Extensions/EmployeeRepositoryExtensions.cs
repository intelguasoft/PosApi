using Entities;

namespace Repository.Extensions;

public static class EmployeeRepositoryExtensions
{
	public static IQueryable<Employee_Employee> FilterByEmployeesAge(this IQueryable<Employee_Employee> employees, uint minAge, uint maxAge) =>
		employees.Where(e => (e.Age >= minAge && e.Age <= maxAge));
}

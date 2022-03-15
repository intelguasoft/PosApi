using Entities;

namespace Repository.Extensions;

public static class CompanyRepositoryExtensions
{
	public static IQueryable<Company_Company> SearchByCompanyName(this IQueryable<Company_Company> companies, string searchTerm)
	{
		if (string.IsNullOrWhiteSpace(searchTerm))
			return companies;

		var lowerCaseSearchTerm = searchTerm.Trim().ToLower();

		return companies.Where(e => e.Name.ToLower().Contains(lowerCaseSearchTerm));
	}
}

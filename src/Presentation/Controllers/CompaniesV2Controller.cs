using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Shared.Parameters;
using System.Text.Json;

namespace Presentation.Controllers;

[ApiVersion("2.0")]
[Route("api/companies")]
[ApiController]
public class CompaniesV2Controller : ControllerBase
{
	private readonly IServiceManager _service;

	public CompaniesV2Controller(IServiceManager service) => _service = service;

	[HttpGet]
	public async Task<IActionResult> GetCompanies([FromQuery] CompanyRequestParameters companyRequestParameters, CancellationToken cancellationToken)
	{
		var pagingResult = await _service.CompanyService.GetCompaniesAsync(companyRequestParameters, false, cancellationToken).ConfigureAwait(false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagingResult.pagingMetaData));

        return Ok(pagingResult.companies);
	}
}

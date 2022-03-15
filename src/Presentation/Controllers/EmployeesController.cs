#region (c) 2022 Binary Builders Inc. All rights reserved.

// EmployeesController.cs
// 
// Copyright (C) 2022 Binary Builders Inc.
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

#endregion

#region using

using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Service.Interfaces;
using Shared.DataTransferObjects;
using Shared.Parameters;
using System.Text.Json;

#endregion

namespace Presentation.Controllers;

[Route("api/companies/{companyId}/employees")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IServiceManager _service;

    public EmployeesController(IServiceManager service)
    {
        _service = service;
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateEmployeeForCompanyAsync(int companyId, [FromBody] Shared.DataTransferObjects.EmployeeForCreationDto employee, CancellationToken cancellationToken)
    {
        var employeeToReturn = await _service.EmployeeService.CreateEmployeeForCompanyAsync(companyId, employee, false, cancellationToken).ConfigureAwait(false);

        return CreatedAtRoute("GetEmployeeForCompany", new { companyId, id = employeeToReturn.EmployeeId }, employeeToReturn);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteEmployeeForCompanyAsync(int companyId, int id, CancellationToken cancellationToken)
    {
        await _service.EmployeeService.DeleteEmployeeForCompanyAsync(companyId, id, false, cancellationToken).ConfigureAwait(false);

        return NoContent();
    }

    [HttpGet("{id:int}", Name = "GetEmployeeForCompany")]
    public async Task<IActionResult> GetEmployeeForCompanyAsync(int companyId, int id, CancellationToken cancellationToken)
    {
        var employee = await _service.EmployeeService.GetEmployeeAsync(companyId, id, false, cancellationToken).ConfigureAwait(false);
        return Ok(employee);
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployeesForCompanyAsync(int companyId, [FromQuery] EmployeeRequestParameters employeeRequestParameters, CancellationToken cancellationToken)
    {
        var pagingResult = await _service.EmployeeService.GetEmployeesAsync(companyId, employeeRequestParameters, false, cancellationToken).ConfigureAwait(false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagingResult.pagingMetaData));

        return Ok(pagingResult.employees);
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> PartiallyUpdateEmployeeForCompanyAsync(int companyId, int id, [FromBody] JsonPatchDocument<EmployeeForUpdateDto> patchDoc, CancellationToken cancellationToken)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");

        var result = await _service.EmployeeService.GetEmployeeForPatchAsync(companyId, id, false, true, cancellationToken).ConfigureAwait(false);

        patchDoc.ApplyTo(result.employeeToPatch);

        TryValidateModel(result.employeeToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        await _service.EmployeeService.SaveChangesForPatchAsync(result.employeeToPatch, result.employeeEntity, cancellationToken).ConfigureAwait(false);

        return NoContent();
    }

    [HttpPut("{id:int}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateEmployeeForCompanyAsync(int companyId, int id, [FromBody] EmployeeForUpdateDto employee, CancellationToken cancellationToken)
    {
        await _service.EmployeeService.UpdateEmployeeForCompanyAsync(companyId, id, employee, false, true, cancellationToken).ConfigureAwait(false);

        return NoContent();
    }
}
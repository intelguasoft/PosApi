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

using System.Text.Json;
using Api.Presentation.ActionFilters;
using Api.Service.Contracts;
using Api.Shared.DataTransferObjects;
using Api.Shared.Paging;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace Api.Presentation.Controllers;

[Route("api/companies/{companyId}/employees")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IServiceManager _service;

    public EmployeesController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployeesForCompany(int companyId, [FromQuery] PagingEmployeeParameters pagingEmployeeParameters)
    {
        var pagingResult = await _service.EmployeeService.GetEmployeesAsync(companyId, pagingEmployeeParameters, false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagingResult.pagingMetaData));

        return Ok(pagingResult.employees);
    }

    [HttpGet("{id:int}", Name = "GetEmployeeForCompany")]
    public async Task<IActionResult> GetEmployeeForCompany(int companyId, int id)
    {
        var employee = await _service.EmployeeService.GetEmployeeAsync(companyId, id, false);
        return Ok(employee);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateEmployeeForCompany(int companyId, [FromBody] EmployeeForCreationDto employee)
    {
        var employeeToReturn = await _service.EmployeeService.CreateEmployeeForCompanyAsync(companyId, employee, false);

        return CreatedAtRoute("GetEmployeeForCompany", new {companyId, id = employeeToReturn.EmployeeId}, employeeToReturn);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteEmployeeForCompany(int companyId, int id)
    {
        await _service.EmployeeService.DeleteEmployeeForCompanyAsync(companyId, id, false);

        return NoContent();
    }

    [HttpPut("{id:int}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateEmployeeForCompany(int companyId, int id, [FromBody] EmployeeForUpdateDto employee)
    {
        await _service.EmployeeService.UpdateEmployeeForCompanyAsync(companyId, id, employee, false, true);

        return NoContent();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> PartiallyUpdateEmployeeForCompany(int companyId, int id, [FromBody] JsonPatchDocument<EmployeeForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");

        var result = await _service.EmployeeService.GetEmployeeForPatchAsync(companyId, id, false,
            true);

        patchDoc.ApplyTo(result.employeeToPatch);

        TryValidateModel(result.employeeToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        await _service.EmployeeService.SaveChangesForPatchAsync(result.employeeToPatch, result.employeeEntity);

        return NoContent();
    }
}
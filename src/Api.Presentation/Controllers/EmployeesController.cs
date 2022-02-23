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

using Api.Service.Contracts;
using Api.Shared.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;

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
    public IActionResult GetEmployeesForCompany(int companyId)
    {
        var employees = _service.EmployeeService.GetEmployees(companyId, false);
        return Ok(employees);
    }

    [HttpGet("{id:int}", Name = "GetEmployeeForCompany")]
    public IActionResult GetEmployeeForCompany(int companyId, int id)
    {
        var employee = _service.EmployeeService.GetEmployee(companyId, id, false);
        return Ok(employee);
    }

    [HttpPost]
    public IActionResult CreateEmployeeForCompany(int companyId, [FromBody] EmployeeForCreationDto employee)
    {
        if (employee is null)
            return BadRequest("EmployeeForCreationDto object is null");

        var employeeToReturn = _service.EmployeeService.CreateEmployeeForCompany(companyId, employee, false);

        return CreatedAtRoute("GetEmployeeForCompany", new {companyId, id = employeeToReturn.Id}, employeeToReturn);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteEmployeeForCompany(int companyId, int id)
    {
        _service.EmployeeService.DeleteEmployeeForCompany(companyId, id, false);

        return NoContent();
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateEmployeeForCompany(int companyId, int id, [FromBody] EmployeeForUpdateDto employee)
    {
        if (employee is null)
            return BadRequest("EmployeeForUpdateDto object is null");

        _service.EmployeeService.UpdateEmployeeForCompany(companyId, id, employee, false, true);

        return NoContent();
    }
}
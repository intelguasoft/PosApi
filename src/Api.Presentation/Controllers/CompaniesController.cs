#region (c) 2022 Binary Builders Inc. All rights reserved.

// CompaniesController.cs
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

using Api.Presentation.ModelBinders;
using Api.Service.Contracts;
using Api.Shared.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;

#endregion

namespace Api.Presentation.Controllers;

[Route("api/companies")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly IServiceManager _service;

    public CompaniesController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetCompanies()
    {
        var companies = _service.CompanyService.GetAllCompanies(false);

        return Ok(companies);
    }

    [HttpGet("{id:int}", Name = "CompanyById")]
    public IActionResult GetCompany(int id)
    {
        var company = _service.CompanyService.GetCompany(id, false);
        return Ok(company);
    }

    [HttpGet("collection/({ids})", Name = "CompanyCollection")]
    public IActionResult GetCompanyCollection(
        [ModelBinder(BinderType = typeof(ArrayModelBinder))]
        IEnumerable<int> ids)
    {
        var companies = _service.CompanyService.GetByIds(ids, false);

        return Ok(companies);
    }

    [HttpPost]
    public IActionResult CreateCompany([FromBody] CompanyForCreationDto company)
    {
        if (company is null)
            return BadRequest("CompanyForCreationDto object is null");

        var createdCompany = _service.CompanyService.CreateCompany(company);

        // CreatedAtRoute will return a status code 201
        return CreatedAtRoute("CompanyById", new {id = createdCompany.Id}, createdCompany);
    }

    [HttpPost("collection")]
    public IActionResult CreateCompanyCollection([FromBody] IEnumerable<CompanyForCreationDto> companyCollection)
    {
        var result = _service.CompanyService.CreateCompanyCollection(companyCollection);

        return CreatedAtRoute("CompanyCollection", new {result.ids}, result.companies);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteCompany(int id)
    {
        _service.CompanyService.DeleteCompany(id, false);

        return NoContent();
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateCompany(int id, [FromBody] CompanyForUpdateDto company)
    {
        if (company is null)
            return BadRequest("CompanyForUpdateDto object is null");

        _service.CompanyService.UpdateCompany(id, company, true);

        return NoContent();
    }
}
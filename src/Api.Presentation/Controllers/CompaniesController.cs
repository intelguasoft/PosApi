﻿#region (c) 2022 Binary Builders Inc. All rights reserved.

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

using Api.Presentation.ActionFilters;
using Api.Presentation.ModelBinders;
using Api.Service.Contracts;
using Api.Shared.DataTransferObjects;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace Api.Presentation.Controllers;

[Route("api/companies")]
[ApiController]
//[ApiKey]
public class CompaniesController : ControllerBase
{
    private readonly IServiceManager _service;

    public CompaniesController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetCompaniesAsync(CancellationToken cancellationToken)
    {
        var companies = await _service.CompanyService.GetCompaniesAsync(false, cancellationToken).ConfigureAwait(false);

        return Ok(companies);
    }

    [HttpGet("{id:int}", Name = "CompanyById")]
    public async Task<IActionResult> GetCompanyAsync(int id, CancellationToken cancellationToken)
    {
        var company = await _service.CompanyService.GetCompanyAsync(id, false, cancellationToken).ConfigureAwait(false);
        return Ok(company);
    }

    [HttpGet("collection/({ids})", Name = "CompanyCollection")]
    public async Task<IActionResult> GetCompanyCollectionAsync([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<int> ids, CancellationToken cancellationToken)
    {
        var companies = await _service.CompanyService.GetByIdsAsync(ids, false, cancellationToken).ConfigureAwait(false);

        return Ok(companies);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateCompanyAsync([FromBody] CompanyForCreationDto company, CancellationToken cancellationToken)
    {
        var createdCompany = await _service.CompanyService.CreateCompanyAsync(company, cancellationToken).ConfigureAwait(false);

        return CreatedAtRoute("CompanyById", new {id = createdCompany?.CompanyId}, createdCompany);
    }

    [HttpPost("collection")]
    public async Task<IActionResult> CreateCompanyCollectionAsync([FromBody] IEnumerable<CompanyForCreationDto> companyCollection, CancellationToken cancellationToken)
    {
        var result = await _service.CompanyService.CreateCompanyCollectionAsync(companyCollection, cancellationToken).ConfigureAwait(false);

        return CreatedAtRoute("CompanyCollection", new {result.ids}, result.companies);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCompanyAsync(int id, CancellationToken cancellationToken)
    {
        await _service.CompanyService.DeleteCompanyAsync(id, false, cancellationToken).ConfigureAwait(false);

        return NoContent();
    }

    [HttpPut("{id:int}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateCompanyAsync(int id, [FromBody] CompanyForUpdateDto company, CancellationToken cancellationToken)
    {
        await _service.CompanyService.UpdateCompanyAsync(id, company, true, cancellationToken).ConfigureAwait(false);

        return NoContent();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> PartiallyUpdateCompanyAsync(int id, [FromBody] JsonPatchDocument<CompanyForUpdateDto> patchDoc, CancellationToken cancellationToken)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");

        var result = await _service.CompanyService.GetCompanyForPatchAsync(id, true, cancellationToken).ConfigureAwait(false);

        patchDoc.ApplyTo(result.companyToPatch);

        await _service.CompanyService.SaveChangesForPatchAsync(result.companyToPatch, result.companyEntity, cancellationToken).ConfigureAwait(false);

        return NoContent();
    }
}
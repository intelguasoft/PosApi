#region (c) 2022 Binary Builders Inc. All rights reserved.

// CompanyService.cs
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

using Entities;
using Api.Entities.Exceptions;
using Api.Interfaces;
using Api.Service.Interfaces;
using Api.Shared.DataTransferObjects;
using AutoMapper;

#endregion

namespace Api.Service;

internal sealed class CompanyService : ICompanyService
{
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;

    public CompanyService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CompanyDto>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges, CancellationToken cancellationToken)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();

        var companyEntities = await _repository.Company.GetByIdsAsync(ids, trackChanges, cancellationToken: cancellationToken).ConfigureAwait(false);
        if (ids.Count() != companyEntities.Count())
            throw new CollectionByIdsBadRequestException();

        var companiesToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);

        return companiesToReturn;
    }

    public async Task<(IEnumerable<CompanyDto> companies, string ids)> CreateCompanyCollectionAsync
        (IEnumerable<CompanyForCreationDto> companyCollection, CancellationToken cancellationToken)
    {
        if (companyCollection is null)
            throw new CompanyCollectionBadRequestException();

        var companyEntities = _mapper.Map<IEnumerable<Company_Company>>(companyCollection);
        foreach (var company in companyEntities)
            _repository.Company.CreateCompany(company);

        await _repository.SaveAsync(cancellationToken: cancellationToken).ConfigureAwait(false);

        var companyCollectionToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);
        var ids = string.Join(",", companyCollectionToReturn.Select(c => c.CompanyId));

        return (companies: companyCollectionToReturn, ids);
    }

    public async Task DeleteCompanyAsync(int companyId, bool trackChanges, CancellationToken cancellationToken)
    {
        var company = await GetCompanyAndCheckIfItExistsAsync(companyId, trackChanges, cancellationToken).ConfigureAwait(false);

        _repository.Company.DeleteCompany(company);
        await _repository.SaveAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
    }

    public async Task UpdateCompanyAsync(int companyId, CompanyForUpdateDto companyForUpdate, bool trackChanges, CancellationToken cancellationToken)
    {
        var company = await GetCompanyAndCheckIfItExistsAsync(companyId, trackChanges, cancellationToken).ConfigureAwait(false);

        _mapper.Map(companyForUpdate, company);
        await _repository.SaveAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
    }

    public async Task<IEnumerable<CompanyDto>> GetCompaniesAsync(bool trackChanges, CancellationToken cancellationToken)
    {
        var companies = await _repository.Company.GetCompaniesAsync(trackChanges, cancellationToken: cancellationToken).ConfigureAwait(false);

        var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);

        return companiesDto;
    }

    public async Task<CompanyDto> GetCompanyAsync(int companyId, bool trackChanges, CancellationToken cancellationToken)
    {
        var company = await GetCompanyAndCheckIfItExistsAsync(companyId, trackChanges, cancellationToken).ConfigureAwait(false);

        var companyDto = _mapper.Map<CompanyDto>(company);
        return companyDto;
    }

    public async Task<CompanyDto> CreateCompanyAsync(CompanyForCreationDto company, CancellationToken cancellationToken)
    {
        var companyEntity = _mapper.Map<Company_Company>(company);

        _repository.Company.CreateCompany(companyEntity);
        await _repository.SaveAsync(cancellationToken: cancellationToken).ConfigureAwait(false);

        var companyToReturn = _mapper.Map<CompanyDto>(companyEntity);

        return companyToReturn;
    }

    public async Task SaveChangesForPatchAsync(CompanyForUpdateDto companyToPatch, Company_Company companyEntity, CancellationToken cancellationToken)
    {
        _mapper.Map(companyToPatch, companyEntity);
        await _repository.SaveAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
    }

    public async Task<(CompanyForUpdateDto companyToPatch, Company_Company companyEntity)> GetCompanyForPatchAsync(int companyId, bool compTrackChanges, CancellationToken cancellationToken)
    {
        var companyEntity = await _repository.Company.GetCompanyAsync(companyId, compTrackChanges, cancellationToken: cancellationToken).ConfigureAwait(false);
        if (companyEntity is null)
            throw new CompanyNotFoundException(companyId);

        var companyToPatch = _mapper.Map<CompanyForUpdateDto>(companyEntity);

        return (companyToPatch, companyEntity);
    }

    private async Task<Company_Company> GetCompanyAndCheckIfItExistsAsync(int id, bool trackChanges, CancellationToken cancellationToken)
    {
        var company = await _repository.Company.GetCompanyAsync(id, trackChanges, cancellationToken).ConfigureAwait(false);
        if (company is null)
            throw new CompanyNotFoundException(id);

        return company;
    }
}
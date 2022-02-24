﻿#region (c) 2022 Binary Builders Inc. All rights reserved.

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

using Api.Contracts;
using Api.Entities.Exceptions;
using Api.Entities.Models;
using Api.Service.Contracts;
using Api.Shared.DataTransferObjects;
using AutoMapper;
using Shared.DataTransferObjects;

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

    public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
    {
        var companies = _repository.Company.GetAllCompanies(trackChanges);

        var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);

        return companiesDto;
    }

    public CompanyDto GetCompany(int companyId, bool trackChanges)
    {
        var company = _repository.Company.GetCompany(companyId, trackChanges);
        if (company is null)
            throw new CompanyNotFoundException(companyId);

        var companyDto = _mapper.Map<CompanyDto>(company);
        return companyDto;
    }

    public CompanyDto CreateCompany(CompanyForCreationDto company)
    {
        var companyEntity = _mapper.Map<Company>(company);

        _repository.Company.CreateCompany(companyEntity);
        _repository.Save();

        var companyToReturn = _mapper.Map<CompanyDto>(companyEntity);

        return companyToReturn;
    }

    public IEnumerable<CompanyDto> GetByIds(IEnumerable<int> ids, bool trackChanges)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();

        var companyEntities = _repository.Company.GetByIds(ids, trackChanges);
        if (ids.Count() != companyEntities.Count())
            throw new CollectionByIdsBadRequestException();

        var companiesToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);

        return companiesToReturn;
    }

    public (IEnumerable<CompanyDto> companies, string ids) CreateCompanyCollection
        (IEnumerable<CompanyForCreationDto> companyCollection)
    {
        if (companyCollection is null)
            throw new CompanyCollectionBadRequest();

        var companyEntities = _mapper.Map<IEnumerable<Company>>(companyCollection);
        foreach (var company in companyEntities) _repository.Company.CreateCompany(company);

        _repository.Save();

        var companyCollectionToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);
        var ids = string.Join(",", companyCollectionToReturn.Select(c => c.Id));

        return (companies: companyCollectionToReturn, ids);
    }

    public void DeleteCompany(int companyId, bool trackChanges)
    {
        var company = _repository.Company.GetCompany(companyId, trackChanges);
        if (company is null)
            throw new CompanyNotFoundException(companyId);

        _repository.Company.DeleteCompany(company);
        _repository.Save();
    }

    public void UpdateCompany(int companyId, CompanyForUpdateDto companyForUpdate, bool trackChanges)
    {
        var companyEntity = _repository.Company.GetCompany(companyId, trackChanges);
        if (companyEntity is null)
            throw new CompanyNotFoundException(companyId);

        _mapper.Map(companyForUpdate, companyEntity);
        _repository.Save();
    }

    public void SaveChangesForPatch(CompanyForUpdateDto companyToPatch, Company companyEntity)
    {
        _mapper.Map(companyToPatch, companyEntity);
        _repository.Save();
    }

    public (CompanyForUpdateDto companyToPatch, Company companyEntity) GetCompanyForPatch(int companyId, bool compTrackChanges)
    {
        var companyEntity = _repository.Company.GetCompany(companyId, compTrackChanges);
        if (companyEntity is null)
            throw new CompanyNotFoundException(companyId);

        var companyToPatch = _mapper.Map<CompanyForUpdateDto>(companyEntity);

        return (companyToPatch, companyEntity);
    }
}
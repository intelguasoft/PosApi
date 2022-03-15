﻿#region (c) 2022 Binary Builders Inc. All rights reserved.

// RepositoryManager.cs
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
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

#endregion

namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly string _apiKey;
    private readonly Lazy<Interfaces.ICompanyRepository> _companyRepository;
    private readonly Lazy<Interfaces.IEmployeeRepository> _employeeRepository;
    private readonly RepositoryContext _repositoryContext;

    public RepositoryManager(RepositoryContext repositoryContext, Service.Interfaces.IApiKeyService apiKeyService)
    {
        _repositoryContext = repositoryContext;
        _apiKey = apiKeyService.GetApiKey();
        _companyRepository = new Lazy<Interfaces.ICompanyRepository>(() => new Repository.CompanyRepository(repositoryContext));
        _employeeRepository = new Lazy<Interfaces.IEmployeeRepository>(() => new EmployeeRepository(repositoryContext));
    }

    private Company_Company UpdateCompanyAuditing(Company_Company referenceEntity, EntityEntry trackerEntry)
    {
        switch (trackerEntry.State)
        {
            case EntityState.Added:
                referenceEntity!.CreatedDate = DateTime.Now;
                referenceEntity.CreatedByApiKey = _apiKey;
                break;

            case EntityState.Deleted:
                referenceEntity.IsDeleted = true;
                referenceEntity!.LastModifiedDate = DateTime.Now;
                referenceEntity.LastModifiedApiKey = _apiKey;
                break;

            case EntityState.Modified:
                referenceEntity!.LastModifiedDate = DateTime.Now;
                referenceEntity.LastModifiedApiKey = _apiKey;
                break;

            case EntityState.Detached:
                break;

            case EntityState.Unchanged:
                break;

            default:
                throw new ArgumentOutOfRangeException("{");
        }

        return referenceEntity;
    }

    private Employee_Employee UpdateEmployeeAuditing(Employee_Employee referenceEntity, EntityEntry trackerEntry)
    {
        switch (trackerEntry.State)
        {
            case EntityState.Added:
                referenceEntity!.CreatedDate = DateTime.Now;
                referenceEntity.CreatedApiKey = _apiKey;
                break;

            case EntityState.Deleted:
                referenceEntity.IsDeleted = true;
                referenceEntity!.LastModifiedDate = DateTime.Now;
                referenceEntity.LastModifiedApiKey = _apiKey;
                break;

            case EntityState.Modified:
                referenceEntity!.LastModifiedDate = DateTime.Now;
                referenceEntity.LastModifiedApiKey = _apiKey;
                break;

            case EntityState.Detached:
                break;

            case EntityState.Unchanged:
                break;

            default:
                throw new ArgumentOutOfRangeException("{");
        }

        return referenceEntity;
    }

    public async Task SaveAsync(CancellationToken cancellationToken)
    {
        var tracker = _repositoryContext.ChangeTracker;

        foreach (var trackerEntry in tracker.Entries())
        {
            // todo - create generic
            if (trackerEntry.Entity is Company_Company companyEntity)
                UpdateCompanyAuditing(companyEntity, trackerEntry);

            if (trackerEntry.Entity is Employee_Employee employeeEntity)
                UpdateEmployeeAuditing(employeeEntity, trackerEntry);
        }

        await _repositoryContext.SaveChangesAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
    }

    public Interfaces.ICompanyRepository Company => _companyRepository.Value;
    public Interfaces.IEmployeeRepository Employee => _employeeRepository.Value;
}
#region (c) 2022 Binary Builders Inc. All rights reserved.

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

using Api.Entities.Models;
using Api.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repository;

#endregion

namespace Api.Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<ICompanyRepository> _companyRepository;
    private readonly string _defaultApiKey = "a2229196-5eb8-4a14-a234-b5451df0a08b";
    private readonly Lazy<IEmployeeRepository> _employeeRepository;
    private readonly RepositoryContext _repositoryContext;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _companyRepository = new Lazy<ICompanyRepository>(() => new CompanyRepository(repositoryContext));
        _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(repositoryContext));
    }

    public ICompanyRepository Company => _companyRepository.Value;
    public IEmployeeRepository Employee => _employeeRepository.Value;

    public async Task SaveAsync()
    {
        var tracker = _repositoryContext.ChangeTracker;

        foreach (var entry in tracker.Entries())
        {
            var apiKey = string.Empty;
            if (entry.Entity is Company)
            {
                var companyEntity = entry.Entity as Company;
                apiKey = companyEntity.ApiKey;
            }

            if (entry.Entity is FullAuditModel)
            {
                var referenceEntity = entry.Entity as FullAuditModel;
                switch (entry.State)
                {
                    case EntityState.Added:
                        referenceEntity!.CreatedDate = DateTime.Now;
                        referenceEntity.CreatedByApiKey = apiKey;
                        break;
                    case EntityState.Deleted:
                        referenceEntity.IsDeleted = true;
                        break;
                    case EntityState.Modified:
                        referenceEntity!.LastModifiedDate = DateTime.Now;
                        referenceEntity.LastModifiedApiKey = apiKey;
                        break;
                }
            }
        }

        await _repositoryContext.SaveChangesAsync();
    }
}
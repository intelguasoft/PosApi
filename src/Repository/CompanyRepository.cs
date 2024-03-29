﻿#region (c) 2022 Binary Builders Inc. All rights reserved.

// CompanyRepository.cs
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

using AutoMapper;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.DataTransferObjects;
using Shared.Paging;
using Shared.Parameters;

#endregion

namespace Repository;

internal sealed class CompanyRepository : RepositoryBase<Company_Company>, Interfaces.ICompanyRepository
{
    private readonly IMapper _mapper;
    private readonly RepositoryContext _repositoryContext;

    internal CompanyRepository(RepositoryContext repositoryContext, IMapper mapper)
        : base(repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _mapper = mapper;
    }

    public void CreateCompany(Company_Company company)
    {
        Create(company);
    }

    public void DeleteCompany(Company_Company company)
    {
        Delete(company);
    }

    public async Task<IEnumerable<Company_Company>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges, CancellationToken cancellationToken)
    {
        return await FindByCondition(c => ids.Contains(c.CompanyId), trackChanges).ToListAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
    }

    public async Task<PagingList<Company_Company>> GetCompaniesAsync(CompanyRequestParameters companyRequestParameters, bool trackChanges, CancellationToken cancellationToken)
    {
        // the order is filter, search, sort
        var companies = await FindAll(trackChanges)
            .SearchByCompanyName(companyRequestParameters.SearchTerm)
            .OrderBy(c => c.Name)
            .Skip((companyRequestParameters.PageNumber - 1) * companyRequestParameters.PageSize)
            .Take(companyRequestParameters.PageSize)
            .ToListAsync(cancellationToken: cancellationToken).ConfigureAwait(false);

        var count = await FindByCondition(c => c.CompanyId > 0, trackChanges).CountAsync(cancellationToken: cancellationToken).ConfigureAwait(false);

        return new PagingList<Company_Company>(companies, count, companyRequestParameters.PageNumber, companyRequestParameters.PageSize);
    }

    public async Task<Company_Company> GetCompanyAsync(int companyId, bool trackChanges, CancellationToken cancellationToken)
    {
        return await FindByCondition(c => c.CompanyId.Equals(companyId), trackChanges).SingleOrDefaultAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
    }

    public async Task<IEnumerable<CompanyJoinEmployeeDto>> GetCompanyWithEmployeesAsync(int companyId, bool trackChanges, CancellationToken cancellationToken)
    {

        // works
        //return await (from c in _repositoryContext.Company_Companies
        //              join e in _repositoryContext.Employee_Employees on c.CompanyId equals e.CompanyId
        //              where c.CompanyId == companyId
        //              orderby e.LastName, e.FirstName, e.MiddleName
        //              select new CompanyJoinEmployeeDto { Company = c, Employee = e }).ToListAsync(cancellationToken).ConfigureAwait(false);

        return await (from c in _repositoryContext.Company_Companies
                      join e in _repositoryContext.Employee_Employees on c.CompanyId equals e.CompanyId
                      where c.CompanyId == companyId
                      orderby e.LastName, e.FirstName, e.MiddleName
                      select new CompanyJoinEmployeeDto 
                      { 
                          CompanyId = c.CompanyId,
                          Name = c.Name,   
                          EmployeeId = e.EmployeeId,
                          FirstName = e.FirstName,
                          MiddleName = e.MiddleName,
                          LastName = e.LastName
                      }).ToListAsync(cancellationToken).ConfigureAwait(false);
    }
}
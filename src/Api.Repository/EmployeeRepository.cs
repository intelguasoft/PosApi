﻿#region (c) 2022 Binary Builders Inc. All rights reserved.

// EmployeeRepository.cs
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
using Api.Repository;
using Api.Shared.Paging;
using Microsoft.EntityFrameworkCore;

#endregion

namespace Repository;

internal sealed class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    public EmployeeRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public async Task<Employee> GetEmployeeAsync(int companyId, int id, bool trackChanges)
    {
        return await FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
    }

    public void CreateEmployeeForCompany(int companyId, Employee employee)
    {
        employee.CompanyId = companyId;
        Create(employee);
    }

    public void DeleteEmployee(Employee employee)
    {
        Delete(employee);
    }

    // method #1
    //public async Task<PagingList<Employee>> GetEmployeesAsync(int companyId, PagingEmployeeParameters pagingEmployeeParameters, bool trackChanges)
    //{
    //    var employees = await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
    //        .OrderBy(e => e.LastName).ThenBy(e => e.FirstName).ThenBy(e => e.MiddleName)
    //        .ToListAsync();

    //    return PagingList<Employee>
    //        .ToPagingList(employees, pagingEmployeeParameters.PageNumber, pagingEmployeeParameters.PageSize);
    //}

    // method #2 for larger tables
    public async Task<PagingList<Employee>> GetEmployeesAsync(int companyId, PagingEmployeeParameters pagingEmployeeParameters, bool trackChanges)
    {
        var employees = await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
            .OrderBy(e => e.LastName).ThenBy(e => e.FirstName).ThenBy(e => e.MiddleName)
            .Skip((pagingEmployeeParameters.PageNumber - 1) * pagingEmployeeParameters.PageSize)
            .Take(pagingEmployeeParameters.PageSize)
            .ToListAsync();

        var count = await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges).CountAsync();

        return new PagingList<Employee>(employees, count, pagingEmployeeParameters.PageNumber, pagingEmployeeParameters.PageSize);
    }
}
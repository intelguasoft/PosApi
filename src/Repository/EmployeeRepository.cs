#region (c) 2022 Binary Builders Inc. All rights reserved.

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

using Entities;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Paging;
using Shared.Parameters;

#endregion


namespace Repository;

internal sealed class EmployeeRepository : RepositoryBase<Employee_Employee>, IEmployeeRepository
{
    internal EmployeeRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public void CreateEmployeeForCompany(int companyId, Employee_Employee employee, CancellationToken cancellationToken)
    {
        employee.CompanyId = companyId;
        Create(employee);
    }

    public void DeleteEmployee(Employee_Employee employee)
    {
        Delete(employee);
    }

    public async Task<Employee_Employee> GetEmployeeAsync(int companyId, int id, bool trackChanges, CancellationToken cancellationToken)
    {
        return await FindByCondition(e => e.CompanyId.Equals(companyId) && e.EmployeeId.Equals(id), trackChanges)
            .SingleOrDefaultAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
    }

    // method #1
    //public async Task<PagingList<Employee>> GetEmployeesAsync(int companyId, employeeRequestParameters employeeRequestParameters, bool trackChanges)
    //{
    //    var employees = await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
    //        .OrderBy(e => e.LastName).ThenBy(e => e.FirstName).ThenBy(e => e.MiddleName)
    //        .ToListAsync();

    //    return PagingList<Employee>
    //        .ToPagingList(employees, employeeRequestParameters.PageNumber, employeeRequestParameters.PageSize);
    //}

    // method #2 for larger tables
    public async Task<PagingList<Employee_Employee>> GetEmployeesAsync(int companyId, EmployeeRequestParameters employeeRequestParameters, bool trackChanges, CancellationToken cancellationToken)
    {
        var employees = await FindByCondition(e => e.CompanyId.Equals(companyId) &&
            (e.Age >= employeeRequestParameters.MinAge && e.Age <= employeeRequestParameters.MaxAge), trackChanges)
            .OrderBy(e => e.LastName).ThenBy(e => e.FirstName).ThenBy(e => e.MiddleName)
            .Skip((employeeRequestParameters.PageNumber - 1) * employeeRequestParameters.PageSize)
            .Take(employeeRequestParameters.PageSize)
            .ToListAsync(cancellationToken: cancellationToken).ConfigureAwait(false);

        var count = await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges).CountAsync(cancellationToken: cancellationToken).ConfigureAwait(false);

        return new PagingList<Employee_Employee>(employees, count, employeeRequestParameters.PageNumber, employeeRequestParameters.PageSize);
    }
}
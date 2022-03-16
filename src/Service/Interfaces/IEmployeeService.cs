#region (c) 2022 Binary Builders Inc. All rights reserved.

// IEmployeeService.cs
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
using Entities.Models;
using Shared.DataTransferObjects;
using Shared.Paging;
using Shared.Parameters;

#endregion

namespace Service.Interfaces;

public interface IEmployeeService
{

    Task<Shared.DataTransferObjects.EmployeeDto> CreateEmployeeForCompanyAsync(
        int companyId,
        Shared.DataTransferObjects.EmployeeForCreationDto employeeForCreation,
        bool trackChanges,
        CancellationToken cancellationToken);

    Task DeleteEmployeeForCompanyAsync(
        int companyId,
        int id,
        bool trackChanges,
        CancellationToken cancellationToken);

    Task<Shared.DataTransferObjects.EmployeeDto> GetEmployeeAsync(
        int companyId,
        int id,
        bool trackChanges,
        CancellationToken cancellationToken);

    Task<(EmployeeForUpdateDto employeeToPatch, Employee_Employee employeeEntity)> GetEmployeeForPatchAsync(
        int companyId,
        int id,
        bool compTrackChanges,
        bool empTrackChanges,
        CancellationToken cancellationToken);

    Task<(IEnumerable<Entity> employees, PagingMetaData pagingMetaData)> GetEmployeesAsync(
        int companyId,
        EmployeeRequestParameters employeeRequestParameters,
        bool trackChanges,
        CancellationToken cancellationToken);

    Task SaveChangesForPatchAsync(
        EmployeeForUpdateDto employeeToPatch,
        Employee_Employee employeeEntity,
        CancellationToken cancellationToken);

    Task UpdateEmployeeForCompanyAsync(
        int companyId,
        int id,
        EmployeeForUpdateDto employeeForUpdate,
        bool compTrackChanges,
        bool empTrackChanges,
        CancellationToken cancellationToken);
}
#region (c) 2022 Binary Builders Inc. All rights reserved.

// IEmployeeRepository.cs
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

using Api.Entities;
using Api.Shared.Paging;

#endregion

namespace Api.Interfaces;

public interface IEmployeeRepository
{
    Task<PagingList<Employee_Employee>> GetEmployeesAsync(int companyId, PagingEmployeeParameters pagingEmployeeParameters, bool trackChanges, CancellationToken cancellationToken);
    Task<Employee_Employee> GetEmployeeAsync(int companyId, int id, bool trackChanges, CancellationToken cancellationToken);
    void CreateEmployeeForCompany(int companyId, Employee_Employee employee, CancellationToken cancellationToken);
    void DeleteEmployee(Employee_Employee employee);
}
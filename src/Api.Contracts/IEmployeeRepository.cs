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

using Api.Entities.Models;

#endregion

namespace Api.Contracts;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetEmployeesAsync(int companyId, bool trackChanges);
    Task<Employee> GetEmployeeAsync(int companyId, int id, bool trackChanges);
    void CreateEmployeeForCompany(int companyId, Employee employee);
    void DeleteEmployee(Employee employee);
}
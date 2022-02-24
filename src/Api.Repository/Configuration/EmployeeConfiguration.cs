#region (c) 2022 Binary Builders Inc. All rights reserved.

// EmployeeConfiguration.cs
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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace Api.Repository.Configuration;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasData
        (
            new Employee
            {
                Id = 1,
                FirstName = "Sam",
                MiddleName = "A",
                LastName = "Raiden",
                Age = 26,
                Position = "Software developer",
                Phone = "713-100-0000",
                CompanyId = 1
            },
            new Employee
            {
                Id = 2,
                FirstName = "Jana",
                MiddleName = "B",
                LastName = "McLeaf",
                Age = 30,
                Position = "Software developer",
                Phone = "832-200-0000",
                CompanyId = 1
            },
            new Employee
            {
                Id = 3,
                FirstName = "Kane",
                MiddleName = "C",
                LastName = "Miller",
                Age = 35,
                Position = "Administrator",
                Phone = "346-300-0000",
                CompanyId = 2
            }
        );
    }
}
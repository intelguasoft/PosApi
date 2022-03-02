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
                Phone = "100-300-0000",
                CompanyId = 2
            },
            new Employee
            {
                Id = 4,
                FirstName = "Michael",
                MiddleName = "D",
                LastName = "Worth",
                Age = 25,
                Position = "Support I",
                Phone = "200-300-0000",
                CompanyId = 2
            },
            new Employee
            {
                Id = 5,
                FirstName = "Nina",
                MiddleName = "E",
                LastName = "Hawk",
                Age = 35,
                Position = "Support II",
                Phone = "300-300-0000",
                CompanyId = 2
            },
            new Employee
            {
                Id = 6,
                FirstName = "John",
                MiddleName = "F",
                LastName = "Spike",
                Age = 29,
                Position = "Support III",
                Phone = "400-300-0000",
                CompanyId = 2
            },
            new Employee
            {
                Id = 7,
                FirstName = "Michael",
                MiddleName = "G",
                LastName = "Fins",
                Age = 20,
                Position = "Support VI",
                Phone = "500-300-0000",
                CompanyId = 2
            },
            new Employee
            {
                Id = 8,
                FirstName = "Martha",
                MiddleName = "H",
                LastName = "Growns",
                Age = 22,
                Position = "Developer I",
                Phone = "500-300-0000",
                CompanyId = 2
            },
            new Employee
            {
                Id = 9,
                FirstName = "Kirk",
                MiddleName = "H",
                LastName = "Metha",
                Age = 24,
                Position = "Developer II",
                Phone = "600-300-0000",
                CompanyId = 2
            },
            new Employee
            {
                Id = 10,
                FirstName = "John",
                MiddleName = "I",
                LastName = "Smith",
                Age = 25,
                Position = "Developer III",
                Phone = "500-300-0000",
                CompanyId = 3
            },
            new Employee
            {
                Id = 11,
                FirstName = "Walter",
                MiddleName = "J",
                LastName = "White",
                Age = 25,
                Position = "Developer IV",
                Phone = "600-300-0000",
                CompanyId = 3
            }
        );
    }
}
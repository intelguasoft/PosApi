#region (c) 2022 Binary Builders Inc. All rights reserved.

// CompanyConfiguration.cs
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

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    private readonly string _defaultApiKey = "a2229196-5eb8-4a14-a234-b5451df0a08b";
    private readonly DateTime _dtNow = DateTime.Now;

    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasData
        (
            new Company
            {
                Id = 1,
                Name = "IT_Solutions Ltd",
                Address = "583 Wall Dr. Gwynn Oak, MD 21207",
                City = "Los Angeles",
                State = "CA",
                ZipCode = "90001",
                Country = "USA",
                Phone = "800-123-4567",
                CreatedByApiKey = _defaultApiKey,
                CreatedDate = _dtNow,
                LastModifiedApiKey = _defaultApiKey,
                LastModifiedDate = _dtNow
            },
            new Company
            {
                Id = 2,
                Name = "Admin_Solutions Ltd",
                Address = "312 Forest Avenue, BF 923",
                City = "New York",
                State = "NY",
                ZipCode = "10001",
                Country = "USA",
                Phone = "888-123-4567",
                CreatedByApiKey = _defaultApiKey,
                CreatedDate = _dtNow,
                LastModifiedApiKey = _defaultApiKey,
                LastModifiedDate = _dtNow
            },
            new Company
            {
                Id = 3,
                Name = "New Generation Electronics",
                Address = "10000 North Loop East",
                City = "Houston",
                State = "TX",
                ZipCode = "77002",
                Country = "USA",
                Phone = "866-100-2000",
                CreatedByApiKey = _defaultApiKey,
                CreatedDate = _dtNow,
                LastModifiedApiKey = _defaultApiKey,
                LastModifiedDate = _dtNow
            }
        );
    }
}
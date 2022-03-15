#region (c) 2022 Binary Builders Inc. All rights reserved.

// EmployeeDto.cs
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


#endregion

namespace Shared.DataTransferObjects;

public record EmployeeDto
{
    public int Age { get; init; }
    public int EmployeeId { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? MiddleName { get; init; }
    public string? Phone { get; init; }
    public string? Position { get; init; }

    //bool IsDeleted,
    //string CreatedApiKey,
    //DateTime CreatedDate,
    //string LastModifiedApiKey,
    //DateTime LastModifiedDate)
}
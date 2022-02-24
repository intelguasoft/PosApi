#region (c) 2022 Binary Builders Inc. All rights reserved.

// EmployeeForManipulationDto.cs
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

using System.ComponentModel.DataAnnotations;

#endregion

namespace Api.Shared.DataTransferObjects;

public abstract record EmployeeForManipulationDto
{
    [Required(ErrorMessage = "Employee first name is a required field.")]
    [MaxLength(15, ErrorMessage = "Maximum length for the FirstName is 15 characters.")]
    public string? FirstName { get; init; }

    [Required(ErrorMessage = "Employee first name is a required field.")]
    [MaxLength(15, ErrorMessage = "Maximum length for the MiddleName is 15 characters.")]
    public string? MiddleName { get; init; }

    [Required(ErrorMessage = "Employee first name is a required field.")]
    [MaxLength(15, ErrorMessage = "Maximum length for the LastName is 15 characters.")]
    public string? LastName { get; init; }

    [Required(ErrorMessage = "Age is a required field.")]
    [Range(18, int.MaxValue, ErrorMessage = "Age is required and it can't be lower than 18")]
    public int Age { get; init; }

    [Required(ErrorMessage = "Position is a required field.")]
    [MaxLength(20, ErrorMessage = "Maximum length for the Position is 20 characters.")]
    public string? Position { get; init; }

    [Required(ErrorMessage = "Phone is a required field.")]
    [Phone]
    public string? Phone { get; init; }
}
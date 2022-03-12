#region (c) 2022 Binary Builders Inc. All rights reserved.

// CompanyForManipulationDto.cs
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
using System.Diagnostics.CodeAnalysis;
using NDepend.Attributes;

#endregion

[assembly: SuppressMessage("NDepend", "ND1500:APIBreakingChangesTypes", Target = "Shared.DataTransferObjects", Scope = "type", Justification = "TODO")]

namespace Api.Shared.DataTransferObjects;

[FullCovered]
public abstract record CompanyForManipulationDtoBase
{
    [Required(ErrorMessage = "Company name is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
    public string? Name { get; init; }

    [Required(ErrorMessage = "Company address is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Address is 60 characters.")]
    public string? Address { get; init; }

    [Required(ErrorMessage = "Company city is a required field.")]
    [MaxLength(20, ErrorMessage = "Maximum length for the City is 20 characters.")]
    public string? City { get; set; }

    [Required(ErrorMessage = "Company state is a required field.")]
    [MaxLength(20, ErrorMessage = "Maximum length for the State is 2 characters.")]
    public string? State { get; set; }

    [Required(ErrorMessage = "Company zipcode is a required field.")]
    [MaxLength(10, ErrorMessage = "Maximum length for the ZipCode is 10 characters.")]
    public string? ZipCode { get; set; }

    [Required(ErrorMessage = "Company country is a required field.")]
    [MaxLength(20, ErrorMessage = "Maximum length for the Country is 20 characters.")]
    public string? Country { get; init; }

    [Required(ErrorMessage = "Company phone is a required field.")]
    [MaxLength(15, ErrorMessage = "Maximum length for the Phone is 15 characters.")]
    public string? Phone { get; init; }
}
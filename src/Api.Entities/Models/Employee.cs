﻿#region (c) 2022 Binary Builders Inc. All rights reserved.

// Employee.cs
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
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace Api.Entities.Models;

public class Employee
{
    [Column("EmployeeId")] public int Id { get; set; }

    [Required(ErrorMessage = "Employee first name is a required field.")]
    [MaxLength(15, ErrorMessage = "Maximum length for the FirstName is 15 characters.")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Employee middle name is a required field.")]
    [MaxLength(15, ErrorMessage = "Maximum length for the MiddleName is 15 characters.")]
    public string? MiddleName { get; set; }

    [Required(ErrorMessage = "Employee last name is a required field.")]
    [MaxLength(15, ErrorMessage = "Maximum length for the LastName is 15 characters.")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Age is a required field.")]
    public int Age { get; set; }

    [Required(ErrorMessage = "Position is a required field.")]
    [MaxLength(20, ErrorMessage = "Maximum length for the Position is 20 characters.")]
    public string? Position { get; set; }

    [Phone] public string? Phone { get; set; }

    [ForeignKey(nameof(Company))] public int CompanyId { get; set; }

    public Company? Company { get; set; }
}
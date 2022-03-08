#region (c) 2022 Binary Builders Inc. All rights reserved.

// FullAuditModel.cs
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

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Api.Entities.Interfaces;

#endregion

namespace Api.Entities.Models;

public abstract class FullAuditModel : IAuditedModel, ISoftDeletable
{
    [Required(ErrorMessage = "CreatedByApiKey is a required field.")]
    [MaxLength(100, ErrorMessage = "Maximum length for the Name is 100 characters.")]
    public string CreatedByApiKey { get; set; }

    [Required(ErrorMessage = "CreatedDate is a required field.")]
    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [MaxLength(100, ErrorMessage = "Maximum length for the Name is 100 characters.")]
    public string? LastModifiedApiKey { get; set; }

    [Column(TypeName = "datetime")] public DateTime? LastModifiedDate { get; set; }

    [Required] [DefaultValue(false)] public bool IsDeleted { get; set; }
}
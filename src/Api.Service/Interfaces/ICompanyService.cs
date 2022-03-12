#region (c) 2022 Binary Builders Inc. All rights reserved.

// ICompanyService.cs
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
using Api.Shared.DataTransferObjects;

#endregion

namespace Api.Service.Interfaces;

public interface ICompanyService
{
    Task<CompanyDto> CreateCompanyAsync(CompanyForCreationDto company, CancellationToken cancellationToken);

    Task<(IEnumerable<CompanyDto> companies, string ids)> CreateCompanyCollectionAsync(IEnumerable<CompanyForCreationDto> companyCollection, CancellationToken cancellationToken);

    Task DeleteCompanyAsync(int companyId, bool trackChanges, CancellationToken cancellationToken);

    Task<IEnumerable<CompanyDto>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges, CancellationToken cancellationToken);

    Task<IEnumerable<CompanyDto>> GetCompaniesAsync(bool trackChanges, CancellationToken cancellationToken);

    Task<CompanyDto> GetCompanyAsync(int companyId, bool trackChanges, CancellationToken cancellationToken);

    Task<(CompanyForUpdateDto companyToPatch, Company_Company companyEntity)> GetCompanyForPatchAsync(int companyId, bool compTrackChanges, CancellationToken cancellationToken);

    Task SaveChangesForPatchAsync(CompanyForUpdateDto companyToPatch, Company_Company companyEntity, CancellationToken cancellationToken);

    Task UpdateCompanyAsync(int companyId, CompanyForUpdateDto companyForUpdate, bool trackChanges, CancellationToken cancellationToken);
}
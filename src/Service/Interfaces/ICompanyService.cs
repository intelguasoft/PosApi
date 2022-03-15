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

using Entities;
using Shared.Paging;
using Shared.Parameters;

#endregion

namespace Service.Interfaces;

public interface ICompanyService
{
    Task<Shared.DataTransferObjects.CompanyDto> CreateCompanyAsync(Shared.DataTransferObjects.CompanyForCreationDto company, CancellationToken cancellationToken);

    Task<(IEnumerable<Shared.DataTransferObjects.CompanyDto> companies, string ids)> CreateCompanyCollectionAsync(IEnumerable<Shared.DataTransferObjects.CompanyForCreationDto> companyCollection, CancellationToken cancellationToken);

    Task DeleteCompanyAsync(int companyId, bool trackChanges, CancellationToken cancellationToken);

    Task<IEnumerable<Shared.DataTransferObjects.CompanyDto>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges, CancellationToken cancellationToken);

    Task<(IEnumerable<Shared.DataTransferObjects.CompanyDto> companies, PagingMetaData pagingMetaData)> GetCompaniesAsync(
        CompanyRequestParameters companyRequestParameters, 
        bool trackChanges, 
        CancellationToken cancellationToken);

    Task<Shared.DataTransferObjects.CompanyDto> GetCompanyAsync(int companyId, bool trackChanges, CancellationToken cancellationToken);

    Task<(Shared.DataTransferObjects.CompanyForUpdateDto companyToPatch, Company_Company companyEntity)> GetCompanyForPatchAsync(int companyId, bool compTrackChanges, CancellationToken cancellationToken);

    Task SaveChangesForPatchAsync(Shared.DataTransferObjects.CompanyForUpdateDto companyToPatch, Company_Company companyEntity, CancellationToken cancellationToken);

    Task UpdateCompanyAsync(int companyId, Shared.DataTransferObjects.CompanyForUpdateDto companyForUpdate, bool trackChanges, CancellationToken cancellationToken);
}
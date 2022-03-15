#region (c) 2022 Binary Builders Inc. All rights reserved.

// ICompanyRepository.cs
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

#region using

using Entities;
using Shared.Paging;
using Shared.Parameters;

namespace Interfaces;

#endregion

public interface ICompanyRepository
{
    void CreateCompany(Company_Company company);

    void DeleteCompany(Company_Company company);

    Task<IEnumerable<Company_Company>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges, CancellationToken cancellationToken);

    Task<PagingList<Company_Company>> GetCompaniesAsync(CompanyRequestParameters companyRequestParameters, bool trackChanges, CancellationToken cancellationToken);

    Task<Company_Company> GetCompanyAsync(int companyId, bool trackChanges, CancellationToken cancellationToken);
}
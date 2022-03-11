#region (c) 2022 Binary Builders Inc. All rights reserved.

// CompanyRepository.cs
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
using Api.Interfaces;
using Microsoft.EntityFrameworkCore;

#endregion

namespace Api.Repository;

internal sealed class CompanyRepository : RepositoryBase<Company_Company>, ICompanyRepository
{
    public CompanyRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public void CreateCompany(Company_Company company)
    {
        Create(company);
    }

    public void DeleteCompany(Company_Company company)
    {
        Delete(company);
    }

    public async Task<IEnumerable<Company_Company>> GetCompaniesAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToListAsync();
    }

    public async Task<Company_Company> GetCompanyAsync(int companyId, bool trackChanges)
    {
        return await FindByCondition(c => c.CompanyId.Equals(companyId), trackChanges).SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<Company_Company>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges)
    {
        return await FindByCondition(x => ids.Contains(x.CompanyId), trackChanges).ToListAsync();
    }
}
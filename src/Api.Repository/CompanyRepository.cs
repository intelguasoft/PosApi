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

using Api.Contracts;
using Api.Entities.Models;

#endregion

namespace Api.Repository;

internal sealed class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
{
    public CompanyRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public IEnumerable<Company> GetAllCompanies(bool trackChanges)
    {
        return FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToList();
    }

    public Company GetCompany(int companyId, bool trackChanges)
    {
        return FindByCondition(c => c.Id.Equals(companyId), trackChanges).SingleOrDefault();
    }

    public void CreateCompany(Company company)
    {
        Create(company);
    }

    public IEnumerable<Company> GetByIds(IEnumerable<int> ids, bool trackChanges)
    {
        return FindByCondition(x => ids.Contains(x.Id), trackChanges).ToList();
    }

    public void DeleteCompany(Company company)
    {
        Delete(company);
    }
}
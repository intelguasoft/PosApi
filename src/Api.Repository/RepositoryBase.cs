#region (c) 2022 Binary Builders Inc. All rights reserved.

// RepositoryBase.cs
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

using System.Linq.Expressions;
using Entities;
using Api.Interfaces;
using Microsoft.EntityFrameworkCore;

#endregion

namespace Api.Repository;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    private readonly RepositoryContext _repositoryContext;

    public RepositoryBase(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
    }

    public IQueryable<T> FindAll(bool trackChanges)
    {
        return !trackChanges
            ? _repositoryContext.Set<T>()
                .AsNoTracking()
            : _repositoryContext.Set<T>();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
        bool trackChanges)
    {
        return !trackChanges
            ? _repositoryContext.Set<T>()
                .Where(expression)
                .AsNoTracking()
            : _repositoryContext.Set<T>()
                .Where(expression);
    }

    public void Create(T entity)
    {
        _repositoryContext.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        _repositoryContext.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        _repositoryContext.Set<T>().Remove(entity);
    }
}
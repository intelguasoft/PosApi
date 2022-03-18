#region (c) 2022 Binary Builders Inc. All rights reserved.

// ServiceManager.cs
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

using AutoMapper;
using Interfaces;
using Microsoft.AspNetCore.Http;
using Service.Interfaces;
using Shared.DataTransferObjects;

#endregion

namespace Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<ICompanyService> _companyService;
    private readonly Lazy<IEmployeeService> _employeeService;
    private readonly Lazy<IApiKeyService> _apiKeyService;

    public ServiceManager(
        IRepositoryManager repositoryManager, 
        ILoggerManager logger, 
        IMapper mapper, 
        IHttpContextAccessor httpContextAccessor,
        IEmployeeLinks employeeLinks)
    {
        _companyService = new Lazy<ICompanyService>(() => new CompanyService(repositoryManager, logger, mapper));
        _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager, logger, mapper, employeeLinks));
        _apiKeyService = new Lazy<IApiKeyService>(() => new ApiKeyService(httpContextAccessor));
    }

    public ICompanyService CompanyService => _companyService.Value;
    public IEmployeeService EmployeeService => _employeeService.Value;
    public IApiKeyService ApiKeyService => _apiKeyService.Value;
}
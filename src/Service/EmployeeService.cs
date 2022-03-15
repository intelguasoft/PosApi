#region (c) 2022 Binary Builders Inc. All rights reserved.

// EmployeeService.cs
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
using Entities;
using Entities.Exceptions;
using Interfaces;
using Service.Interfaces;
using Shared.DataTransferObjects;
using Shared.Paging;
using Shared.Parameters;

#endregion

namespace Service;

internal sealed class EmployeeService : IEmployeeService
{
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;

    public EmployeeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    private async Task CheckIfCompanyExistsAsync(int companyId, bool trackChanges, CancellationToken cancellationToken)
    {
        var company = await _repository.Company.GetCompanyAsync(companyId, trackChanges, cancellationToken).ConfigureAwait(false);
        if (company is null)
            throw new CompanyNotFoundException(companyId);
    }

    private async Task<Employee_Employee> GetEmployeeForCompanyAndCheckIfItExistsAsync(
        int companyId,
        int id,
        bool trackChanges,
        CancellationToken cancellationToken)
    {
        var employeeDb = await _repository.Employee.GetEmployeeAsync(companyId, id, trackChanges, cancellationToken).ConfigureAwait(false);
        if (employeeDb is null)
            throw new EmployeeNotFoundException(id);

        return employeeDb;
    }

    public async Task<EmployeeDto> CreateEmployeeForCompanyAsync(
        int companyId,
        EmployeeForCreationDto employeeForCreation,
        bool trackChanges,
        CancellationToken cancellationToken)
    {
        await CheckIfCompanyExistsAsync(companyId, trackChanges, cancellationToken).ConfigureAwait(false);

        var employeeEntity = _mapper.Map<Employee_Employee>(employeeForCreation);

        _repository.Employee.CreateEmployeeForCompany(companyId, employeeEntity, cancellationToken);
        await _repository.SaveAsync(cancellationToken).ConfigureAwait(false);

        var employeeToReturn = _mapper.Map<EmployeeDto>(employeeEntity);

        return employeeToReturn;
    }

    public async Task DeleteEmployeeForCompanyAsync(
        int companyId,
        int id,
        bool trackChanges,
        CancellationToken cancellationToken)
    {
        await CheckIfCompanyExistsAsync(companyId, trackChanges, cancellationToken).ConfigureAwait(false);

        var employeeDb = await GetEmployeeForCompanyAndCheckIfItExistsAsync(companyId, id, trackChanges, cancellationToken).ConfigureAwait(false);

        _repository.Employee.DeleteEmployee(employeeDb);
        await _repository.SaveAsync(cancellationToken).ConfigureAwait(false);
    }

    public async Task<EmployeeDto> GetEmployeeAsync(
        int companyId,
        int id,
        bool trackChanges,
        CancellationToken cancellationToken)
    {
        await CheckIfCompanyExistsAsync(companyId, trackChanges, cancellationToken).ConfigureAwait(false);

        var employeeDb = await GetEmployeeForCompanyAndCheckIfItExistsAsync(companyId, id, trackChanges, cancellationToken).ConfigureAwait(false);

        var employee = _mapper.Map<EmployeeDto>(employeeDb);
        return employee;
    }

    public async Task<(EmployeeForUpdateDto employeeToPatch, Employee_Employee employeeEntity)> GetEmployeeForPatchAsync(
        int companyId,
        int id,
        bool compTrackChanges,
        bool empTrackChanges,
        CancellationToken cancellationToken)
    {
        await CheckIfCompanyExistsAsync(companyId, compTrackChanges, cancellationToken).ConfigureAwait(false);

        var employeeDb = await GetEmployeeForCompanyAndCheckIfItExistsAsync(companyId, id, empTrackChanges, cancellationToken).ConfigureAwait(false);

        var employeeToPatch = _mapper.Map<EmployeeForUpdateDto>(employeeDb);

        return (employeeToPatch, employeeEntity: employeeDb);
    }

    public async Task<(IEnumerable<EmployeeDto> employees, PagingMetaData pagingMetaData)> GetEmployeesAsync(
        int companyId,
        EmployeeRequestParameters employeeRequestParameters,
        bool trackChanges,
        CancellationToken cancellationToken)
    {
        if (!employeeRequestParameters.ValidAgeRange)
            throw new MaxAgeRangeBadRequestException();

        await CheckIfCompanyExistsAsync(companyId, trackChanges, cancellationToken).ConfigureAwait(false);

        var employeesWithMetaData = await _repository.Employee.GetEmployeesAsync(companyId, employeeRequestParameters, trackChanges, cancellationToken).ConfigureAwait(false);
        var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesWithMetaData);

        return (employees: employeesDto, pagingMetaData: employeesWithMetaData.PagingMetaData);
    }

    public async Task SaveChangesForPatchAsync(EmployeeForUpdateDto employeeToPatch, Employee_Employee employeeEntity, CancellationToken cancellationToken)
    {
        _mapper.Map(employeeToPatch, employeeEntity);
        await _repository.SaveAsync(cancellationToken).ConfigureAwait(false);
    }

    public async Task UpdateEmployeeForCompanyAsync(
        int companyId,
        int id,
        EmployeeForUpdateDto employeeForUpdate,
        bool compTrackChanges,
        bool empTrackChanges,
        CancellationToken cancellationToken)
    {
        await CheckIfCompanyExistsAsync(companyId, compTrackChanges, cancellationToken).ConfigureAwait(false);

        var employeeDb = await GetEmployeeForCompanyAndCheckIfItExistsAsync(companyId, id, empTrackChanges, cancellationToken).ConfigureAwait(false);

        _mapper.Map(employeeForUpdate, employeeDb);
        await _repository.SaveAsync(cancellationToken).ConfigureAwait(false);
    }
}
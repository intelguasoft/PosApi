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

using Api.Contracts;
using Api.Entities.Exceptions;
using Api.Entities.Models;
using Api.Service.Contracts;
using Api.Shared.DataTransferObjects;
using AutoMapper;
using Shared.DataTransferObjects;

#endregion

namespace Api.Service;

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

    public IEnumerable<EmployeeDto> GetEmployees(int companyId, bool trackChanges)
    {
        var company = _repository.Company.GetCompany(companyId, trackChanges);
        if (company is null)
            throw new CompanyNotFoundException(companyId);

        var employeesFromDb = _repository.Employee.GetEmployees(companyId, trackChanges);
        var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDb);

        return employeesDto;
    }

    public EmployeeDto GetEmployee(int companyId, int id, bool trackChanges)
    {
        var company = _repository.Company.GetCompany(companyId, trackChanges);
        if (company is null)
            throw new CompanyNotFoundException(companyId);

        var employeeDb = _repository.Employee.GetEmployee(companyId, id, trackChanges);
        if (employeeDb is null)
            throw new EmployeeNotFoundException(id);

        var employee = _mapper.Map<EmployeeDto>(employeeDb);
        return employee;
    }

    public EmployeeDto CreateEmployeeForCompany(int companyId, EmployeeForCreationDto employeeForCreation, bool trackChanges)
    {
        var company = _repository.Company.GetCompany(companyId, trackChanges);
        if (company is null)
            throw new CompanyNotFoundException(companyId);

        var employeeEntity = _mapper.Map<Employee>(employeeForCreation);

        _repository.Employee.CreateEmployeeForCompany(companyId, employeeEntity);
        _repository.Save();

        var employeeToReturn = _mapper.Map<EmployeeDto>(employeeEntity);

        return employeeToReturn;
    }

    public void DeleteEmployeeForCompany(int companyId, int id, bool trackChanges)
    {
        var company = _repository.Company.GetCompany(companyId, trackChanges);
        if (company is null)
            throw new CompanyNotFoundException(companyId);

        var employeeForCompany = _repository.Employee.GetEmployee(companyId, id, trackChanges);
        if (employeeForCompany is null)
            throw new EmployeeNotFoundException(id);

        _repository.Employee.DeleteEmployee(employeeForCompany);
        _repository.Save();
    }

    public void UpdateEmployeeForCompany(int companyId, int id, EmployeeForUpdateDto employeeForUpdate, bool compTrackChanges, bool empTrackChanges)
    {
        var company = _repository.Company.GetCompany(companyId, compTrackChanges);
        if (company is null)
            throw new CompanyNotFoundException(companyId);

        var employeeEntity = _repository.Employee.GetEmployee(companyId, id, empTrackChanges);
        if (employeeEntity is null)
            throw new EmployeeNotFoundException(id);

        _mapper.Map(employeeForUpdate, employeeEntity);
        _repository.Save();
    }

    public (EmployeeForUpdateDto employeeToPatch, Employee employeeEntity) GetEmployeeForPatch(int companyId, int id, bool compTrackChanges, bool empTrackChanges)
    {
        var company = _repository.Company.GetCompany(companyId, compTrackChanges);
        if (company is null)
            throw new CompanyNotFoundException(companyId);

        var employeeEntity = _repository.Employee.GetEmployee(companyId, id, empTrackChanges);
        if (employeeEntity is null)
            throw new EmployeeNotFoundException(companyId);

        var employeeToPatch = _mapper.Map<EmployeeForUpdateDto>(employeeEntity);

        return (employeeToPatch, employeeEntity);
    }

    public void SaveChangesForPatch(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)
    {
        _mapper.Map(employeeToPatch, employeeEntity);
        _repository.Save();
    }
}
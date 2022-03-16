#region (c) 2022 Binary Builders Inc. All rights reserved.

// CompanyControllerTests.cs
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
using FakeItEasy;
using Presentation.Controllers;
using Service.Interfaces;
using System.Collections.Generic;
using Xunit;

#endregion

namespace UnitTests;

public class CompanyControllerTests
{
    private readonly CompaniesController _controller;

    private readonly Interfaces.ICompanyRepository _repository;

    private readonly IServiceManager _serviceManager;

    public CompanyControllerTests()
    {
        _repository = A.Fake<Interfaces.ICompanyRepository>();
        _serviceManager = A.Fake<IServiceManager>();
        _controller = A.Fake<CompaniesController>();
    }

    [Fact]
    public void Get_ActionExecutes_ReturnsViewForGet()
    {
        // arrange
        var listOfEmployees = new List<Employee_Employee>();
        listOfEmployees.Add(new Employee_Employee
        {
            CompanyId = 1,
            EmployeeId = 1,
            FirstName = "Bob",
            MiddleName = "D",
            LastName = "Smith",
            Age = 20

        });

        listOfEmployees.Add(new Employee_Employee
        {
            CompanyId = 1,
            EmployeeId = 2,
            FirstName = "Alice",
            MiddleName = "C",
            LastName = "Clark",
            Age = 25
        });

        var expectedCompany = new Company_Company
        {
            CompanyId = 1,
            Name = "Marketing Solutions Ltd",
            Address = "242 Sunny Ave, K334",
            City = "Los Angeles",
            State = "CA",
            ZipCode = "90801",
            Country = "USA",
            Employee_Employees = listOfEmployees
        };

        A.CallTo(() => _repository.GetCompanyAsync(1, false, default)).Returns(expectedCompany);
        var actualCompany = _repository.GetCompanyAsync(1, false, default);

        // assert
        Assert.NotNull(actualCompany);
        Assert.Equal(expectedCompany.Name, actualCompany.Result.Name);

        var employees = actualCompany.Result.Employee_Employees;
        Assert.True(actualCompany.Result.Employee_Employees.Count == listOfEmployees.Count);
    }
}
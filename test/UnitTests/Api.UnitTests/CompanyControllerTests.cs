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

using System.Collections.Generic;
using Api.Entities.Models;
using Api.Interfaces;
using Api.Presentation.Controllers;
using Api.Service.Contracts;
using FakeItEasy;
using Xunit;

#endregion

namespace Api.UnitTests;

public class CompanyControllerTests
{
    private readonly CompaniesController _controller;

    private readonly ICompanyRepository _repository;

    private readonly IServiceManager _serviceManager;

    public CompanyControllerTests()
    {
        _repository = A.Fake<ICompanyRepository>();
        _serviceManager = A.Fake<IServiceManager>();
        _controller = A.Fake<CompaniesController>();
    }

    [Fact]
    public void Get_ActionExecutes_ReturnsViewForGet()
    {
        // arrange
        var listOfEmployees = new List<Employee>();
        listOfEmployees.Add(new Employee
        {
            Age = 20,
            FirstName = "John",
            MiddleName = "D",
            LastName = "Smith"
        });

        var company = new Company
        {
            Name = "Marketing Solutions Ltd",
            Address = "242 Sunny Ave, K334",
            City = "Los Angeles",
            State = "CA",
            ZipCode = "90801",
            Country = "USA",
            Employees = listOfEmployees
        };

        A.CallTo(() => _repository.GetCompanyAsync(1, false)).Returns(company);
        var result = _repository.GetCompanyAsync(1, false);

        // assert
        Assert.NotNull(result);
        Assert.Equal(company.Name, result.Result.Name);
    }
}
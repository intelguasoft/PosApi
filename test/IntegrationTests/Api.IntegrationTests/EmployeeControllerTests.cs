#region (c) 2022 Binary Builders Inc. All rights reserved.

// EmployeeControllerTests.cs
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
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Api.Shared.DataTransferObjects;
using Newtonsoft.Json;
using Xunit;

#endregion

namespace Api.IntegrationTests;

public class EmployeeControllerTests : IClassFixture<TestingWebAppFactory<Program>>
{
    // https://code-maze.com/aspnet-core-integration-testing/

    private readonly HttpClient _client;

    public EmployeeControllerTests(TestingWebAppFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetCompanyEmployees_WhenCalled_Returns_Employees()
    {
        // act
        var response = await _client.GetAsync("api/companies/1/employees");

        // assert
        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();

        Assert.Contains("McLeaf", responseString);

        var employees = JsonConvert.DeserializeObject<IEnumerable<EmployeeDto>>(response.Content.ReadAsStringAsync().Result);
        Assert.True(employees?.Count() > 0);
    }

    [Fact]
    public async Task GetCompanyEmployee_WhenCalled_Returns_Employee()
    {
        // act
        var response = await _client.GetAsync("api/companies/1/employees/2");

        // assert
        response.EnsureSuccessStatusCode();

        var employee = JsonConvert.DeserializeObject<EmployeeDto>(response.Content.ReadAsStringAsync().Result);
        Assert.True(employee?.Id == 2);
    }

    [Fact]
    public async Task CreateEmployeeForCompany_WhenCalled_Creates_Employee()
    {
        // arrange
        var companyId = 1;

        // ----
        // POST
        // ----

        var postEmployee = new EmployeeForCreationDto
        {
            FirstName = "Curly",
            MiddleName = "Lester",
            LastName = "Horwitz",
            Age = 30,
            Phone = "346-300-4000",
            Position = "Manager"
        };

        // act
        var payLoad = new StringContent(JsonConvert.SerializeObject(postEmployee), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync($"api/companies/{companyId}/employees", payLoad);

        // assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        var employee = JsonConvert.DeserializeObject<EmployeeDto>(response.Content.ReadAsStringAsync().Result);
        Assert.True(employee?.Id > 0);

        // ---
        // PUT
        // ---

        // arrange
        var putEmployee = new EmployeeForCreationDto
        {
            FirstName = "Mo",
            MiddleName = "Harry",
            LastName = "Horwitz",
            Age = 30,
            Phone = "346-300-4000",
            Position = "Manager"
        };

        // act
        payLoad = new StringContent(JsonConvert.SerializeObject(putEmployee), Encoding.UTF8, "application/json");
        response = await _client.PutAsync($"api/companies/{companyId}/employees/{employee?.Id}", payLoad);

        // assert
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

        // -----
        // PATCH
        // -----

        // arrange
        var patchEmployee = new EmployeeForCreationDto
        {
            FirstName = "Larry",
            MiddleName = "Fine",
            LastName = "Horwitz"
        };

        // act
        payLoad = new StringContent(JsonConvert.SerializeObject(patchEmployee), Encoding.UTF8, "application/json");
        response = await _client.PatchAsync($"api/companies/{companyId}/employees/{employee?.Id}", payLoad);

        // assert
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

        // ------
        // DELETE
        // ------

        // act
        response = await _client.DeleteAsync($"api/companies/{companyId}/employees/{employee?.Id}");

        // assert
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }

    [Fact]
    public async Task CreateEmployee_WhenPassed_InvalidData_Returns_UnprocessableEntity()
    {
        // arrange
        var companyId = 1;

        // note null position
        var postEmployee = new EmployeeForCreationDto
        {
            FirstName = "Curly",
            MiddleName = "Lester",
            LastName = "Horwitz",
            Age = 30,
            Phone = "346-300-4000",
            Position = null
        };


        // act
        var payLoad = new StringContent(JsonConvert.SerializeObject(postEmployee), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync($"api/companies/{companyId}/employees", payLoad);

        // assert
        Assert.Equal(HttpStatusCode.UnprocessableEntity, response.StatusCode);
    }

    [Fact]
    public async Task UpdateEmployee_WhenPassed_InvalidData_Returns_UnprocessableEntity()
    {
        // arrange
        var companyId = 1;
        var employeeId = 1;

        // note null last name
        var putEmployee = new EmployeeForCreationDto
        {
            FirstName = "Larry",
            MiddleName = "Fine",
            LastName = null
        };

        // act
        var payLoad = new StringContent(JsonConvert.SerializeObject(putEmployee), Encoding.UTF8, "application/json");
        var response = await _client.PutAsync($"api/companies/{companyId}/employees/{employeeId}", payLoad);

        // assert
        Assert.Equal(HttpStatusCode.UnprocessableEntity, response.StatusCode);
    }
}
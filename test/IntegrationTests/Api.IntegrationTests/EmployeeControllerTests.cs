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

using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Api;

#endregion

namespace IntegrationTests;

public class EmployeeControllerTests : IClassFixture<TestingWebAppFactory<Program>>
{
     private const string APIKEYNAME = "x-posapi-key";

    private readonly string _apiKey;
    // https://code-maze.com/aspnet-core-integration-testing/

    private readonly HttpClient _client;

    public EmployeeControllerTests(TestingWebAppFactory<Program> factory)
    {
        var config = InitConfiguration();
        _apiKey = config[APIKEYNAME];

        _client = factory.CreateClient();

        // https://makolyte.com/csharp-how-to-add-request-headers-when-using-httpclient/
        _client.DefaultRequestHeaders.Add(APIKEYNAME, _apiKey);
    }

    [Fact]
    public async Task CreateEmployee_WhenPassed_InvalidData_Returns_UnprocessableEntity()
    {
        // arrange
        var companyId = 1;

        // note null position
        var postEmployee = new Shared.DataTransferObjects.EmployeeForCreationDto
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
        var response = await _client.PostAsync($"api/companies/{companyId}/employees", payLoad).ConfigureAwait(false);

        // assert
        Assert.Equal(HttpStatusCode.UnprocessableEntity, response.StatusCode);
    }

    [Fact]
    public async Task CreateEmployeeForCompany_WhenCalled_Creates_Employee()
    {
        // arrange
        var companyId = 1;

        // ----
        // POST
        // ----

        var postEmployee = new Shared.DataTransferObjects.EmployeeForCreationDto
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
        var response = await _client.PostAsync($"api/companies/{companyId}/employees", payLoad).ConfigureAwait(false);

        // assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        var employee = JsonConvert.DeserializeObject<Shared.DataTransferObjects.EmployeeDto>(response.Content.ReadAsStringAsync().Result);
        Assert.True(employee?.EmployeeId > 0);

        // ---
        // PUT
        // ---

        // arrange
        var putEmployee = new Shared.DataTransferObjects.EmployeeForCreationDto
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
        response = await _client.PutAsync($"api/companies/{companyId}/employees/{employee?.EmployeeId}", payLoad).ConfigureAwait(false);

        // assert
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

        // -----
        // PATCH
        // -----

        // arrange
        var patchEmployee = new Shared.DataTransferObjects.EmployeeForCreationDto
        {
            FirstName = "Larry",
            MiddleName = "Fine",
            LastName = "Horwitz"
        };

        // act
        payLoad = new StringContent(JsonConvert.SerializeObject(patchEmployee), Encoding.UTF8, "application/json");
        response = await _client.PatchAsync($"api/companies/{companyId}/employees/{employee?.EmployeeId}", payLoad).ConfigureAwait(false);

        // assert
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

        // ------
        // DELETE
        // ------

        // act
        response = await _client.DeleteAsync($"api/companies/{companyId}/employees/{employee?.EmployeeId}").ConfigureAwait(false);

        // assert
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }

    [Fact]
    public async Task GetCompanyEmployee_WhenCalled_Returns_Employee()
    {
        // act
        var response = await _client.GetAsync("api/companies/1/employees/1").ConfigureAwait(false);

        // assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var json = response.Content.ReadAsStringAsync().Result;
        var employee = JsonConvert.DeserializeObject<Shared.DataTransferObjects.EmployeeDto>(json);
        Assert.NotNull(employee);
    }

    [Fact]
    public async Task GetCompanyEmployees_WhenCalled_Returns_Employees()
    {
        var response = await _client.GetAsync("api/companies/1/employees").ConfigureAwait(false);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        Assert.Contains("Raiden", responseString);

        var employees = JsonConvert.DeserializeObject<IEnumerable<Shared.DataTransferObjects.EmployeeDto>>(response.Content.ReadAsStringAsync().Result);
        Assert.True(employees?.Count() > 0);
    }

    [Fact]
    public async Task GetCompanyEmployees_With_DataShaper_Option_Returns_Data_Shaped_Employees()
    {
        var response = await _client.GetAsync("api/companies/1/employees?fields=FirstName,LastName,Age").ConfigureAwait(false);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        Assert.Contains("FirstName", responseString);
        Assert.Contains("LastName", responseString);
        Assert.Contains("Age", responseString);

        var employees = JsonConvert.DeserializeObject<IEnumerable<Shared.DataTransferObjects.EmployeeDto>>(response.Content.ReadAsStringAsync().Result);
        Assert.True(employees?.Count() == 5);
    }

    [Fact]
    public async Task GetCompanyEmployees_WhenCalled_Returns_PagedEmployees()
    {
        // arrange
        var companyId = 3;
        var pageNumber = 1;
        var pageSize = 3;

        // act
        var response = await _client.GetAsync($"api/companies/{companyId}/employees?pageNumber={pageNumber}&pageSize={pageSize}").ConfigureAwait(false);

        // assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var employees = JsonConvert.DeserializeObject<IEnumerable<Shared.DataTransferObjects.EmployeeDto>>(response.Content.ReadAsStringAsync().Result);
        Assert.True(employees?.Count() == 3);
    }

    public static IConfiguration InitConfiguration()
    {
        // https://stackoverflow.com/questions/39791634/read-appsettings-json-values-in-net-core-test-project

        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.test.json")
            .AddEnvironmentVariables()
            .Build();
        return config;
    }

    [Fact]
    public async Task UpdateEmployee_WhenPassed_InvalidData_Returns_UnprocessableEntity()
    {
        // arrange
        var companyId = 1;
        var employeeId = 1;

        // note null last name
        var putEmployee = new Shared.DataTransferObjects.EmployeeForCreationDto
        {
            FirstName = "Larry",
            MiddleName = "Fine",
            LastName = null
        };

        // act
        var payLoad = new StringContent(JsonConvert.SerializeObject(putEmployee), Encoding.UTF8, "application/json");
        var response = await _client.PutAsync($"api/companies/{companyId}/employees/{employeeId}", payLoad).ConfigureAwait(false);

        // assert
        Assert.Equal(HttpStatusCode.UnprocessableEntity, response.StatusCode);
    }
}
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

public class CompanyControllerTests : IClassFixture<TestingWebAppFactory<Program>>
{
    // https://code-maze.com/aspnet-core-integration-testing/

    private readonly HttpClient _client;

    public CompanyControllerTests(TestingWebAppFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Index_WhenCalled_Returns_ApplicationForm()
    {
        // act
        var response = await _client.GetAsync("api/companies");

        // assert
        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();

        Assert.Contains("Admin_Solutions Ltd", responseString);
        Assert.Contains("IT_Solutions Ltd", responseString);
    }

    [Fact]
    public async Task GetCompany_WhenCalled_Returns_RequestedCompany()
    {
        // act
        var response = await _client.GetAsync("api/companies/1");

        // assert
        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();

        Assert.Contains("IT_Solutions Ltd", responseString);
    }

    [Fact]
    public async Task GetCompanyCollection_WhenCalled_Returns_RequestedCompanies()
    {
        // act
        var response = await _client.GetAsync("api/companies/collection/(1,2)");

        // assert
        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();

        Assert.Contains("IT_Solutions Ltd", responseString);
        Assert.Contains("Admin_Solutions Ltd", responseString);
    }

    [Fact]
    public async Task CreateCompany_WhenPassedValidData_Returns_Success()
    {
        // ----
        // POST
        // ----

        // arrange
        var postCompany = new CompanyForCreationDto
        {
            Name = "Bit Friendly Networks",
            Address = "5000 Almeda Road",
            City = "Kansas City",
            State = "KS",
            ZipCode = "30000",
            Country = "USA",
            Phone = "200-300-4000"
        };

        // act
        var payLoad = new StringContent(JsonConvert.SerializeObject(postCompany), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("api/companies", payLoad);

        // assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        var company = JsonConvert.DeserializeObject<CompanyDto>(response.Content.ReadAsStringAsync().Result);
        Assert.True(company?.Id > 0);

        // ---
        // PUT
        // ---

        // arrange
        var putCompany = new CompanyForCreationDto
        {
            Name = "Byte Friendly Networks",
            Address = "5000 Almeda Road",
            City = "Kansas City",
            State = "KS",
            ZipCode = "30000",
            Country = "USA",
            Phone = "200-300-4000"
        };

        // act
        payLoad = new StringContent(JsonConvert.SerializeObject(putCompany), Encoding.UTF8, "application/json");
        response = await _client.PutAsync($"api/companies/{company?.Id}", payLoad);

        // assert
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

        // -----
        // PATCH
        // -----

        // arrange
        var patchCompany = new CompanyForCreationDto
        {
            Name = "FooBar Friendly Networks"
        };

        // act
        payLoad = new StringContent(JsonConvert.SerializeObject(patchCompany), Encoding.UTF8, "application/json");
        response = await _client.PatchAsync($"api/companies/{company.Id}", payLoad);

        // assert
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

        // ------
        // DELETE
        // ------

        // act
        response = await _client.DeleteAsync($"api/companies/{company?.Id}");

        // assert
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }

    [Fact]
    public async Task CreateCompany_WhenPassed_InvalidData_Returns_UnprocessableEntity()
    {
        // arrange - with null phone number
        var company = new CompanyForCreationDto
        {
            Name = "Bit Flip Networks",
            Address = "5000 Almeda Road",
            City = "Kansas City",
            State = "KS",
            ZipCode = "30000",
            Country = "USA",
            Phone = null
        };

        // act
        var payLoad = new StringContent(JsonConvert.SerializeObject(company), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("api/companies", payLoad);

        // assert
        Assert.Equal(HttpStatusCode.UnprocessableEntity, response.StatusCode);
    }

    [Fact]
    public async Task UpdateCompany_WhenPassed_InvalidData_Returns_UnprocessableEntity()
    {
        var companyId = 1;

        // arrange - with null phone number
        var putCompany = new CompanyForCreationDto
        {
            Name = "Bit Flip Networks",
            Address = "5000 Almeda Road",
            City = "Kansas City",
            State = "KS",
            ZipCode = "30000",
            Country = "USA",
            Phone = null
        };

        // act
        var payLoad = new StringContent(JsonConvert.SerializeObject(putCompany), Encoding.UTF8, "application/json");
        var response = await _client.PutAsync($"api/companies/{companyId}", payLoad);

        // assert
        Assert.Equal(HttpStatusCode.UnprocessableEntity, response.StatusCode);
    }

    [Fact]
    public async Task CreateCompanyCollection_WhenPassed_ValidData_Creates_MultipleCompanies()
    {
        // arrange
        var listOfCompanies = new List<CompanyForCreationDto>();

        var aCompany = new CompanyForCreationDto
        {
            Name = "Bit Friendly Networks",
            Address = "5000 Almeda Road",
            City = "Kansas City",
            State = "KS",
            ZipCode = "30000",
            Country = "USA",
            Phone = "200-300-4000"
        };

        listOfCompanies.Add(aCompany);

        aCompany = new CompanyForCreationDto
        {
            Name = "Byte Friendly Networks",
            Address = "5000 Almeda Road",
            City = "Kansas City",
            State = "KS",
            ZipCode = "30000",
            Country = "USA",
            Phone = "200-300-4000"
        };

        listOfCompanies.Add(aCompany);

        // act
        var payLoad = new StringContent(JsonConvert.SerializeObject(listOfCompanies), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("api/companies/collection", payLoad);

        // assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        var companies = JsonConvert.DeserializeObject<IEnumerable<CompanyDto>>(response.Content.ReadAsStringAsync().Result);

        Assert.True(companies?.Count() == 2);
    }

    [Fact]
    public async Task PartiallyUpdateCompany_WhenPassed_ValidData_Patches_Company()
    {
        // arrange
        var newCompany = new CompanyForCreationDto
        {
            Name = "Bit Friendly Networks",
            Address = "5000 Almeda Road",
            City = "Kansas City",
            State = "KS",
            ZipCode = "30000",
            Country = "USA",
            Phone = "200-300-4000"
        };

        // act
        var payLoad = new StringContent(JsonConvert.SerializeObject(newCompany), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("api/companies", payLoad);

        // assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        var company = JsonConvert.DeserializeObject<CompanyDto>(response.Content.ReadAsStringAsync().Result);
        Assert.True(company?.Id > 0);
    }
}
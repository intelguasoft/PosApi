#region (c) 2022 Binary Builders Inc. All rights reserved.

// TestingWebAppFactory.cs
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

using System.Linq;
using Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NDepend.Attributes;

#endregion

namespace Api.IntegrationTests;

[FullCovered]
public class TestingWebAppFactory<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(DbContextOptions<RepositoryContext>));

            if (descriptor != null)
                services.Remove(descriptor);

            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlServer("server=.; database=PosApi; Integrated Security=true");
                options.EnableSensitiveDataLogging();
            });

            //services.AddDbContext<_repositoryContext>(options =>
            //{
            //    options.UseInMemoryDatabase("InMemoryEmployeeTest");
            //    options.EnableSensitiveDataLogging();
            //});

            var sp = services.BuildServiceProvider();
            using (var scope = sp.CreateScope())
            using (var appContext = scope.ServiceProvider.GetRequiredService<RepositoryContext>())
            {
                appContext.Database.EnsureCreated();
            }
        });
    }
}
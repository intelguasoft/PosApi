#region (c) 2022 Binary Builders Inc. All rights reserved.

// ServiceExtensions.cs
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
using Interfaces;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service;
using Service.Interfaces;

#endregion

namespace Api.Extensions;

public static class ServiceExtensions
{

    public static IMvcBuilder AddCustomCSVFormatter(this IMvcBuilder builder)
    {
        return builder.AddMvcOptions(config => config.OutputFormatters.Add(new CsvOutputFormatter()));
    }

    public static void ConfigureApiKeyService(this IServiceCollection services)
    {
        services.AddScoped<Service.Interfaces.IApiKeyService, ApiKeyService>();
    }
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });
    }

    public static void ConfigureHttpContextAccessor(this IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }

    public static void ConfigureIISIntegration(this IServiceCollection services)
    {
        services.Configure<IISOptions>(options => { });
    }

    public static void ConfigureLoggerService(this IServiceCollection services)
    {
        services.AddSingleton<Interfaces.ILoggerManager, LoggerManager>();
    }

    public static void ConfigureRepositoryManager(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryManager, RepositoryManager>();
    }

    public static void ConfigureServiceManager(this IServiceCollection services)
    {
        services.AddScoped<IServiceManager, ServiceManager>();
    }

    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RepositoryContext>(opts =>
            opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
    }

	public static void AddCustomMediaTypes(this IServiceCollection services)
	{
		services.Configure<MvcOptions>(config =>
		{
			var systemTextJsonOutputFormatter = config.OutputFormatters
					.OfType<SystemTextJsonOutputFormatter>()?.FirstOrDefault();

			if (systemTextJsonOutputFormatter != null)
			{
				systemTextJsonOutputFormatter.SupportedMediaTypes
				.Add("application/vnd.bbinc.hateoas+json");
			}

			var xmlOutputFormatter = config.OutputFormatters
					.OfType<XmlDataContractSerializerOutputFormatter>()?
					.FirstOrDefault();

			if (xmlOutputFormatter != null)
			{
				xmlOutputFormatter.SupportedMediaTypes
				.Add("application/vnd.bbinc.hateoas+xml");
			}
		});
	}
}
#region (c) 2022 Binary Builders Inc. All rights reserved.

// Program.cs
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

using Api;
using Api.Extensions;
using HibernatingRhinos.Profiler.Appender.EntityFramework;
using Interfaces;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;
using NLog;
using Presentation;
using Shared.DataTransferObjects;
using System.Text.Json.Serialization;

#endregion

EntityFrameworkProfilerBootstrapper.PreStart();

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.ConfigureHttpContextAccessor();
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureApiKeyService();
builder.Services.ConfigureSqlContext(builder.Configuration);

// scan assembly for mapping definitions in class MappingProfile 
// https://medium.com/dotnet-hub/use-automapper-in-asp-net-or-asp-net-core-automapper-getting-started-introduction-dotnet-9cdda3db1feb
builder.Services.AddAutoMapper(typeof(Api.Program));

builder.Services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

builder.Services.AddScoped<Presentation.ActionFilters.ValidationFilterAttribute>();
builder.Services.AddScoped<Presentation.ActionFilters.ValidateMediaTypeAttribute>();

builder.Services.AddScoped<IDataShaper<EmployeeDto>, Service.Utility.DataShaper<EmployeeDto>>();
builder.Services.AddScoped<IEmployeeLinks, Service.Utility.EmployeeLinks>();

builder.Services.ConfigureVersioning();

builder.Services.AddControllers(config =>
    {
        config.RespectBrowserAcceptHeader = true;
        config.ReturnHttpNotAcceptable = true;
        config.InputFormatters.Insert(0, GetJsonPatchInputFormatter());
    }).AddXmlDataContractSerializerFormatters()
    .AddCustomCSVFormatter()
    .AddApplicationPart(typeof(AssemblyReference).Assembly)
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); // https://stackoverflow.com/questions/60197270/jsonexception-a-possible-object-cycle-was-detected-which-is-not-supported-this

builder.Services.AddCustomMediaTypes();

var app = builder.Build();

var logger = app.Services.GetRequiredService<Interfaces.ILoggerManager>();
app.ConfigureExceptionHandler(logger);

if (app.Environment.IsProduction())
    app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.UseMiddleware<Presentation.Middleware.ApiKeyMiddleware>();

app.MapControllers();

EntityFrameworkProfiler.Initialize();

app.Run();


NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter()
{
    return new ServiceCollection().AddLogging().AddMvc().AddNewtonsoftJson()
        .Services.BuildServiceProvider()
        .GetRequiredService<IOptions<MvcOptions>>().Value.InputFormatters
        .OfType<NewtonsoftJsonPatchInputFormatter>().First();
}


// used for AutoMapper - see note above
namespace Api
{
    public class Program
    {
    }
}
#region (c) 2022 Binary Builders Inc. All rights reserved.

// ApiKeyMiddleware.cs
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

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Api.Presentation.Middleware;

// http://codingsonata.com/secure-asp-net-core-web-api-using-api-key-authentication/

public class ApiKeyMiddleware
{
    private const string APIKEYNAME = "ApiKey";
    private readonly RequestDelegate _next;

    public ApiKeyMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Api Key was not provided. (Using ApiKeyMiddleware) ");
            return;
        }

        var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();

        var apiKey = appSettings.GetValue<string>(APIKEYNAME);

        if (!apiKey.Equals(extractedApiKey))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Unauthorized client. (Using ApiKeyMiddleware)");
            return;
        }

        await _next(context);
    }
}
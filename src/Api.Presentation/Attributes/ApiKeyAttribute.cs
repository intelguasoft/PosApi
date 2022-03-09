#region (c) 2022 Binary Builders Inc. All rights reserved.

// ApiKeyAttribute.cs
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

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Api.Presentation.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class ApiKeyAttribute : Attribute, IAsyncActionFilter
{
    private const string APIKEYNAME = "ApiKey";

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
        {
            context.Result = new ContentResult
            {
                StatusCode = 401,
                Content = "Api Key was not provided"
            };
            return;
        }

        var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();

        var apiKey = appSettings.GetValue<string>(APIKEYNAME);

        if (!apiKey.Equals(extractedApiKey))
        {
            context.Result = new ContentResult
            {
                StatusCode = 401,
                Content = "Api Key is not valid"
            };
            return;
        }

        await next();
    }
}
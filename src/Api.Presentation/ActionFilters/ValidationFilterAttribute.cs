#region (c) 2022 Binary Builders Inc. All rights reserved.

// ValidationFilterAttribute.cs
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
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

#endregion

namespace Api.Presentation.ActionFilters;

public class ValidationFilterAttribute : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var action = context.RouteData.Values["action"];
        var controller = context.RouteData.Values["controller"];

        var param = context.ActionArguments.SingleOrDefault(x => x.Value!.ToString()!.Contains("Dto")).Value;
        if (param is null)
        {
            context.Result = new BadRequestObjectResult($"Object is null. Controller: {controller}, action: {action}");
            return;
        }

        if (!context.ModelState.IsValid)
            context.Result = new UnprocessableEntityObjectResult(context.ModelState);
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        // todo - remove this line
        if (context.Exception != null)
        {
            var message = $"{context.Exception}{Environment.NewLine}{context.Exception.InnerException}";

            if (!string.IsNullOrEmpty(message))
                context.HttpContext.Response.WriteAsync(message, default);
        }
    }
}
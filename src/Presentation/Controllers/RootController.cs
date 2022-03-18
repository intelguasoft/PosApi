
#region (c) 2022 Binary Builders Inc. All rights reserved.

//-----------------------------------------------------------------------
// <copyright> 
//       File: D:\Dev\Src\GitHub\PointOfSale\PosApi\src\Presentation\Controllers\RootController.cs
//     Author:  
//     Copyright (c) 2022 Binary Builders Inc.. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
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
//-----------------------------------------------------------------------

#endregion

using Entities.LinkModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Presentation.Controllers;

[Route("api")]
[ApiController]
public class RootController : ControllerBase
{
    private readonly LinkGenerator _linkGenerator;

    public RootController(LinkGenerator linkGenerator) => _linkGenerator = linkGenerator;

    [HttpGet(Name = "GetRoot")]
    public IActionResult GetRoot([FromHeader(Name = "Accept")] string mediaType)
    {
        // todo - read this value from appsettings.json
        if (mediaType.Contains("application/vnd.bbinc.apiroot"))
        {
            var list = new List<Link>
                {
                    new Link
                    {
                        Href = _linkGenerator.GetUriByName(HttpContext, nameof(GetRoot), new {}),
                        Rel = "self",
                        Method = "GET"
                    },
                    new Link
                    {
                        Href = _linkGenerator.GetUriByName(HttpContext, "GetCompanies", new {}),
                        Rel = "companies",
                        Method = "GET"
                    },
                    new Link
                    {
                        Href = _linkGenerator.GetUriByName(HttpContext, "CreateCompany", new {}),
                        Rel = "create_company",
                        Method = "POST"
                    }
                };

            return Ok(list);
        }

        return NoContent();
    }
}

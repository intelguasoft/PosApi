
#region (c) 2022 Binary Builders Inc. All rights reserved.

//-----------------------------------------------------------------------
// <copyright> 
//       File: D:\Dev\Src\GitHub\PointOfSale\PosApi\src\Entities\LinkModels\Link.cs
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

namespace Entities.LinkModels;

public class Link
{
    public string? Href { get; set; }
    public string? Rel { get; set; }
    public string? Method { get; set; }

    public Link()
    { }

    public Link(string href, string rel, string method)
    {
        Href = href;
        Rel = rel;
        Method = method;
    }
}

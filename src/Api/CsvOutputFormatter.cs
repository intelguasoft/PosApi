#region (c) 2022 Binary Builders Inc. All rights reserved.

// CsvOutputFormatter.cs
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

using System.Text;
using Api.Shared.DataTransferObjects;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

#endregion

namespace Api;

public class CsvOutputFormatter : TextOutputFormatter
{
    public CsvOutputFormatter()
    {
        SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
        SupportedEncodings.Add(Encoding.UTF8);
        SupportedEncodings.Add(Encoding.Unicode);
    }

    protected override bool CanWriteType(Type? type)
    {
        if (typeof(CompanyDto).IsAssignableFrom(type)
            || typeof(IEnumerable<CompanyDto>).IsAssignableFrom(type))
            return base.CanWriteType(type);

        return false;
    }

    public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context,
        Encoding selectedEncoding)
    {
        var response = context.HttpContext.Response;
        var buffer = new StringBuilder();

        // todo - write unit test for working code below, then add context.Object != null guard clause to prevent null dereference
        // if (context.Object != null)

        if (context.Object is IEnumerable<CompanyDto>)
            foreach (var company in (IEnumerable<CompanyDto>) context.Object)
                FormatCsv(buffer, company);
        else
            FormatCsv(buffer, (CompanyDto) context.Object);

        await response.WriteAsync(buffer.ToString(), cancellationToken: default).ConfigureAwait(false);
    }

    private static void FormatCsv(StringBuilder buffer, CompanyDto company)
    {
        buffer.AppendLine($"{company.CompanyId},\"{company.Name},\"{company.FullAddress}\"");
    }
}
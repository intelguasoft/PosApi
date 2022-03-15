using Shared.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Parameters
{
    public class CompanyRequestParameters : PagingBase
    {
        public string? SearchTerm { get; set; }
    }
}

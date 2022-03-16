using Entities;
using System;
using System.Linq;

namespace Shared.DataTransferObjects
{
    public class CompanyJoinEmployeeDto
    {
        public Company_Company? Company { get; init; }
        public Employee_Employee? Employee { get; init; }
    }
}

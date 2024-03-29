﻿#region (c) 2022 Binary Builders Inc. All rights reserved.

// MappingProfile.cs
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

using AutoMapper;
using Entities;
using Shared.DataTransferObjects;

#endregion

namespace Api;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Company_Company, CompanyDto>()
            .ForMember(c => c.FullAddress,
                opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));

        CreateMap<Employee_Employee, EmployeeDto>();

        CreateMap<CompanyForCreationDto, Company_Company>();

        CreateMap<EmployeeForCreationDto, Employee_Employee>();

        CreateMap<EmployeeForUpdateDto, Employee_Employee>();

        CreateMap<CompanyForUpdateDto, Company_Company>();

        CreateMap<CompanyJoinEmployeeDto, Company_Company>();

        CreateMap<EmployeeForUpdateDto, Employee_Employee>().ReverseMap();

        CreateMap<CompanyForUpdateDto, Company_Company>().ReverseMap();
    }
}
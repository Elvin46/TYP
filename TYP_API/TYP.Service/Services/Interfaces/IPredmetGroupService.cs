﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Core.Entities;
using TYP.Service.DTOs.PredmetGroupDTOs;

namespace TYP.Service.Services.Interfaces
{
    public interface IPredmetGroupService
    {
        Task SetCourseAsync();
        Task<List<PredmetGroupOutDepartmentDTO>> OutDepartment(int departmentId);
        Task<List<PredmetGroupOutDepartmentDTO>> IntoDepartment(int departmentId);
    }
}

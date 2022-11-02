﻿using School.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Service.Interfaces
{
    public interface IClassService
    {
        Task<IList<ClassViewModel>> WhereAsync();
    }
}

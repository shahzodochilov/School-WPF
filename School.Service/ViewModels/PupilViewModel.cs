﻿using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Service.ViewModels
{
    public class PupilViewModel : Person
    {
        public string ClassName { get; set; } = string.Empty;
    }
}

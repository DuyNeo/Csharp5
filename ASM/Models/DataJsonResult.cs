﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Models
{
    public class DataJsonResult
    {
        public string Message { get; set; }

        public bool IsSuccess { get; set; }

        public object Data { get; set; }
    }
}

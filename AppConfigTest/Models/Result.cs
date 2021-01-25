﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppConfigTest.Models
{
    public class Result
    {
        public string Controller { get; set; }
        public string Action { get; set; }

        public Dictionary<string, object> Data { get; } = new Dictionary<string, object>();
    }
}

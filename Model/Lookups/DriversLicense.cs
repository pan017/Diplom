﻿using Diplom.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Model.Lookups
{
    public class DriversLicense :BaseLookup
    {
        public string Category { get; set; }
        public DateTime GettingDate { get; set; }

    }
}

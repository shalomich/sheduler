﻿using Sheduler.RestApi.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.RestApi.Model.Requests
{
    public class RemoteWorkRequest : Request
    {
        public override string Type => "На удаленную работу";
        
        public string WorkingPlan { set; get; }
    }
}

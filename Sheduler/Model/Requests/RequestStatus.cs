﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.Model.Requests
{
    public enum RequestStatus
    {
        Created,
        Sent,
        Approved,
        Disapproved,
        Allowed,
        Disallowed,
        Withdrawn,
        Cancelled
    }
}

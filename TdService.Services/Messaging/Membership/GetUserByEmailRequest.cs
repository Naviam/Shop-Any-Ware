﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TdService.Services.Messaging.Membership
{
    public class GetUserByEmailRequest:RequestBase
    {
        public string Email { get; set; }
    }
}

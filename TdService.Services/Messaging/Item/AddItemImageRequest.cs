﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TdService.Services.Messaging.Item
{
    public class AddItemImageRequest:RequestBase
    {
        public int ItemId { get; set; }
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
    }
}
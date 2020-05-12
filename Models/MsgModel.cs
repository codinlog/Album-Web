using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Album_Web.Models
{
    public class MsgModel
    {
        public string ChannelId { get; set; }
        public string ChannelName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string SmallIcon { get; set; }
        public bool AutoCancel { get; set; }
    }
}

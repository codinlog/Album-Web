using System;
using System.Threading.Tasks;

using Album_Web.Models;

using Microsoft.AspNetCore.SignalR;

using Newtonsoft.Json;

namespace Album_Web.Hubs
{
    public interface IPushHub
    {
        public void PushMsg(String msg);
    }

    public class PushHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            string msg = JsonConvert.SerializeObject(new MsgModel
            {
                ChannelId = "codinlog",
                ChannelName = "codinlog",
                Title = "连接成功",
                Content = "成功与服务器建立连接",
                SmallIcon = null,
                AutoCancel = true
            });
            Clients.All.SendAsync("pushMsg", msg);
            return base.OnConnectedAsync();
        }

        public void PushMsg(MsgModel msgModel)
        {
            string msg = JsonConvert.SerializeObject(msgModel);
            Clients.All.SendAsync("pushMsg", msg);
        }
    }
}
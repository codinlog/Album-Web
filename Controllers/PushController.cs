using Album_Web.Hubs;
using Album_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Album_Web.Controllers
{
    [Route("push")]
    //[Route("[controller]/[action]")]
    public class PushController : Controller
    {
        private readonly IHubContext<PushHub> pushHub;
        private readonly ILogger<PushController> logger;

        public PushController(IHubContext<PushHub> pushHub, ILogger<PushController> logger)
        {
            this.pushHub = pushHub;
            this.logger = logger;
        }

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("pushMsg")]
        public IActionResult PushMsg(MsgModel msgModel)
        {
            string msg = JsonConvert.SerializeObject(msgModel);
            pushHub.Clients.All.SendAsync("pushMsg", msg);
            return RedirectToAction(nameof(Index));
        }

        [Route("testMsg")]
        public IActionResult TestMsg()
        {
            return Ok(nameof(TestMsg));
        }
    }
}
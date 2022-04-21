using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using WeTalk.Services;

namespace WeTalk.WebMVC.Controllers
{
    public class MessageController : Controller
    {
        public MessageService CreateMessageService()
        {
            return new MessageService(User.Identity.GetUserId());
        }
        // GET: Message
        public ActionResult Index()
        {
            return View();
        }

        //message create
        public ActionResult Create()
        {
            return View();
        }

       
    }
}
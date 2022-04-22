using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using WeTalk.Models.MessageModels;
using WeTalk.Services;

namespace WeTalk.WebMVC.Controllers
{
    [Authorize]
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MessageCreate model)
        {
            if (ModelState.IsValid)
            {
                var service = CreateMessageService();
                if (service.CreateAMessage(model))
                {
                    ViewData["SaveResult"] = "Your Message has been sent";
                    return RedirectToAction("Index", "Conversation");
                }
                ViewData["SaveResult"] = "Sorry, this message could not be sent";
            }
            ViewData["SaveResult"] = "Invalid Model State";
            return View(model);
        }

        //message edit

        //message delete
    }
}
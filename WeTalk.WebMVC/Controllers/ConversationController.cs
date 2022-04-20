using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;
using WeTalk.Models.ConversationModels;
using WeTalk.Services;

namespace WeTalk.WebMVC.Controllers
{
    [Authorize]
    public class ConversationController : Controller
    {
        public ConversationService CreateConversationService()
        {
            return new ConversationService(User.Identity.GetUserId());
        }

        // GET: Conversation
        public ActionResult Index()
        {
            var service = CreateConversationService();
            var model = service.GetAllConversations();
            return View(model);
        }

        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConversationCreate model)
        {
            if (!ModelState.IsValid)
            {
                var service = CreateConversationService();
                if (service.CreateConversation(model))
                {
                    ViewData["SaveResult"] = "A new conversation has been created";
                        return RedirectToAction("Index");
                }
                ViewData["SaveResult"] = "This conversation could not be created or the conversation already exists";
            }
            ViewData["SaveResult"] = "Invalid Model State";
            return View(model);
        }
    }
}
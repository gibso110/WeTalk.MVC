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

        //Get Conversation by Id

        public ActionResult Details(int id)
        {
            var service = CreateConversationService();
            var model = service.GetConversationById(id);

            return View(model);
        }

        //Delete Conversation



        //message delete
        public ActionResult Delete(int id)
        {
            var service = CreateConversationService();
            var model = service.GetConversationById(id);

            if (model != null)
            {
                return View(model);
            }
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteRequest(int id)
        {
            var service = CreateConversationService();
            if (service.DeleteAConversation(id))
            {
                TempData["SaveResult"] = "The conversation has been deleted.";
            }
            else
            {
                TempData["SaveResult"] = "The conversation could not be deleted";
            }
            return RedirectToAction("Index", "Conversation");
        }

        //Conversation edit
        public ActionResult Edit(int id)
        {
            var service = CreateConversationService();
            var request = service.GetConversationById(id);
            var model = new ConversationDetail
            {
                Username1 = request.Username1,
                Username2 = request.Username2,
                UserMessages = request.UserMessages,
                

            };
            if (model != null)
            {
                return View(model);
            }
            return HttpNotFound();
        }

        
    }
}
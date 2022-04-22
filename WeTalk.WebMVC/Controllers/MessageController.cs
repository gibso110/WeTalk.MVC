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
        public ActionResult Edit(int id)
        {
            var service = CreateMessageService();
            var model = service.GetMessageById(id);

            if (model != null)
            {
                return View(model);
            }
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public ActionResult EditRequest(MessageEdit model)
        {
            var service = CreateMessageService();
            if (service.EditAMessage(model))
            {
                TempData["SaveResult"] = "The message has been edited.";
            }
            else
            {
                TempData["SaveResult"] = "The message could not be edited";
            }
            return RedirectToAction("Index", "Conversation");
        }

        //message delete
        public ActionResult Delete(int id)
        {
            var service = CreateMessageService();
            var model = service.GetMessageById(id);

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
            var service = CreateMessageService();
            if (service.DeleteAMessage(id))
            {
                TempData["SaveResult"] = "The message has been deleted.";
            }
            else
            {
                TempData["SaveResult"] = "The message could not be deleted";
            }
            return RedirectToAction("Index","Conversation");
        }
    }
}
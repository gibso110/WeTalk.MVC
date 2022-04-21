using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using WeTalk.Models.FriendRequestModels;
using WeTalk.Services;

namespace WeTalk.WebMVC.Controllers
{
    [Authorize]
    public class FriendRequestController : Controller
    {
        public FriendRequestService CreateFriendRequestService()
        {
            return new FriendRequestService(User.Identity.GetUserId());
        }

        // GET: FriendRequest
        public ActionResult Index()
        {
            var service = CreateFriendRequestService();
            var model = service.GetAllFriendRequests();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FriendRequestCreate model)
        {
            if (ModelState.IsValid)
            {
                var service = CreateFriendRequestService();
                if (service.CreateFriendRequest(model))
                {
                    ViewData["SaveResult"] = "A new friend request has been sent";
                    return RedirectToAction("Index");
                }
                ViewData["SaveResult"] = "This conversation could not be created or the conversation already exists";
            }
            ViewData["SaveResult"] = "Invalid Model State";
            return View(model);
        }
        
        
        public ActionResult Delete(int id)
        {
            var service = CreateFriendRequestService();
            var model = service.GetFriendRequestById(id);

            if(model != null)
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
            var service = CreateFriendRequestService();
            if (service.deleteFriendRequest(id))
            {
                ViewData["SaveResult"] = "The friend request has been deleted.";
            }
            else
            {
                ViewData["SaveResult"] = "The friend request could not be deleted";
            }
            return Redirect("Index");
        }

        public ActionResult Edit (int id)
        {
            var service = CreateFriendRequestService();
            var request = service.RequestEditView(id);
            var model = new RequestEditDetail
            {
                RequestId = request.RequestId,
                IsAccepted = request.IsAccepted,
                IsBlocked = request.IsBlocked,
                User2Id = request.User2Id,
            };
            if(model != null)
            {
                return View(model);
            }
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RequestEditDetail model)
        {
            model.RequestId = id;
            if(!ModelState.IsValid) return View(model);

            if(model.RequestId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateFriendRequestService();

            if (service.EditFriendRequest(model))
            {
                TempData["SaveResult"] = "The friend request was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The friend request could not be updated.");
            return View(model);
        }

       
    }
}
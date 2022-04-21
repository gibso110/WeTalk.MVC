using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using WeTalk.Services;

namespace WeTalk.WebMVC.Controllers
{
    public class FriendController : Controller
    {
        public FriendService CreateFriendService()
        {
            return new FriendService(User.Identity.GetUserId());

        }

        // GET: Friend
        public ActionResult Index()
        {
            var service = CreateFriendService();
            var model = service.GetAllFriends();
            return View(model);
        }

        //Delete Friend

        public ActionResult Delete(int id)
        {
            var service = CreateFriendService();
            var model = service.GetFriendById(id);

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
            var service = CreateFriendService();
            if (service.FriendDelete(id))
            {
                ViewData["SaveResult"] = "The friend has been deleted.";
            }
            else
            {
                ViewData["SaveResult"] = "The friend could not be deleted";
            }
            return Redirect("Index");
        }


    }
}
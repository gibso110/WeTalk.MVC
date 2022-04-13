using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeTalk.Data;
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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineLMS.Service;

namespace SessionProject.Controllers
{
    public class LoginUserController : Controller
    {
        OnlineLMS context;
        //ctor + double tabb
        public LoginUserController()
        {
            context = new OnlineLMS();
        }
        // GET: LoginUser
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Models.LoginUserModel model)
        {
            var data = context.UserLogins.FirstOrDefault(a => a.UserName == model.Username && a.UserPassword == model.UserPassword);
            if (data != null)
            {
                Session["SessionModel"] = model;
                return View("Display");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid UserName and Password";
                return View();
            }
        }
        public ActionResult Display()
        {
            if (Session["SessionModel"] == null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
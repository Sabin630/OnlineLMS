using OnlineLMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineLMS.Controllers
{
    public class MemberController : Controller
    {
        MemberService member;
        public MemberController()
        {
            member = new MemberService();
        }
        // GET: Member
        public ActionResult Index()
        {
            var data = member.DisplayData();
            return View(data);

        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            member.DeleteData(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddData()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddData(Models.MemberModel memberModel)
        {
            member.SaveData(memberModel);
            var data = member.DisplayData();
            return View("Index", data);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = member.GetData(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(Models.MemberModel model)
        {
            member.UpdateData(model);
            var dataList = member.DisplayData();
            return View("Index", dataList);
        }
    }
}
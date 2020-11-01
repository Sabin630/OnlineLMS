using OnlineLMS.Models;
using OnlineLMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineLMS.Controllers
{
    public class MemberCategoryController : Controller
    {
        MemberCategoryService memberCategories;
        public MemberCategoryController()
        {
            memberCategories = new MemberCategoryService();
        }
        // GET: MemberCategory
        public ActionResult Index()
        {
            var data = memberCategories.DisplayData();
            return View(data);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            memberCategories.DeleteData(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddData()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveData(MemberCategoryModel memberCategoryModel)
        {
            memberCategories.SaveData(memberCategoryModel);
            var data = memberCategories.DisplayData();
            return View("Index", data);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = memberCategories.GetData(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(MemberCategoryModel memberCategoryModel)
        {
            memberCategories.UpdateData(memberCategoryModel);
            var dataList = memberCategories.DisplayData();
            return View("Index", dataList);
        }

    }
}
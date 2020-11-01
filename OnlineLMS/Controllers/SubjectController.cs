using OnlineLMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineLMS.Controllers
{
    public class SubjectController : Controller
    {
        SubjectService subservice;
        public SubjectController()
        {
            subservice = new SubjectService();
        }
        // GET: Subject
        public ActionResult Index()
        {
            var data = subservice.DisplayData();
            return View(data);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            subservice.DeleteData(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddData()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddData(Models.SubjectModel subser)
        {
            subservice.SaveData(subser);
            var data = subservice.DisplayData();
            return View("Index", data);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = subservice.GetData(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(Models.SubjectModel subser)
        {
            subservice.UpdateData(subser);
            var dataList = subservice.DisplayData();
            return View("Index", dataList);
        }
    }
}
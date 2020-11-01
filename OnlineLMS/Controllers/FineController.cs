using OnlineLMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineLMS.Controllers
{
    public class FineController : Controller
    {
        FineService fine;
        public FineController()
        {
            fine = new FineService();
        }
        // GET: Fine
        public ActionResult Index()
        {
            var data = fine.DisplayData();
            return View(data); 
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            fine.DeleteData(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddData()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddData(Models.FineModel authorModel)
        {
            fine.SaveData(authorModel);
            var data = fine.DisplayData();
            return View("Index", data);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = fine.GetData(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(Models.FineModel model)
        {
            fine.UpdateData(model);
            var dataList = fine.DisplayData();
            return View("Index", dataList);
        }
    }
}
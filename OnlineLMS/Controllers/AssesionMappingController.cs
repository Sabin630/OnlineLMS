using OnlineLMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineLMS.Controllers
{
    public class AssesionMappingController : Controller
    {
        AssesionMappingService assessionmap;
        public AssesionMappingController()
        {
            assessionmap = new AssesionMappingService();
        }
        // GET: AssesionMapping
        public ActionResult Index()
        {
            var data = assessionmap.DisplayData();
            return View(data);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            assessionmap.DeleteData(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddData()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddData(Models.AssesionMappingModel assessionmapping)
        {
            assessionmap.SaveData(assessionmapping);
            var data = assessionmap.DisplayData();
            return View("Index", data);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = assessionmap.GetData(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(Models.AssesionMappingModel asmodel)
        {
            assessionmap.UpdateData(asmodel);
            var dataList = assessionmap.DisplayData();
            return View("Index", dataList);
        }
    }
}
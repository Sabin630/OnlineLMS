using OnlineLMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineLMS.Controllers
{
    public class AuthorController : Controller
    {
        AuthorService authors;
        public AuthorController()
        {
            authors = new AuthorService();
        }
        // GET: Author
        public ActionResult Index()
        {
            var data = authors.DisplayData();
            return View(data);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            authors.DeleteData(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddData()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddData(Models.AuthorModel authorModel)
        {
            authors.SaveData(authorModel);
            var data = authors.DisplayData();
            return View("Index", data);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = authors.GetData(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(Models.AuthorModel model)
        {
            authors.UpdateData(model);
            var dataList = authors.DisplayData();
            return View("Index", dataList);
        }
    }
}
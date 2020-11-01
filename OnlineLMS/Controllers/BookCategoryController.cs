using OnlineLMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineLMS.Controllers
{
    public class BookCategoryController : Controller
    {
        BookCategoryService bookCategory;
        public BookCategoryController()
        {
            bookCategory = new BookCategoryService();
        }
        // GET: BookCategory
        public ActionResult Index()
        {
            var data = bookCategory.DisplayData();
            return View(data);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            bookCategory.DeleteData(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddData()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddData(Models.BookCategoryModel bookcategory)
        {
            bookCategory.SaveData(bookcategory);
            var data = bookCategory.DisplayData();
            return View("Index", data);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = bookCategory.GetData(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(Models.BookCategoryModel bcmodel)
        {
            bookCategory.UpdateData(bcmodel);
            var dataList = bookCategory.DisplayData();
            return View("Index", dataList);
        }
    }
}
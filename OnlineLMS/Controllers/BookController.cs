using OnlineLMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineLMS.Controllers
{
    public class BookController : Controller
    {
        BookService book;
        public BookController()
        {
            book = new BookService();
        }

        // GET: Book
        public ActionResult Index()
        {
            var data = book.DisplayData();
            return View(data);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            book.DeleteData(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddData()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddData(Models.BookModel books)
        {
            book.SaveData(books);
            var data = book.DisplayData();
            return View("Index", data);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = book.GetData(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(Models.BookModel bmodel)
        {
            book.UpdateData(bmodel);
            var dataList = book.DisplayData();
            return View("Index", dataList);
        }
    }
}
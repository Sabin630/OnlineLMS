using OnlineLMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineLMS.Controllers
{
    public class BookIssueRetController : Controller
    {
        BookIssueRetService bookIssueRet;
        public BookIssueRetController()
        {
            bookIssueRet = new BookIssueRetService();
        }
        // GET: BookIssueRet
        public ActionResult Index()
        {
            var data = bookIssueRet.DisplayData();
            return View(data);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            bookIssueRet.DeleteData(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddData()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddData(Models.BookIssueRetModel bookIssueRetModel)
        {
             bookIssueRet.SaveData(bookIssueRetModel);
            var data = bookIssueRet.DisplayData();
            return View("Index", data);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result =  bookIssueRet.GetData(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(Models.BookIssueRetModel bicmodel)
        {
            bookIssueRet.UpdateData(bicmodel);
            var dataList = bookIssueRet.DisplayData();
            return View("Index", dataList);
        }
    }
}
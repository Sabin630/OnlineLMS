using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLMS.Service
{
    public class BookCategoryService
    {
        LMSDBEntities context;
        public BookCategoryService()
        {
            context = new LMSDBEntities();
        }
        public List<Models.BookCategoryModel> DisplayData()
        {
            try
            {
                var data = context.BookCategories.Select(a => new Models.BookCategoryModel()
                {
                    BookCategoryID = a.BookCategoryID,
                    BookCategoryName = a.BookCategoryName,
                    Description = a.Description
                }).ToList();
                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        public void SaveData(Models.BookCategoryModel bookCategoryModel)
        {
            var data = new BookCategory()
            {
                BookCategoryID = bookCategoryModel.BookCategoryID,
                BookCategoryName = bookCategoryModel.BookCategoryName,
                Description = bookCategoryModel.Description,
            };
            context.BookCategories.Add(data);
            context.SaveChanges();
        }
        public void UpdateData(Models.BookCategoryModel model)
        {
            try
            {
                BookCategory data = new BookCategory();
                data = context.BookCategories.
                    Where(a => a.BookCategoryID == model.BookCategoryID).FirstOrDefault();
                data.BookCategoryName = model.BookCategoryName;
                data.Description = model.Description;
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void DeleteData(int id)
        {
            try
            {
                BookCategory data = new BookCategory();
                data = context.BookCategories.
                    Where(a => a.BookCategoryID == id).FirstOrDefault();
                context.BookCategories.Remove(data);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Models.BookCategoryModel GetData(int id)
        {
            try
            {
                var data = context.BookCategories.Where(a => a.BookCategoryID == id).Select(a => new Models.BookCategoryModel()
                {
                    BookCategoryID = a.BookCategoryID,
                    BookCategoryName = a.BookCategoryName,
                    Description = a.Description
                }).FirstOrDefault();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
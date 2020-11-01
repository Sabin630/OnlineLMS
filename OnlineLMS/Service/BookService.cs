using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLMS.Service
{
    public class BookService
    {
        LMSDBEntities context;
        public BookService()
        {
            context = new LMSDBEntities();
        }
        public List<Models.BookModel> DisplayData()
        {
            try
            {
                var data = context.Books.Select(a => new Models.BookModel()
                {
                    BookID = a.BookID,
                    BookName = a.BookName,
                    BookCategoryID = a.BookCategoryID,
                    AuthorID = a.AuthorID,
                    SubjectID = a.SubjectID,
                    Remarks = a.Remarks
                }).ToList();
                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        public void SaveData(Models.BookModel bookModel)
        {
            var data = new Book()
            {
                BookID = bookModel.BookID,
                BookName = bookModel.BookName,
                BookCategoryID = bookModel.BookCategoryID,
                AuthorID = bookModel.AuthorID,
                SubjectID = bookModel.SubjectID,
                Remarks = bookModel.Remarks
            };
            context.Books.Add(data);
            context.SaveChanges();
        }
        public void UpdateData(Models.BookModel model)
        {
            try
            {
                Book data = new Book();
                data = context.Books.
                    Where(a => a.BookID == model.BookID).FirstOrDefault();
                data.BookName = model.BookName;
                data.BookCategoryID = model.BookCategoryID;
                data.AuthorID = model.AuthorID;
                data.SubjectID = model.SubjectID;
                data.Remarks = model.Remarks;
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
                Book data = new Book();
                data = context.Books.
                    Where(a => a.BookID == id).FirstOrDefault();
                context.Books.Remove(data);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Models.BookModel GetData(int id)
        {
            try
            {
                var data = context.Books.Where(a => a.BookID == id).Select(a => new Models.BookModel()
                {
                    BookID = a.BookID,
                    BookName = a.BookName,
                    BookCategoryID = a.BookCategoryID,
                    AuthorID = a.AuthorID,
                    SubjectID = a.SubjectID,
                    Remarks = a.Remarks
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
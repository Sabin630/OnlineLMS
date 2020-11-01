using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLMS.Service
{
    public class BookIssueRetService
    {
        LMSDBEntities context;
        public BookIssueRetService()
        {
            context = new LMSDBEntities();
        }
        public List<Models.BookIssueRetModel> DisplayData()
        {
            try
            {
                var data = context.BookIssueRets.Select(a => new Models.BookIssueRetModel()
                {
                    BookIssueReturnID = a.BookIssueReturnID,
                    MemberID = a.MemberID,
                    AssesionID = a.AssesionID,
                    IssueDate = a.IssueDate,
                    DueDate = a.DueDate,
                    ReturnDate = a.ReturnDate,
                    FineAmount = a.FineAmount,
                    Status = a.Status,
                    StaffMemberID = a.StaffMemberID,
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
        public void SaveData(Models.BookIssueRetModel bookIssueRetModel)
        {
            var data = new BookIssueRet()
            {
                BookIssueReturnID = bookIssueRetModel.BookIssueReturnID,
                MemberID = bookIssueRetModel.MemberID,
                AssesionID = bookIssueRetModel.AssesionID,
                IssueDate = bookIssueRetModel.IssueDate,
                DueDate = bookIssueRetModel.DueDate,
                ReturnDate = bookIssueRetModel.ReturnDate,
                FineAmount = bookIssueRetModel.FineAmount,
                Status = bookIssueRetModel.Status,
                StaffMemberID = bookIssueRetModel.StaffMemberID,
                Remarks = bookIssueRetModel.Remarks
            };
            context.BookIssueRets.Add(data);
            context.SaveChanges();
        }
        public void UpdateData(Models.BookIssueRetModel model)
        {
            try
            {
                BookIssueRet data = new BookIssueRet();
                data = context.BookIssueRets.
                    Where(a => a.BookIssueReturnID == model.BookIssueReturnID).FirstOrDefault();
                data.MemberID = model.MemberID;
                data.AssesionID = model.AssesionID;
                data.IssueDate = model.IssueDate;
                data.DueDate = model.DueDate;
                data.ReturnDate = model.ReturnDate;
                data.FineAmount = model.FineAmount;
                data.Status = model.Status;
                data.StaffMemberID = model.StaffMemberID;
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
                BookIssueRet data = new BookIssueRet();
                data = context.BookIssueRets.
                    Where(a => a.BookIssueReturnID == id).FirstOrDefault();
                context.BookIssueRets.Remove(data);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Models.BookIssueRetModel GetData(int id)
        {
            try
            {
                var data = context.BookIssueRets.Where(a => a.BookIssueReturnID == id).Select(a => new Models.BookIssueRetModel()
                {
                    BookIssueReturnID = a.BookIssueReturnID,
                    MemberID = a.MemberID,
                    AssesionID = a.AssesionID,
                    IssueDate = a.IssueDate,
                    DueDate = a.DueDate,
                    ReturnDate = a.ReturnDate,
                    FineAmount = a.FineAmount,
                    Status = a.Status,
                    StaffMemberID = a.StaffMemberID,
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
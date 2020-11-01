using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLMS.Service
{
    public class MemberService
    {
        LMSDBEntities context;
        public MemberService()
        {
            context = new LMSDBEntities();
        }
        public List<Models.MemberModel> DisplayData()
        {
            try
            {
                var data = context.Members.Select(a => new Models.MemberModel()
                {
                    MemberID = a.MemberID,
                    MemberName = a.MemberName,
                    StaffMemberID = a.StaffMemberID,
                    MemberAddress = a.MemberAddress,
                    ContactNo = a.ContactNo,
                    EmailAddress = a.EmailAddress,
                    UserName = a.UserName,
                    Password = a.Password,
                    Status = a.Status
                }).ToList();
                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        public void SaveData(Models.MemberModel memberModel)
        {
            var data = new Member()
            {
                MemberID = memberModel.MemberID,
                MemberName = memberModel.MemberName,
                StaffMemberID = memberModel.StaffMemberID,
                MemberAddress = memberModel.MemberAddress,
                ContactNo = memberModel.ContactNo,
                EmailAddress = memberModel.EmailAddress,
                UserName = memberModel.UserName,
                Password = memberModel.Password,
                Status = memberModel.Status
            };
            context.Members.Add(data);
            context.SaveChanges();
        }
        public void UpdateData(Models.MemberModel model)
        {
            try
            {
                Member data = new Member();
                data = context.Members.
                    Where(a => a.MemberID == model.MemberID).FirstOrDefault();
                data.MemberID = model.MemberID;
                data.MemberName = model.MemberName;
                data.StaffMemberID = model.StaffMemberID;
                data.MemberAddress = model.MemberAddress;
                data.ContactNo = model.ContactNo;
                data.EmailAddress = model.EmailAddress;
                data.UserName = model.UserName;
                data.Password = model.Password;
                data.Status = model.Status;
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
                Member data = new Member();
                data = context.Members.
                    Where(a => a.MemberID == id).FirstOrDefault();
                context.Members.Remove(data);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Models.MemberModel GetData(int id)
        {
            try
            {
                var data = context.Members.Where(a => a.MemberID == id).Select(a => new Models.MemberModel()
                {
                    MemberID = a.MemberID,
                    MemberName = a.MemberName,
                    StaffMemberID = a.StaffMemberID,
                    MemberAddress = a.MemberAddress,
                    ContactNo = a.ContactNo,
                    EmailAddress = a.EmailAddress,
                    UserName = a.UserName,
                    Password = a.Password,
                    Status = a.Status
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLMS.Service
{
    public class MemberCategoryService
    {
        LMSDBEntities context;
        public MemberCategoryService()
        {
            context = new LMSDBEntities();
        }
        public List<Models.MemberCategoryModel> DisplayData()
        {
            try
            {
                var data = context.MemberCategories.Select(a => new Models.MemberCategoryModel()
                {
                    StaffMemberID = a.StaffMemberID,
                    MemberCategoryName = a.MemberCategoryName,
                    Remarks = a.Remarks
                }).ToList();
                return data;
            }
            catch(Exception)
            {
                return null;
                throw;
            }
        }
        public void SaveData(Models.MemberCategoryModel memberCategoryModel)
        {
            var data = new MemberCategory()
            {
                StaffMemberID = memberCategoryModel.StaffMemberID,
                MemberCategoryName = memberCategoryModel.MemberCategoryName,
                Remarks = memberCategoryModel.Remarks
            };
            context.MemberCategories.Add(data);
            context.SaveChanges();
        }
            
        public void UpdateData(Models.MemberCategoryModel model)
        {
            try
            {
                MemberCategory data = new MemberCategory();
                data = context.MemberCategories.
                    Where(a => a.StaffMemberID == model.StaffMemberID).FirstOrDefault();
                data.MemberCategoryName = model.MemberCategoryName;
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
                MemberCategory data = new MemberCategory();
                data = context.MemberCategories.
                    Where(a => a.StaffMemberID == id).FirstOrDefault();
                context.MemberCategories.Remove(data);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Models.MemberCategoryModel GetData(int id)
        {
            try
            {
                var data = context.MemberCategories.Where(a => a.StaffMemberID == id).Select(a => new Models.MemberCategoryModel()
                {
                    StaffMemberID = a.StaffMemberID,
                    MemberCategoryName = a.MemberCategoryName,
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
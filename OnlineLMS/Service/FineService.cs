using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLMS.Service
{
    public class FineService
    {
        LMSDBEntities context;
        public FineService()
        {
            context = new LMSDBEntities();
        }
        public List<Models.FineModel> DisplayData()
        {
            try
            {
                var data = context.Fines.Select(a => new Models.FineModel()
                {
                    FineID = a.FineID,
                    LateDays = a.LateDays,
                    StaffMemberID = a.StaffMemberID,
                    Amount = a.Amount,
                    Remarks = a.Remarks,
                }).ToList();
                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        public void SaveData(Models.FineModel fineModel)
        {
            var data = new Fine()
            {
                FineID = fineModel.FineID,
                LateDays = fineModel.LateDays,
                StaffMemberID = fineModel.StaffMemberID,
                Amount = fineModel.Amount,
                Remarks = fineModel.Remarks,
            };
            context.Fines.Add(data);
            context.SaveChanges();
        }
        public void UpdateData(Models.FineModel model)
        {
            try
            {
                Fine data = new Fine();
                data = context.Fines.
                    Where(a => a.FineID == model.FineID).FirstOrDefault();
                data.LateDays = model.LateDays;
                data.StaffMemberID = model.StaffMemberID;
                data.Amount = model.Amount;
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
                Fine data = new Fine();
                data = context.Fines.
                    Where(a => a.FineID == id).FirstOrDefault();
                context.Fines.Remove(data);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Models.FineModel GetData(int id)
        {
            try
            {
                var data = context.Fines.Where(a => a.FineID == id).Select(a => new Models.FineModel()
                {
                    FineID = a.FineID,
                    LateDays = a.LateDays,
                    StaffMemberID = a.StaffMemberID,
                    Amount = a.Amount,
                    Remarks = a.Remarks,
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
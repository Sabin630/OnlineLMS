using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLMS.Service
{
    public class AssesionMappingService
    {
        LMSDBEntities context;
        public AssesionMappingService()
        {
            context = new LMSDBEntities();
        }
        public List<Models.AssesionMappingModel> DisplayData()
        {
            try
            {
                var data = context.AssesionMappings.Select(a => new Models.AssesionMappingModel()
                {
                    AssesionID = a.AssesionID,
                    BookID = a.BookID,
                    Status = a.Status,
                }).ToList();
                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public void SaveData(Models.AssesionMappingModel assesionMappingModel)
        {
            var data = new AssesionMapping()
            {
                AssesionID = assesionMappingModel.AssesionID,
                BookID = assesionMappingModel.BookID,
                Status = assesionMappingModel.Status,
            };
            context.AssesionMappings.Add(data);
            context.SaveChanges();
        }
        public void UpdateData(Models.AssesionMappingModel model)
        {
            try
            {
                AssesionMapping data = new AssesionMapping();
                data = context.AssesionMappings.
                    Where(a => a.AssesionID == model.AssesionID).FirstOrDefault();
                data.BookID = model.BookID;
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
                AssesionMapping data = new AssesionMapping();
                data = context.AssesionMappings.
                    Where(a => a.AssesionID == id).FirstOrDefault();
                context.AssesionMappings.Remove(data);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Models.AssesionMappingModel GetData(int id)
        {
            try
            {
                var data = context.AssesionMappings.Where(a => a.AssesionID == id).Select(a => new Models.AssesionMappingModel()
                {
                    AssesionID = a.AssesionID,
                    BookID = a.BookID,
                    Status = a.Status,
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIFALIBITKILERMVC.Models.Entity;
namespace SIFALIBITKILERMVC.Controllers.Admin
{
    public class DeletePlantController : Controller
    {
        // GET: DeletePlant
        [HttpPost]
        public JsonResult DeletePlantIndex(int id = 0)
        {
            using (MedicinalPlantsEntities db = new MedicinalPlantsEntities())
            {
                var find = db.Plants.Find(id);
                db.Plants.Remove(find);
                db.SaveChanges();


            }
            return Json(new { response = "successDeleted" }, JsonRequestBehavior.AllowGet);
        }
    }
}
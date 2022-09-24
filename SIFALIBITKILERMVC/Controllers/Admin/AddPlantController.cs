using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using SIFALIBITKILERMVC.Models.Entity;
namespace SIFALIBITKILERMVC.Controllers.Admin
{

    public class AddPlantController : Controller
    {
        [HttpGet]
        public ActionResult AddPlantIndex()
        {
            return View();
        }





        [HttpPost]
        public JsonResult AddPlantIndex(Plants plants)
        {
            using (MedicinalPlantsEntities db = new MedicinalPlantsEntities())
            {
                if (Request.Files.Count > 0)
                {
                    Request.Files[0].SaveAs(Server.MapPath("/PlantsPhoto/" + plants.PlantImage));
                    plants.PlantImage = "/PlantsPhoto/" + plants.PlantImage;
                    db.Plants.Add(plants);
                    db.SaveChanges();
                }
            }

            return Json(new { response = "successAdded", JsonRequestBehavior.AllowGet });
        }
    }
}



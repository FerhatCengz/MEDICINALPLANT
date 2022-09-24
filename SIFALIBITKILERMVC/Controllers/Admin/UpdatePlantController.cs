using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIFALIBITKILERMVC.Models.Entity;

namespace SIFALIBITKILERMVC.Controllers.Admin
{
    public class UpdatePlantController : Controller
    {
        // GET: UpdatePlant
        [HttpGet]
        public ActionResult UpdatePlantIndex(int id = 0)
        {
            if (id > 0)
            {
                using (MedicinalPlantsEntities db = new MedicinalPlantsEntities())
                {
                    //Gelen İdnin ilk değerine göre verileri çekiyorum
                    var query = db.Plants.FirstOrDefault(x => x.ID == id);

                    //Ön tarafta bulunan gelen idyi karşılıyacak bitki fotoğrafını alıyorum.
                    string getPlantImage = db.Plants.FirstOrDefault(x => x.ID == id).PlantImage;
                    ViewBag.getPlantImage = getPlantImage;
                    ViewBag.returnId = query.ID;
                    return View(query);

                }
            }
            return View();
        }



        // Gelen Paramtereye göre işlemleri yapmak için "paramsProcess" parametresinin değerini kullanıyorum.
        [HttpPost]
        public JsonResult UpdatePlantIndex(Plants plant, int ssQQmmLL = 0, string paramProcess = "updateInfo")
        {

            //Eğer bu koşula uyarsa sadece fotğraf güncelle ! bir diğer koşul fotoğraf sunucuya düştüyse koşuludur
            if (paramProcess == "updateImage" && Request.Files.Count > 0)
            {
                using (MedicinalPlantsEntities db = new MedicinalPlantsEntities())
                {
                    Request.Files[0].SaveAs(Server.MapPath("/PlantsPhoto/" + plant.PlantImage));
                    plant.PlantImage = "/PlantsPhoto/" + plant.PlantImage;
                    var findPlant = db.Plants.FirstOrDefault(x => x.ID == ssQQmmLL);
                    findPlant.PlantImage = plant.PlantImage;
                    db.SaveChanges();

                }

                return Json(new
                {
                    response = "successPhoto",
                    JsonRequestBehavior.AllowGet
                });

            }

            //Burada İse Tablo bilgilerini güncelle !
            else
            {

                using (MedicinalPlantsEntities db = new MedicinalPlantsEntities())
                {
                    var findPlant = db.Plants.FirstOrDefault(x => x.ID == ssQQmmLL);
                    findPlant.PlantName = plant.PlantName;
                    findPlant.PlantAbout = plant.PlantAbout;
                    db.SaveChanges();

                }


                return Json(new
                {
                    response = "successUpdate",
                    JsonRequestBehavior.AllowGet
                });
            }
        }

    }
}





using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using SIFALIBITKILERMVC.Models.Entity;
namespace SIFALIBITKILERMVC.Controllers.PageVisit
{
    public class VisitorMessagesController : Controller
    {
        // GET: VisitorMessages

        [HttpPost]
        public JsonResult SendVisitorMessage(VisitorMessages visitorMessages, params string[] gelenDeger)
        {

            using (MedicinalPlantsEntities db = new MedicinalPlantsEntities())
            {


                if (visitorMessages.VisitorMail.Length <= 100 && visitorMessages.VisitorNameSurname.Length <= 50 && visitorMessages.VisitorMessage.Length <= 500)
                {
                    db.VisitorMessages.Add(visitorMessages);
                    db.SaveChanges();
                    return Json(new { response = "successMessage" }, JsonRequestBehavior.AllowGet);
                }
                else
                {

                    return Json(new { response = "errorMessage" }, JsonRequestBehavior.AllowGet);
                }

            }
        }
    }
}
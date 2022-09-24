using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIFALIBITKILERMVC.Models.Entity;
namespace SIFALIBITKILERMVC.Controllers.PageVisit
{
    [AllowAnonymous]
    public class PageVisitController : Controller
    {
        [HttpGet]
        public ActionResult PageVisitIndex()
        {
            using (MedicinalPlantsEntities db = new MedicinalPlantsEntities())
            {
                return View(db.Plants.ToList());
            }
        }
    }
}
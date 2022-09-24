using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIFALIBITKILERMVC.Models.Entity;
using PagedList.Mvc;
using PagedList;
namespace SIFALIBITKILERMVC.Controllers.Admin
{
    public class ReadPlantsController : Controller
    {
        // GET: ReadPlants
        [HttpGet]
        public ActionResult IndexList(int sayfa = 1, string SearchText = "")
        {
            using (MedicinalPlantsEntities db = new MedicinalPlantsEntities())
            {
                if (string.IsNullOrEmpty(SearchText))
                {
                    return View(db.Plants.ToList().ToPagedList(sayfa, 5));
                }
                else
                {
                    return View(db.Plants.Where(x => x.PlantName.Contains(SearchText)).ToList().ToPagedList(sayfa, 5));
                }
            }
        }
    }
}
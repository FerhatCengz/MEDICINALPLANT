using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIFALIBITKILERMVC.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace SIFALIBITKILERMVC.Controllers.Admin
{
    public class ReadVisitMessagesController : Controller
    {
        // GET: ReadVisitMessages
        public ActionResult ReadVisitMessagesIndex(int sayfa = 1)
        {
            using (MedicinalPlantsEntities db = new MedicinalPlantsEntities())
            {

                return View(db.VisitorMessages.ToList().ToPagedList(sayfa, 14));
            }
        }
    }
}
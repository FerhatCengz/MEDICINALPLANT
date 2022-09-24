using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIFALIBITKILERMVC.Models.Entity;
using System.Web.Security;
namespace SIFALIBITKILERMVC.Controllers.AdminLogin
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin

        [HttpGet]
        public ActionResult LoginIndex()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LoginIndex(Authority authority)
        {
            using (MedicinalPlantsEntities db = new MedicinalPlantsEntities())
            {
                var userControl = db.Authority.FirstOrDefault(x => x.UserName == authority.UserName && x.Password == authority.Password);
                if (userControl != null)
                {
                    FormsAuthentication.SetAuthCookie(authority.UserName, false);
                    Session["USERNAME"] = authority.UserName;
                    
                    return Json(new { success = "loginSucces" }, JsonRequestBehavior.AllowGet);
                }

                return Json(new { error = "loginError" }, JsonRequestBehavior.AllowGet);

            }
        }
    }
}
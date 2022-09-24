using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIFALIBITKILERMVC.Models.Entity;
namespace SIFALIBITKILERMVC.Controllers.Admin
{
    public class AdminProfileController : Controller
    {
        // GET: AdminProfile
        [HttpPost]
        public JsonResult AdminProfileIndex(Authority authority, string NewPassword1 = "")
        {
            using (MedicinalPlantsEntities db = new MedicinalPlantsEntities())
            {
                var getAdminOldPassword = db.Authority.FirstOrDefault(x => x.UserName == authority.UserName).Password;
                if (getAdminOldPassword == authority.Password)
                {
                    var getAdminID = db.Authority.FirstOrDefault(x => x.UserName == authority.UserName).ID;
                    var getAdminInfo = db.Authority.Find(getAdminID);
                    getAdminInfo.UserName = authority.UserName;
                    getAdminInfo.Password = NewPassword1;
                    db.SaveChanges();
                    return Json(new { response = "updateSuccess" }, JsonRequestBehavior.AllowGet);
                }

                else
                {
                    return Json(new { response = "updateError" }, JsonRequestBehavior.AllowGet);
                }
            }
        }
    }
}
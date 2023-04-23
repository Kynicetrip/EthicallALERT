using EthicalALERT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EthicalALERT.Controllers
{
    

    public class MemberController : Controller
    {
        MemberDB db = new MemberDB();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllMembers()
        {
            var members = db.GetAllMembers();
            return Json(members, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMemberById(int id)
        {
            var member = db.GetMemberById(id);
            return Json(member, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddMember(Member member)
        {
            db.AddMember(member);
            return Json(new { success = true });
        }

        public JsonResult UpdateMember(Member member)
        {
            db.UpdateMember(member);
            return Json(new { success = true });
        }

        public JsonResult DeleteMember(int id)
        {
            db.DeleteMember(id);
            return Json(new { success = true });
        }
    }

}
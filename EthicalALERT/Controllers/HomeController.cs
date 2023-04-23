using EthicalALERT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace EthicalALERT.Controllers
{   
    public class HomeController : Controller
    {

        MemberDB memberDB = new MemberDB();
        CauseDBEntities2 db = new CauseDBEntities2();
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult AddMember(Member member)
        {
            memberDB.AddMember(member);
            return Json(new { success = true });
        }

        public ActionResult Cause()
        {
           
            return View();
        }

        [HttpPost]
        public JsonResult AddCause(Cause cause)
        {
            // code to save the cause object to the database goes here
            // you can return any data you like in the JsonResult object
            return Json(new { success = true });
        }

        // Controller code
       
        public ActionResult Admin()
        {
            return View();
        }

        

        public ActionResult Register()
        {
            return View();
        }

       

        [HttpPost]
        public JsonResult AddRegistration(Registration registration)
        {
            // code to save the cause object to the database goes here
            // you can return any data you like in the JsonResult object
            return Json(new { success = true });
        }



        public ActionResult Signatures()
        {
            return View();
        }



       
    }
}
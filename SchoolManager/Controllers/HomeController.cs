using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CL_Database;

namespace SchoolManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SCHOOLEntities db = new SCHOOLEntities();
            List<SCH_SCHOOL> school = new List<SCH_SCHOOL>();
            school = db.SCH_SCHOOL.ToList();
            ViewBag.list = school;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult SaveData(string id, string name, string address)
        {
            bool estado = false;

            SCHOOLEntities db = new SCHOOLEntities();
            try
            {
                Int32 id_ = Convert.ToInt32(id);
           
                SCH_SCHOOL sch = new SCH_SCHOOL();
                sch.esc_id = id_;
                sch.esc_name = name;
                sch.esc_address = address;
                db.SCH_SCHOOL.Add(sch);
                db.SaveChanges();
                estado = true;
                db.Dispose();
            }
            catch (Exception e)
            {
                estado = false;
            }


            return Json(new { estado }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ModifyData(string id, string name, string address)
        {
            bool estado = false;

            SCHOOLEntities db = new SCHOOLEntities();

            try
            {
                Int32 id_ = Convert.ToInt32(id);

                SCH_SCHOOL sch = db.SCH_SCHOOL.Where(x => x.esc_id == id_).FirstOrDefault();
                sch.esc_id = id_;
                sch.esc_name = name;
                sch.esc_address = address;
                db.SaveChanges();
                estado = true;
                db.Dispose();
            }
            catch (Exception e)
            {
                estado = false;
            }


            return Json(new { estado }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteData(string id)
        {
            bool estado = false;

            SCHOOLEntities db = new SCHOOLEntities();

            Int32 id_ = Convert.ToInt32(id);

            try
            {
                SCH_SCHOOL sch = db.SCH_SCHOOL.Where(x => x.esc_id == id_).FirstOrDefault();
                db.SCH_SCHOOL.Remove(sch);
                db.SaveChanges();
                estado = true;
                db.Dispose();
            }
            catch (Exception e)
            {
                estado = false;
            }


            return Json(new { estado }, JsonRequestBehavior.AllowGet);
        }


    }
}
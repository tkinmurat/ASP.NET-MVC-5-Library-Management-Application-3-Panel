using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcLibrary.Models.Entity;
namespace mvcLibrary.Controllers
{
    public class StatisticsController : Controller
    {
        DBLIBRARYEntitiesa db= new DBLIBRARYEntitiesa();
        // GET: Statistics
        public ActionResult Index()
        {
            var val1=db.TblMembers.Count();
            var val2 = db.TblBook.Count();
            var val3 = db.TblBook.Where(z=>z.Situation==false).Count();
            var val4 = db.TblBan.Sum(z => z.Fine);
            ViewBag.value1=val1;
            ViewBag.value2 = val2;
            ViewBag.value3 = val3;
            ViewBag.value4 = val4;
            return View();
        }
        public ActionResult Weather()
        {

            return View();
        }
        public ActionResult WeatherCard()
        {

            return View();
        }

        public ActionResult Gallery()
        {

            return View();
        }
        public ActionResult UploadPhoto(HttpPostedFileBase photo)
        {
            if (photo.ContentLength > 0)
            {
                string pathway = Path.Combine(Server.MapPath("~/web2/img/"), Path.GetFileName(photo.FileName));
            photo.SaveAs(pathway);
            }
            return RedirectToAction("Gallery");
        }
    }
}
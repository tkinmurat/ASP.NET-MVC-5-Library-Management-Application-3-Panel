using Microsoft.Ajax.Utilities;
using mvcLibrary.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace mvcLibrary.Controllers
{
    public class BorrowController : Controller
    {
        DBLIBRARYEntitiesa db = new DBLIBRARYEntitiesa();
        // GET: Borrow
        public ActionResult Index()
        {
            var values = db.TblProcess.Where(x => x.ProcessSituation == false).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult Borrow() {
            return View();
        }
        [HttpPost]
        public ActionResult Borrow(TblProcess p)
        {
            db.TblProcess.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BorrowReturn(TblProcess p)
        {
            var brrw = db.TblProcess.Find(p.ID);
            DateTime d1 = DateTime.Parse(brrw.DueDate.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.val=d3.TotalDays;
            return View("BorrowReturn", brrw);
            
        }
        public ActionResult UpdateBorrow(TblProcess p)
        {
            var prc = db.TblProcess.Find(p.ID);
            prc.ReturnedDate = p.ReturnedDate;
            prc.ProcessSituation = true;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
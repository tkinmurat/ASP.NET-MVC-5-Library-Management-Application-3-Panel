using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcLibrary.Models.Entity;
using mvcLibrary.Models.Classes;

namespace mvcLibrary.Controllers
{
    public class WindowController : Controller
    {
        // GET: Window
        DBLIBRARYEntitiesa db=new DBLIBRARYEntitiesa();
        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Books = db.TblBook.ToList();
            cs.About = db.TblAbout.ToList();
            
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(TblContact t)
        {
            db.TblContact.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
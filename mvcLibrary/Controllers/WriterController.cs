using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcLibrary.Models.Entity;


namespace mvcLibrary.Controllers
{
    public class WriterController : Controller
    {
        // GET: Writer
        DBLIBRARYEntitiesa db= new DBLIBRARYEntitiesa();
        public ActionResult Index()
        {
           var values=db.TblWriter.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddNewWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewWriter(TblWriter w)
        {
            if (!ModelState.IsValid)
            {
                return View("AddNewWriter");
            }
            db.TblWriter.Add(w);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetWriter(int id)
        {
            var wrt = db.TblWriter.Find(id);
            return View("GetWriter",wrt);
        }

        public ActionResult UpdateWriter(TblWriter w)
        {
            var wrt = db.TblCategory.Find(w.ID);
            wrt.Name = w.Name;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult RemoveWriter(int id) {
            var writer = db.TblWriter.Find(id);
            db.TblWriter.Remove(writer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
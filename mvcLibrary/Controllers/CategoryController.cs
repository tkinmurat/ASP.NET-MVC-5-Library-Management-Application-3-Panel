using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcLibrary.Models.Entity;

namespace mvcLibrary.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        DBLIBRARYEntitiesa db = new DBLIBRARYEntitiesa();
        public ActionResult Index()
        {
            var values = db.TblCategory.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddNewCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewCategory(TblCategory c) { 
        db.TblCategory.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

      public ActionResult RemoveCategory(int id)
        {
            var category = db.TblCategory.Find(id);
           db.TblCategory.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCategory(int id)
        {
            var ctg=db.TblCategory.Find(id);
            return View("GetCategory",ctg);
        }

        public ActionResult UpdateCategory(TblCategory c) 
        {
            var ctg = db.TblCategory.Find(c.ID);
            ctg.Name = c.Name;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
   
    }
}
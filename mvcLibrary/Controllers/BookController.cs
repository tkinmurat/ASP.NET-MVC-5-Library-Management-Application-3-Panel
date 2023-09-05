using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using mvcLibrary.Models.Entity;


namespace mvcLibrary.Controllers
{

    public class BookController : Controller
    {
        // GET: Book
        DBLIBRARYEntitiesa db = new DBLIBRARYEntitiesa();
        public ActionResult Index(string p)
        {
            var values = from k in db.TblBook select k;
            if (!string.IsNullOrEmpty(p)) 
            {
                values = values.Where(x => x.Name.Contains(p));
            }
            return View(values.ToList());
        }
        [HttpGet]
        public ActionResult AddNewBook()
        {
            List<SelectListItem> cate = (from i in db.TblCategory.ToList()
                                         select new SelectListItem
                                         {
                                             Text= i.Name,
                                             Value=i.ID.ToString()
                                         }  ).ToList();
            ViewBag.cate1 = cate;
            List<SelectListItem> cate2=(from i in db.TblWriter.ToList()
                                        select new SelectListItem
                                        {
                                            Text = i.Name +" "+ i.LastName,
                                            Value = i.ID.ToString()
                                        }).ToList();
            ViewBag.cate2 = cate2;
            return View();
        }
        
        [HttpPost]
        public ActionResult AddNewBook(TblBook b)
        {
            var ctg = db.TblCategory.Where(c => c.ID == b.TblCategory.ID).FirstOrDefault();
            var wrt = db.TblWriter.Where(w => w.ID == b.TblWriter.ID).FirstOrDefault();
            b.TblCategory = ctg;
            b.TblWriter = wrt;
            db.TblBook.Add(b);
            db.SaveChanges();
            return RedirectToAction("Index");
           
        }
        public ActionResult RemoveBook(int id) {
            var book = db.TblBook.Find(id);
            db.TblBook.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");

            }

        public ActionResult GetBook(int id)
        {
            var book = db.TblBook.Find(id);
            List<SelectListItem> cate = (from i in db.TblCategory.ToList()
                                         select new SelectListItem
                                         {
                                             Text = i.Name,
                                             Value = i.ID.ToString()
                                         }).ToList();
            ViewBag.cate1 = cate;
            List<SelectListItem> cate2 = (from i in db.TblWriter.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.Name + " " + i.LastName,
                                              Value = i.ID.ToString()
                                          }).ToList();
            ViewBag.cate2 = cate2;
            return View("GetBook", book);
        }

        public ActionResult UpdateBook(TblBook b)
        {
            var book = db.TblBook.Find(b.ID);
            book.Name = b.Name;
            book.ReleaseYear = b.ReleaseYear;
            book.Page = b.Page;
            book.Publisher = b.Publisher;
            book.Situation = true;
            var ctg=db.TblCategory.Where(c => c.ID==b.TblCategory.ID).FirstOrDefault();
            var wrt = db.TblWriter.Where(w => w.ID == b.TblWriter.ID).FirstOrDefault();
            book.Category = ctg.ID;
            book.Writer = wrt.ID;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
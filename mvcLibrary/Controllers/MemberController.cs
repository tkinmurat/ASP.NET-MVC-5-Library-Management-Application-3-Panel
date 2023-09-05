using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using mvcLibrary.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace mvcLibrary.Controllers
{
    public class MemberController : Controller
    {
        DBLIBRARYEntitiesa db = new DBLIBRARYEntitiesa();
        // GET: Member
        
        public ActionResult Index(int page = 1)
        {
            var values = db.TblMembers.ToList().ToPagedList(page, 4); 
            return View(values);
        }
        [HttpGet]
        public ActionResult AddNewMember()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewMember(TblMembers m)
        {
            if (!ModelState.IsValid)
            {
                return View("AddNewMember");
            }
            db.TblMembers.Add(m);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetMember(int id)
        {
            var mbr = db.TblMembers.Find(id);
            return View("GetMember", mbr);
        }

        public ActionResult UpdateMember(TblMembers m)
        {
            var mbr = db.TblMembers.Find(m.ID);
            mbr.Name = m.Name;
            mbr.LastName = m.LastName;
            mbr.Mail = m.Mail;
            mbr.UserName = m.UserName;
            mbr.Password = m.Password;
            mbr.Photo = m.Photo;
            mbr.PhoneNumber = m.PhoneNumber;
            mbr.University = m.University;

            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult RemoveMember(int id)
        {
            var member = db.TblMembers.Find(id);
            db.TblMembers.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public ActionResult Search(string p) 
        //{
        //    var values = from k in db.TblMembers select k;
        //    if (!string.IsNullOrEmpty(p))
        //    {
        //        values = values.Where(x => x.Name.Contains(p));
        //    }
        //    return View(values.ToList());
        //}

    }
}
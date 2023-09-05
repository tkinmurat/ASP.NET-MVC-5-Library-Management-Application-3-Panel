using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcLibrary.Models.Entity;

namespace mvcLibrary.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        DBLIBRARYEntitiesa db = new DBLIBRARYEntitiesa();
        public ActionResult Index()
        {
            var values = db.TblEmployee.ToList();
            return View(values);
           
        }
        [HttpGet]
        public ActionResult AddNewEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewEmployee(TblEmployee e)
        {
            if (!ModelState.IsValid)
            {
                return View("AddNewEmployee");
            }
            db.TblEmployee.Add(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult RemoveEmployee(int id)
        {
            var employee = db.TblEmployee.Find(id);
            db.TblEmployee.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetEmployee(int id)
        {
            var emp = db.TblEmployee.Find(id);
            return View("GetEmployee", emp);
        }

        public ActionResult UpdateEmployee(TblEmployee e)
        {
            var emp = db.TblEmployee.Find(e.ID);
            emp.Employee = e.Employee;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
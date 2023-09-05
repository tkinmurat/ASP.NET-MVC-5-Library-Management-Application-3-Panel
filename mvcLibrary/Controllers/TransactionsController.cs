using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcLibrary.Models.Entity;
namespace mvcLibrary.Controllers
{
    public class TransactionsController : Controller
    {
        // GET: Transactions
        DBLIBRARYEntitiesa db=new DBLIBRARYEntitiesa();
        public ActionResult Index()
        {

            var values = db.TblProcess.Where(x => x.ProcessSituation == true).ToList();
            return View(values);
        }
    }
}
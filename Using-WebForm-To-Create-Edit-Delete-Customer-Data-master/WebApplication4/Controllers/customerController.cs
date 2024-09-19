using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class customerController : Controller
    {
        // GET: customer
        public ActionResult Index()
        {
            Kirti2Entities dbContext = new Kirti2Entities(); //found the name from ~ Models\Model1.Context.cs
            List<customer> empList = dbContext.customers.ToList();
            return View(empList);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class empDataController : Controller
    {
        // GET: empData
        public ActionResult Index()
        {
            KirtiEntities dbContext = new KirtiEntities(); //found the name from ~ Models\Model1.Context.cs
            List<empData> empList = dbContext.empDatas.ToList();
            return View(empList);
        }
    }
}
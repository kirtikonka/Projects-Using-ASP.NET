using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class empDatazzController : Controller
    {
        private KirtiEntities db = new KirtiEntities();

        // GET: empDatazz
        public ActionResult Index()
        {
            return View(db.empDatas.ToList());
        }

        // GET: empDatazz/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empData empData = db.empDatas.Find(id);
            if (empData == null)
            {
                return HttpNotFound();
            }
            return View(empData);
        }

        // GET: empDatazz/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: empDatazz/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,email,mobile,Flag,datetime")] empData empData)
        {
            if (ModelState.IsValid)
            {
                db.empDatas.Add(empData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empData);
        }

        // GET: empDatazz/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empData empData = db.empDatas.Find(id);
            if (empData == null)
            {
                return HttpNotFound();
            }
            return View(empData);
        }

        // POST: empDatazz/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,email,mobile,Flag,datetime")] empData empData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empData);
        }

        // GET: empDatazz/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empData empData = db.empDatas.Find(id);
            if (empData == null)
            {
                return HttpNotFound();
            }
            return View(empData);
        }

        // POST: empDatazz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            empData empData = db.empDatas.Find(id);
            db.empDatas.Remove(empData);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

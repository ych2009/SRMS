using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SRMS.Models;

namespace SRMS.Controllers
{
    public class workdetailsController : Controller
    {
        private SRMSEntities db = new SRMSEntities();

        // GET: workdetails
        public ActionResult Index()
        {
            var workdetailSet = db.workdetailSet.Include(w => w.lineworkinfo);
            return View(workdetailSet.ToList());
        }

        // GET: workdetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            workdetail workdetail = db.workdetailSet.Find(id);
            if (workdetail == null)
            {
                return HttpNotFound();
            }
            return View(workdetail);
        }

        // GET: workdetails/Create
        public ActionResult Create()
        {
            ViewBag.lineworkinfoId = new SelectList(db.lineworkinfoSet, "Id", "code");
            return View();
        }

        // POST: workdetails/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,finishnum,lineworkinfoId,buildtime")] workdetail workdetail)
        {
            if (ModelState.IsValid)
            {
                db.workdetailSet.Add(workdetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.lineworkinfoId = new SelectList(db.lineworkinfoSet, "Id", "code", workdetail.lineworkinfoId);
            return View(workdetail);
        }

        // GET: workdetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            workdetail workdetail = db.workdetailSet.Find(id);
            if (workdetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.lineworkinfoId = new SelectList(db.lineworkinfoSet, "Id", "code", workdetail.lineworkinfoId);
            return View(workdetail);
        }

        // POST: workdetails/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,finishnum,lineworkinfoId,buildtime")] workdetail workdetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workdetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.lineworkinfoId = new SelectList(db.lineworkinfoSet, "Id", "code", workdetail.lineworkinfoId);
            return View(workdetail);
        }

        // GET: workdetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            workdetail workdetail = db.workdetailSet.Find(id);
            if (workdetail == null)
            {
                return HttpNotFound();
            }
            return View(workdetail);
        }

        // POST: workdetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            workdetail workdetail = db.workdetailSet.Find(id);
            db.workdetailSet.Remove(workdetail);
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

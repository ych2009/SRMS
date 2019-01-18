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
    public class deviceinfoSetsController : Controller
    {
        private SRMSEntities db = new SRMSEntities();

        // GET: deviceinfoSets
        public ActionResult Index()
        {
            var deviceinfoSet = db.deviceinfoSet.Include(d => d.lineinfoSet);
            return View(deviceinfoSet.ToList());
        }

        // GET: deviceinfoSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            deviceinfoSet deviceinfoSet = db.deviceinfoSet.Find(id);
            if (deviceinfoSet == null)
            {
                return HttpNotFound();
            }
            return View(deviceinfoSet);
        }

        // GET: deviceinfoSets/Create
        public ActionResult Create()
        {
            ViewBag.lineinfoSetId = new SelectList(db.lineinfoSet, "Id", "code");
            return View();
        }

        // POST: deviceinfoSets/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,code,name,productor,devicetype,totallifetime,usedlifetime,buildtime,lineinfoSetId")] deviceinfoSet deviceinfoSet)
        {
            if (ModelState.IsValid)
            {
                db.deviceinfoSet.Add(deviceinfoSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.lineinfoSetId = new SelectList(db.lineinfoSet, "Id", "code", deviceinfoSet.lineinfoSetId);
            return View(deviceinfoSet);
        }

        // GET: deviceinfoSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            deviceinfoSet deviceinfoSet = db.deviceinfoSet.Find(id);
            if (deviceinfoSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.lineinfoSetId = new SelectList(db.lineinfoSet, "Id", "code", deviceinfoSet.lineinfoSetId);
            return View(deviceinfoSet);
        }

        // POST: deviceinfoSets/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,code,name,productor,devicetype,totallifetime,usedlifetime,buildtime,lineinfoSetId")] deviceinfoSet deviceinfoSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deviceinfoSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.lineinfoSetId = new SelectList(db.lineinfoSet, "Id", "code", deviceinfoSet.lineinfoSetId);
            return View(deviceinfoSet);
        }

        // GET: deviceinfoSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            deviceinfoSet deviceinfoSet = db.deviceinfoSet.Find(id);
            if (deviceinfoSet == null)
            {
                return HttpNotFound();
            }
            return View(deviceinfoSet);
        }

        // POST: deviceinfoSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            deviceinfoSet deviceinfoSet = db.deviceinfoSet.Find(id);
            db.deviceinfoSet.Remove(deviceinfoSet);
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

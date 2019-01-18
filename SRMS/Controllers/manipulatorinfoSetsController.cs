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
    public class manipulatorinfoSetsController : Controller
    {
        private SRMSEntities db = new SRMSEntities();

        // GET: manipulatorinfoSets
        public ActionResult Index()
        {
            var manipulatorinfoSet = db.manipulatorinfoSet.Include(m => m.lineinfoSet);
            return View(manipulatorinfoSet.ToList());
        }

        // GET: manipulatorinfoSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            manipulatorinfoSet manipulatorinfoSet = db.manipulatorinfoSet.Find(id);
            if (manipulatorinfoSet == null)
            {
                return HttpNotFound();
            }
            return View(manipulatorinfoSet);
        }

        // GET: manipulatorinfoSets/Create
        public ActionResult Create()
        {
            ViewBag.lineinfoSetId = new SelectList(db.lineinfoSet, "Id", "code");
            return View();
        }

        // POST: manipulatorinfoSets/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,code,name,status,x,y,speed,catchnum,buildtime,lineinfoSetId")] manipulatorinfoSet manipulatorinfoSet)
        {
            if (ModelState.IsValid)
            {
                db.manipulatorinfoSet.Add(manipulatorinfoSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.lineinfoSetId = new SelectList(db.lineinfoSet, "Id", "code", manipulatorinfoSet.lineinfoSetId);
            return View(manipulatorinfoSet);
        }

        // GET: manipulatorinfoSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            manipulatorinfoSet manipulatorinfoSet = db.manipulatorinfoSet.Find(id);
            if (manipulatorinfoSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.lineinfoSetId = new SelectList(db.lineinfoSet, "Id", "code", manipulatorinfoSet.lineinfoSetId);
            return View(manipulatorinfoSet);
        }

        // POST: manipulatorinfoSets/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,code,name,status,x,y,speed,catchnum,buildtime,lineinfoSetId")] manipulatorinfoSet manipulatorinfoSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manipulatorinfoSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.lineinfoSetId = new SelectList(db.lineinfoSet, "Id", "code", manipulatorinfoSet.lineinfoSetId);
            return View(manipulatorinfoSet);
        }

        // GET: manipulatorinfoSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            manipulatorinfoSet manipulatorinfoSet = db.manipulatorinfoSet.Find(id);
            if (manipulatorinfoSet == null)
            {
                return HttpNotFound();
            }
            return View(manipulatorinfoSet);
        }

        // POST: manipulatorinfoSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            manipulatorinfoSet manipulatorinfoSet = db.manipulatorinfoSet.Find(id);
            db.manipulatorinfoSet.Remove(manipulatorinfoSet);
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

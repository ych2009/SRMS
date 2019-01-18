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
    public class lineworkinfoesController : Controller
    {
        private SRMSEntities db = new SRMSEntities();

        // GET: lineworkinfoes
        public ActionResult Index()
        {
            var lineworkinfoSet = db.lineworkinfoSet.Include(l => l.lineinfoSet);
            return View(lineworkinfoSet.ToList());
        }

        // GET: lineworkinfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lineworkinfo lineworkinfo = db.lineworkinfoSet.Find(id);
            if (lineworkinfo == null)
            {
                return HttpNotFound();
            }
            return View(lineworkinfo);
        }

        // GET: lineworkinfoes/Create
        public ActionResult Create()
        {
            ViewBag.lineinfoSetId = new SelectList(db.lineinfoSet, "Id", "code");
            return View();
        }

        // POST: lineworkinfoes/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,code,name,sampletime,totalnum,finishnum,errornum,bulidtime,lineinfoSetId")] lineworkinfo lineworkinfo)
        {
            if (ModelState.IsValid)
            {
                db.lineworkinfoSet.Add(lineworkinfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.lineinfoSetId = new SelectList(db.lineinfoSet, "Id", "code", lineworkinfo.lineinfoSetId);
            return View(lineworkinfo);
        }

        // GET: lineworkinfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lineworkinfo lineworkinfo = db.lineworkinfoSet.Find(id);
            if (lineworkinfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.lineinfoSetId = new SelectList(db.lineinfoSet, "Id", "code", lineworkinfo.lineinfoSetId);
            return View(lineworkinfo);
        }

        // POST: lineworkinfoes/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,code,name,sampletime,totalnum,finishnum,errornum,bulidtime,lineinfoSetId")] lineworkinfo lineworkinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lineworkinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.lineinfoSetId = new SelectList(db.lineinfoSet, "Id", "code", lineworkinfo.lineinfoSetId);
            return View(lineworkinfo);
        }

        // GET: lineworkinfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lineworkinfo lineworkinfo = db.lineworkinfoSet.Find(id);
            if (lineworkinfo == null)
            {
                return HttpNotFound();
            }
            return View(lineworkinfo);
        }

        // POST: lineworkinfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lineworkinfo lineworkinfo = db.lineworkinfoSet.Find(id);
            db.lineworkinfoSet.Remove(lineworkinfo);
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

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
    public class lineinfoSetsController : Controller
    {
        private SRMSEntities db = new SRMSEntities();

        // GET: lineinfoSets
        public ActionResult Index()
        {
            return View(db.lineinfoSet.ToList());
        }

        // GET: lineinfoSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lineinfoSet lineinfoSet = db.lineinfoSet.Find(id);
            if (lineinfoSet == null)
            {
                return HttpNotFound();
            }
            return View(lineinfoSet);
        }

        // GET: lineinfoSets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: lineinfoSets/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,code,name,buildtime")] lineinfoSet lineinfoSet)
        {
            if (ModelState.IsValid)
            {
                db.lineinfoSet.Add(lineinfoSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lineinfoSet);
        }

        // GET: lineinfoSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lineinfoSet lineinfoSet = db.lineinfoSet.Find(id);
            if (lineinfoSet == null)
            {
                return HttpNotFound();
            }
            return View(lineinfoSet);
        }

        // POST: lineinfoSets/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,code,name,buildtime")] lineinfoSet lineinfoSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lineinfoSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lineinfoSet);
        }

        // GET: lineinfoSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lineinfoSet lineinfoSet = db.lineinfoSet.Find(id);
            if (lineinfoSet == null)
            {
                return HttpNotFound();
            }
            return View(lineinfoSet);
        }

        // POST: lineinfoSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lineinfoSet lineinfoSet = db.lineinfoSet.Find(id);
            db.lineinfoSet.Remove(lineinfoSet);
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

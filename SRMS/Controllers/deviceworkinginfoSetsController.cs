using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SRMS.Models;
using SRMS.Models.model1;

namespace SRMS.Controllers
{
    public class deviceworkinginfoSetsController : Controller
    {
        private SRMSEntities db = new SRMSEntities();

        // GET: deviceworkinginfoSets
        public ActionResult Index()
        {
            return View(db.deviceworkinginfoSet.ToList());
        }

        // GET: deviceworkinginfoSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            deviceworkinginfoSet deviceworkinginfoSet = db.deviceworkinginfoSet.Find(id);
            if (deviceworkinginfoSet == null)
            {
                return HttpNotFound();
            }
            return View(deviceworkinginfoSet);
        }

        // GET: deviceworkinginfoSets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: deviceworkinginfoSets/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,runningstatus,mainspeed,errorcount,totalcount,buildtime,isruning,isfinished")] deviceworkinginfoSet deviceworkinginfoSet)
        {
            if (ModelState.IsValid)
            {
                db.deviceworkinginfoSet.Add(deviceworkinginfoSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deviceworkinginfoSet);
        }

        // GET: deviceworkinginfoSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            deviceworkinginfoSet deviceworkinginfoSet = db.deviceworkinginfoSet.Find(id);
            if (deviceworkinginfoSet == null)
            {
                return HttpNotFound();
            }
            return View(deviceworkinginfoSet);
        }

        // POST: deviceworkinginfoSets/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,runningstatus,mainspeed,errorcount,totalcount,buildtime,isruning,isfinished")] deviceworkinginfoSet deviceworkinginfoSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deviceworkinginfoSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deviceworkinginfoSet);
        }

        // GET: deviceworkinginfoSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            deviceworkinginfoSet deviceworkinginfoSet = db.deviceworkinginfoSet.Find(id);
            if (deviceworkinginfoSet == null)
            {
                return HttpNotFound();
            }
            return View(deviceworkinginfoSet);
        }



        public JsonResult GetJsonData(int? lineinfoId)
        {
            db.Configuration.ProxyCreationEnabled = false;

            //设备信息(饼状图)
            var deviceinfo = db.deviceinfoSet.Include("deviceworkinginfoSet").Where(u => u.lineinfoSetId == lineinfoId);
            List<deviceinfoSet> deviceinfolist = deviceinfo.ToList();
            List<deviceworkinginfos> deviceworkinglist = new List<deviceworkinginfos>(); //自定义models,附件外键实体信息，便于转json
            foreach (var item in deviceinfolist)
            {
                deviceworkinginfos itemtemp = new deviceworkinginfos();
                itemtemp.code = item.code;
                itemtemp.name = item.name;
                itemtemp.productor = item.productor;
                itemtemp.lineinfoSetId = item.lineinfoSetId;
                itemtemp.devicetype = item.devicetype;
                itemtemp.totallifetime = item.totallifetime;
                itemtemp.usedlifetime = item.usedlifetime;
                itemtemp.buildtime = item.buildtime;
                itemtemp.errorcount = item.deviceworkinginfoSet.errorcount;
                itemtemp.mainspeed = item.deviceworkinginfoSet.mainspeed;
                itemtemp.runningstatus = item.deviceworkinginfoSet.runningstatus;
                itemtemp.totalcount = item.deviceworkinginfoSet.totalcount;
                itemtemp.isrunning = item.deviceworkinginfoSet.isruning;
                itemtemp.isfinished = item.deviceworkinginfoSet.isfinished;
                itemtemp.iswarning = item.deviceworkinginfoSet.iswarning;
                deviceworkinglist.Add(itemtemp);
            }            
            var jsondata = new { deviceworkinginfo = deviceworkinglist};
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetJsonData1()
        {
            db.Configuration.ProxyCreationEnabled = false;
            //生产线数据（下拉框）
            var lineinfo = from u in db.lineinfoSet
                           select new { Id = u.Id, name = u.name };
            List<lineinfoSet> lineinfolist = new List<lineinfoSet>();
            foreach (var item in lineinfo)
            {
                lineinfoSet itemtemp = new lineinfoSet();
                itemtemp.Id = item.Id;
                itemtemp.name = item.name;
                lineinfolist.Add(itemtemp);
            }
            var jsondata = new { linelist = lineinfolist };
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }

        // POST: deviceworkinginfoSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            deviceworkinginfoSet deviceworkinginfoSet = db.deviceworkinginfoSet.Find(id);
            db.deviceworkinginfoSet.Remove(deviceworkinginfoSet);
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

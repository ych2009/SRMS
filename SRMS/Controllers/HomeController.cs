using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SRMS.Models;
using SRMS.Models.model1;

namespace SRMS.Controllers
{
    public class HomeController : Controller
    {
        private SRMSEntities db = new SRMSEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Tips()
        {
            ViewBag.Message = "网页暂时未开发";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult GetJsonData(int? lineinfoId, int? productinfoSetId)
        {
            db.Configuration.ProxyCreationEnabled = false;

            //根据产线Id、产品Id(下拉框获取)，查询lineworkId
            var lineworkinfo = from u in db.lineworkinfoSet
                               where u.lineinfoSetId == lineinfoId
                               where u.productinfoSetId == productinfoSetId
                               select new { lineworkId = u.Id, totalnum = u.totalnum, finishnum = u.finishnum, errornum = u.errornum };

            var lineworkId = lineworkinfo.ToList()[0].lineworkId;
            var productinfo = from u in db.productinfoSet
                              where u.Id == productinfoSetId
                              select new { productname = u.name };
            List<lineworkinfos> lineworkinfosList = new List<lineworkinfos>();
            lineworkinfos itemtemp1 = new lineworkinfos();
            itemtemp1.totalnum = lineworkinfo.ToList()[0].totalnum;
            itemtemp1.finishnum = lineworkinfo.ToList()[0].finishnum;
            itemtemp1.errornum = lineworkinfo.ToList()[0].errornum;
            itemtemp1.productinfoSetName = productinfo.ToList()[0].productname;
            lineworkinfosList.Add(itemtemp1);

            //机械手位置图
            var manipulatorinfoSet = db.manipulatorinfoSet.Where(u => u.lineinfoSetId == lineinfoId);
            List<manipulatorinfoSet> manipulatorinfoSetList = manipulatorinfoSet.ToList();
            //生产统计图
            var workdetail = db.workdetailSet.Where(u => u.lineworkinfoId == lineworkId);
            List<workdetail> workdetailList = workdetail.ToList();

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
                deviceworkinglist.Add(itemtemp);
            }

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
            //产品数据（下拉框）
            var productinfo1 = from u in db.productinfoSet
                               select new { Id = u.Id, name = u.name };
            List<productinfoSet> productinfolist = new List<productinfoSet>();
            foreach (var item in productinfo1)
            {
                productinfoSet itemtemp = new productinfoSet();
                itemtemp.Id = item.Id;
                itemtemp.name = item.name;
                productinfolist.Add(itemtemp);
            }

            var jsondata = new { data1 = manipulatorinfoSetList, data2 = workdetailList, data3 = deviceworkinglist, data4 = lineworkinfosList, data5 = lineinfolist, data6 = productinfolist };
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
            //产品数据（下拉框）
            var productinfo1 = from u in db.productinfoSet
                               select new { Id = u.Id, name = u.name };
            List<productinfoSet> productinfolist = new List<productinfoSet>();
            foreach (var item in productinfo1)
            {
                productinfoSet itemtemp = new productinfoSet();
                itemtemp.Id = item.Id;
                itemtemp.name = item.name;
                productinfolist.Add(itemtemp);
            }

            var jsondata = new {linelist = lineinfolist, productlist = productinfolist };
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }
    }
}
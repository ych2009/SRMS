using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Services;
using SRMS.Models;

namespace SRMS
{
    /// <summary>
    /// SRCSWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class SRCSWebService : System.Web.Services.WebService
    {
        private SRMSEntities db = new SRMSEntities();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string Test(bool status, int x, int y, int speed, int catchnum, int lineinfoId)
        {
            if (lineinfoId == 1)
            {
                db.Configuration.AutoDetectChangesEnabled = true;
                var manipulatorinfoSet = from u in db.manipulatorinfoSet
                                         where u.lineinfoSetId == lineinfoId
                                         select u;
                //List<manipulatorinfoSet> manipulatorinfoSetList = manipulatorinfoSet.ToList();

                foreach (manipulatorinfoSet item in manipulatorinfoSet)
                {
                    item.buildtime = DateTime.Now;
                    item.status = status;
                    item.x = x;
                    item.y = y;
                    item.speed = speed;
                    item.catchnum = catchnum;
                }
                db.Configuration.AutoDetectChangesEnabled = true;
                db.SaveChanges();
                return "success";
            }
            else
                return "failed";
        }


        [WebMethod]
        public string Test1(int finishnum, int lineworkinfoId)
        {
            //db.Configuration.AutoDetectChangesEnabled = true;
            //var workdetail = from u in db.workdetailSet
            //                         where u.lineworkinfoId == lineworkinfoId
            //                 select u;
            //foreach (workdetail item in workdetail)
            //{
            //    item.finishnum = finishnum;
            //    item.lineworkinfoId = lineworkinfoId;
            //}
            //db.Configuration.AutoDetectChangesEnabled = true;
            //db.SaveChanges();
            SRMSEntities db = new SRMSEntities();
            workdetail workdetail = new workdetail();
            workdetail.finishnum = finishnum;
            workdetail.lineworkinfoId = lineworkinfoId;
            workdetail.buildtime = DateTime.Now;
            db.workdetailSet.Add(workdetail);
            db.SaveChanges();
            return "success";
        }

    }
}

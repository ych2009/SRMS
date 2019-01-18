using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRMS.Models.model1
{
    public class deviceworkinginfos
    {

        public string code { get; set; }
        public string name { get; set; }
        public string productor { get; set; }
        public string devicetype { get; set; }
        public int totallifetime { get; set; }
        public int usedlifetime { get; set; }

        public int lineinfoSetId { get; set; }
        public bool runningstatus { get; set; }
        public bool isrunning { get; set; }
        public bool isfinished { get; set; }
        public bool iswarning { get; set; }
        public int mainspeed { get; set; }
        public int errorcount { get; set; }
        public int totalcount { get; set; }
        public System.DateTime buildtime { get; set; }
    }
}
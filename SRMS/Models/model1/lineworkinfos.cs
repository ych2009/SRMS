using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRMS.Models.model1
{
    public class lineworkinfos
    {
        public string code { get; set; }
        public string name { get; set; }
        public string sampletime { get; set; }
        public int totalnum { get; set; }
        public int finishnum { get; set; }
        public int errornum { get; set; }
        public System.DateTime bulidtime { get; set; }
        public int lineinfoSetId { get; set; }
        public int productinfoSetId { get; set; }
        public string productinfoSetName { get; set; }
    }
}
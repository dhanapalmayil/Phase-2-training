using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    internal class Course
    {
        public int Cid {  get; set; }
        public string Cname { get; set; }

        public int Cduration {  get; set; }

        public Course(int Cid,string cname,int Cduration) { 
            this.Cid = Cid;
            this.Cname=cname;
            this.Cduration = Cduration;
        }
    }
}

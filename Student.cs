using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentApplication
{
    public class Student
    {
        public int stid { get; set; }
        public string stname { get; set; }
        public int stmarks { get; set; }
        public Student()
        {

        }
        public Student(int stid, string stname, int stmarks)
        {
            this.stid = stid;
            this.stname = stname;
            this.stmarks = stmarks;
        }
    }
}
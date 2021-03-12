using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace StudentApplication
{
    public class BusinessLogic
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommandBuilder cmb;
        DataRow row;
        DataSet ds;
        public BusinessLogic()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            con = new SqlConnection(cs);
            da = new SqlDataAdapter("select * from tbl_student", con);
            cmb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, "tbl_student");
            da.Update(ds.Tables["tbl_student"]);
            ds.Tables["tbl_student"].Constraints.Add("stid_pk", ds.Tables["tbl_student"].Columns["stid"], true);
        }
        public bool AddStudent(Student stu)
        {
            row = ds.Tables["tbl_student"].NewRow();
            row["stid"] = stu.stid;
            row["stname"] = stu.stname;
            row["stmarks"] = stu.stmarks;
            ds.Tables["tbl_student"].Rows.Add(row);
            return da.Update(ds.Tables["tbl_student"]) == 1;
        }
        public bool DeleteStudent(Student stu)
        {
            ds.Tables["tbl_student"].Rows.Find(stu.stid).Delete();
            return da.Update(ds.Tables["tbl_student"]) == 1;
        }
        public bool UpdateStudent(Student stu)
        {
            row= ds.Tables["tbl_student"].Rows.Find(stu.stid);
            row.BeginEdit();
            row["stname"] = stu.stname;
            row["stmarks"] = stu.stmarks;
            row.EndEdit();
            return da.Update(ds.Tables["tbl_student"]) == 1;
            
        }
        public Student GetStudent(Student stu)
        {
            row = ds.Tables["tbl_student"].Rows.Find(stu.stid);
            stu.stname = row["stname"].ToString();
            stu.stmarks = Convert.ToInt32(row["stmarks"]);
            return stu;
        }
        public DataSet GetStudent()
        {
            return ds;
        }
    }

}
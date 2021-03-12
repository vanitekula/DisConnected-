using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentApplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Display();
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            if (new BusinessLogic().AddStudent(new Student() {stid=int.Parse(TextBox1.Text),stname=TextBox2.Text,stmarks=int.Parse(TextBox3.Text)}))
            {
                Display();
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            if (new BusinessLogic().DeleteStudent(new Student() {stid = int.Parse(TextBox1.Text)}))
            {
                Display();
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (new BusinessLogic().UpdateStudent(new Student() {stid = int.Parse(TextBox1.Text), stname = TextBox2.Text, stmarks = int.Parse(TextBox3.Text) }))
            {
                Display();
            }
        }

        protected void BtnFind_Click(object sender, EventArgs e)
        {
            Student stu = new BusinessLogic().GetStudent(new Student() { stid = int.Parse(TextBox1.Text) });
            TextBox2.Text = stu.stname;
            TextBox3.Text = stu.stmarks.ToString();
        }
        public void Display()
        {
            GridView1.DataSource = new BusinessLogic().GetStudent();
            GridView1.DataBind();
        }
    }
}
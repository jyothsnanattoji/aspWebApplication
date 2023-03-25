using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2.Webpages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Repeater1.Visible = false;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertStudent.aspx");
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string Id = Request.Form["Id"];
            string FirstName = Request.Form["FirstName"];
            string conn = ConfigurationManager.ConnectionStrings["dbcs"].ToString();
            StudentRepository studentrepo = new StudentRepository(conn);
            List<Student> students = new List<Student>();
            if (!string.IsNullOrEmpty(Id))
            {
                students= studentrepo.GetStudentById(Convert.ToInt32(Id));
                Repeater1.DataSource = students;
                Repeater1.DataBind();
                Repeater1.Visible = true;
            }
            else if (!string.IsNullOrEmpty(FirstName))
            {
                students = studentrepo.GetSTudentByName(FirstName);
                Repeater1.DataSource = students;
                Repeater1.DataBind();
                Repeater1.Visible = true;
            }
            else if(string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(Id))
            {
                students = studentrepo.GetAllStudent();
                Repeater1.DataSource = students;
                Repeater1.DataBind();
                Repeater1.Visible = true;
            }
            if (students.Count == 0)
            {
                errorLabel.Visible = true;
                errorLabel.InnerText = "NO SUCH STUDENT FOUND!!!";
            }
            else
            {
                errorLabel.Visible = false;
            }
        }
    }
}
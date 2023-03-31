using System;
using System.Collections.Generic;
using System.Configuration;
using StudentRepo;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2.Webpages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Boolean IsPageRefresh = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["ViewStateId"] = System.Guid.NewGuid().ToString();
                Session["SessionId"] = ViewState["ViewStateId"].ToString();
                // ViewState["PageState"] = "Initial";
            }
            else
            {
                if (ViewState["ViewStateId"].ToString() != Session["SessionId"].ToString())
                {
                    IsPageRefresh = true;
                    Id.Text = "";
                    FirstName.Text = "";
                }

                Session["SessionId"] = System.Guid.NewGuid().ToString();
                ViewState["ViewStateId"] = Session["SessionId"].ToString();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertStudent.aspx");
        }
        protected async void Button2_Click(object sender, EventArgs e)
        {
            if(!IsPageRefresh)
            {
                string Id = Request.Form["Id"];
                string FirstName = Request.Form["FirstName"];
                string conn = ConfigurationManager.ConnectionStrings["dbcs"].ToString();
                StudentRepository studentrepo = new StudentRepository(conn);
                List<Student> students = new List<Student>();
                if (!string.IsNullOrEmpty(Id))
                {
                    students = studentrepo.GetStudentById(Convert.ToInt32(Id));
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
                //else if (string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(Id))
                //{
                //    students = studentrepo.GetAllStudent();
                //    Repeater1.DataSource = students;
                //    Repeater1.DataBind();
                //    Repeater1.Visible = true;
                //}
                else if (string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(Id))
                {
                    int pageSize = 3; // set a large page size
                    int pageNumber = 1;
                    while (true)
                    {
                        List<Student> page = await studentrepo.GetAllStudentAsync(pageSize, pageNumber);
                        if (page.Count == 0) break;
                        students.AddRange(page);
                        pageNumber++;
                    }
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
}
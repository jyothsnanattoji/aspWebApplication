using StudentRepo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2.Webpages
{

    public partial class InsertStudent1 : System.Web.UI.Page
    {
        Boolean IsPageRefresh = false;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                ClearFormFields();
                ClearErrorMessages();
                ViewState["ViewStateId"] = System.Guid.NewGuid().ToString();
                Session["SessionId"] = ViewState["ViewStateId"].ToString();
               // ViewState["PageState"] = "Initial";
            }
            else
            {
                if (ViewState["ViewStateId"].ToString() != Session["SessionId"].ToString())
                {
                    IsPageRefresh = true;
                    ClearFormFields();
                    ClearErrorMessages();
                }

                Session["SessionId"] = System.Guid.NewGuid().ToString();
                ViewState["ViewStateId"] = Session["SessionId"].ToString();
            }

        }
        protected void Submit_Clicked(object sender, EventArgs e)
        {
            if(!IsPageRefresh)
            {
                Student student = new Student();
                student.id = Convert.ToInt32(Id.Text);
                student.Marks = Convert.ToInt32(Marks.Text);
                student.FirstName = FirstName.Text;
                student.LastName = LastName.Text;
                student.Dob = (Dob.Text);
                student.FatherName = FatherName.Text;
                student.MotherName = MotherName.Text;
                student.Address = Address.Text;
                student.Mobile = Mobile.Text;
             
                string conn = ConfigurationManager.ConnectionStrings["dbcs"].ToString();
                StudentRepository studentrepo = new StudentRepository(conn);
                if (!studentrepo.SearchById(student.id) && !studentrepo.SearchByMobile(student.Mobile))
                {
                    //ViewState["PageState"] = "Submitted";
                    studentrepo.AddStudent(student);
                    ClearFormFields();
                    ClearErrorMessages();
                }
                else
                {
                    errorLabel.InnerText += "Student with this Id or Phone number already exists" + Environment.NewLine;
                }
                //ViewState["PageState"] = "Initial";
            }
               
        }
            

        private void ClearFormFields()
        {
            Id.Text = "";
            FirstName.Text = "";
            LastName.Text = "";
            FatherName.Text = "";
            MotherName.Text = "";
            Address.Text = "";
            Mobile.Text = "";
            Marks.Text = "";
            Dob.Text = "";
        }
        private void ClearErrorMessages()
        {
            errorLabel.InnerText = "";
        }
    }

}
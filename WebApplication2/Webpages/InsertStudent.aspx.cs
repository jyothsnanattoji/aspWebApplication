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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Clear form fields and error messages
                ClearFormFields();
                ClearErrorMessages();

                // Store the current page state
                ViewState["PageState"] = "Initial";
            }

            // Clear form fields and error messages if the form was submitted successfully
            if (ViewState["PageState"] != null && ViewState["PageState"].ToString() == "Submitted")
            {
                ClearFormFields();
                ClearErrorMessages();
                ViewState["PageState"] = "Initial";
            }

            // Handle the reload button click
            string eventTarget = Request["_EVENTTARGET"];
            if (eventTarget == "reloadPage")
            {
                ClearFormFields();
                ClearErrorMessages();
                ViewState["PageState"] = "Initial";

                //Response.Redirect(Request.RawUrl);
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            ClearErrorMessages();
            // Update the page state
            
            List<string> errors = new List<string>();
            Student student = new Student();
            if(string.IsNullOrEmpty(Id.Value))
            {
                errors.Add("All the fields are a reuired field");
            }
            else if(string.IsNullOrEmpty(Marks.Value))
            {
                errors.Add("All the fields are a reuired field");
            }
            else
            {
                student.id = Convert.ToInt32(Id.Value);
                student.Marks = Convert.ToInt32(Marks.Value);
                student.FirstName = FirstName.Value;
                student.LastName = LastName.Value;
                student.Dob = (Dob.Value);
                student.FatherName = FatherNme.Value;
                student.MotherName = MotherName.Value;
                student.Address = Address.Value;
                student.Mobile = Mobile.Value;
                StudentValidator validator = new StudentValidator(student);
                errors = validator.validate();
            }
            if (errors.Count == 0)
            {
                string conn = ConfigurationManager.ConnectionStrings["dbcs"].ToString();
                StudentRepository studentrepo = new StudentRepository(conn);
                if(!studentrepo.SearchById(student.id) && !studentrepo.SearchByMobile(student.Mobile))
                {
                    ViewState["PageState"] = "Submitted";
                    studentrepo.AddStudent(student);
                    ClearFormFields();
                    ClearErrorMessages();
                }
                else
                {
                    errorLabel.InnerText += "Student with this Id or Phone number already exists" + Environment.NewLine;
                }
            }
            else
            {
                foreach (var i in errors)
                {
                    errorLabel.InnerText    += i + Environment.NewLine;
                }
            }
            ViewState["PageState"] = "Initial";
        }

        private void ClearFormFields()
        {
            Id.Value = "";
            FirstName.Value = "";
            LastName.Value = "";
            FatherNme.Value = "";
            MotherName.Value = "";
            Address.Value = "";
            Mobile.Value = "";
            Marks.Value = "";
            Dob.Value = "";
        }

        private void ClearErrorMessages()
        {
            errorLabel.InnerText = "";
        }
    }
}
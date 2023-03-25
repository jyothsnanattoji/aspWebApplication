using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class StudentValidator : Validator
    {
        Student student;
        List<string> errorMessage;
        private string defaultString="Please enter the Student ";
        //constructor
        public  StudentValidator(Student stu)
        {
            this.student = stu;
            this.errorMessage = new List<String>();
        }
        
        public List<string> validate()
        {

            if (string.IsNullOrEmpty(student.id.ToString()))
                errorMessage.Add("ID is required.");
            if (string.IsNullOrEmpty(student.FirstName) || string.IsNullOrEmpty(student.LastName))
                errorMessage.Add("Both First and Last Name are required.");
            if (string.IsNullOrEmpty(student.Dob) || !CheckDob(student.Dob))
                errorMessage.Add("DOB in the format dd/mm/yyyy is required. and age must be above 17");
            if (string.IsNullOrEmpty(student.FatherName) || string.IsNullOrEmpty(student.MotherName))
                errorMessage.Add("Both Father and Mother Name are required.");
            if (string.IsNullOrEmpty(student.Address))
                errorMessage.Add("Address is required.");
            if (string.IsNullOrEmpty(student.Mobile) || !CheckPhone(student.Mobile))
                errorMessage.Add("Phone number must be an integer and have 10 digits.");
            if (!CheckMarks(student.Marks))
                errorMessage.Add("Marks must be between 200 and 500.");

            return errorMessage;
        }
    }
}
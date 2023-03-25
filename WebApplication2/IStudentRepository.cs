using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2
{
    public interface IStudentRepository
    {
        bool SearchById(int id);
        bool SearchByMobile(string mobile);
        void AddStudent(Student student);
        List<Student> GetStudentById(int id);
        List<Student> GetSTudentByName(string name);
        List<Student> GetAllStudent();

    }
}

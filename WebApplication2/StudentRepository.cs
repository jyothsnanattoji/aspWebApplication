using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
namespace WebApplication2
{
    public class StudentRepository : IStudentRepository
    {
        private readonly String connectionString;
        public StudentRepository(String connectionString)
        {
            this.connectionString = connectionString;
        }
        public bool SearchById(int id)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                string query = "SELECT 1 FROM STUDENT WHERE Id=@id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                object result = command.ExecuteScalar();
                connection.Close();
                return result != null;
        }
        public bool SearchByMobile(string mobile)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "SELECT COUNT(*) FROM STUDENT WHERE Mobile=@mobile";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@mobile", mobile);
            int count = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return count != 1;
        }
        public void AddStudent(Student student)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "INSERT into Student (Id,FirstName,LastName,Dob,FatherName ,MotherName ,Address,Mobile,Marks) values(@Id,@FirstName,@LastName,@Dob,@FatherName ,@MotherName ,@Address,@Mobile,@Marks)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", student.id);
                command.Parameters.AddWithValue("@FirstName", student.FirstName);
                command.Parameters.AddWithValue("@LastName", student.LastName);
                command.Parameters.AddWithValue("@Dob", student.Dob);
                command.Parameters.AddWithValue("@FatherName", student.FatherName);
                command.Parameters.AddWithValue("@MotherName", student.MotherName);
                command.Parameters.AddWithValue("@Address", student.Address);
                command.Parameters.AddWithValue("@Mobile", student.Mobile);
                command.Parameters.AddWithValue("@Marks", student.Marks);
                command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                connection.Close();
            }
        }
        public List<Student> GetAllStudent()
        {
            List<Student> students = new List<Student>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "SELECT * FROM Student";
                MySqlCommand command = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Student student = new Student();
                        student.id = Convert.ToInt32(reader["Id"]);
                        student.FirstName = reader["FirstName"].ToString();
                        student.LastName = reader["LastName"].ToString();
                        student.Dob = (reader["Dob"].ToString());
                        student.FatherName = reader["FatherName"].ToString();
                        student.MotherName = reader["MotherName"].ToString();
                        student.Address = reader["Address"].ToString();
                        student.Mobile = reader["Mobile"].ToString();
                        student.Marks = Convert.ToInt32(reader["Marks"]);
                        students.Add(student);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                connection.Close();
            }
            return students;
        }

        public List<Student> GetStudentById(int id)
        {
            List<Student> students = new List<Student>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "SELECT * FROM Student WHERE Id=@Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Student student = new Student();
                        student.id = Convert.ToInt32(reader["Id"]);
                        student.FirstName = reader["FirstName"].ToString();
                        student.LastName = reader["LastName"].ToString();
                        student.Dob = (reader["Dob"].ToString());
                        student.FatherName = reader["FatherName"].ToString();
                        student.MotherName = reader["MotherName"].ToString();
                        student.Address = reader["Address"].ToString();
                        student.Mobile = reader["Mobile"].ToString();
                        student.Marks = Convert.ToInt32(reader["Marks"]);
                        students.Add(student);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                connection.Close();
            }
            return students;
        }


        public List<Student> GetSTudentByName(string name)
        {
            List<Student> students = new List<Student>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "SELECT * FROM Student WHERE FirstName=@name";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", name);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Student student = new Student();
                        student.id = Convert.ToInt32(reader["Id"]);
                        student.FirstName = reader["FirstName"].ToString();
                        student.LastName = reader["LastName"].ToString();
                        student.Dob = (reader["Dob"].ToString());
                        student.FatherName = reader["FatherName"].ToString();
                        student.MotherName = reader["MotherName"].ToString();
                        student.Address = reader["Address"].ToString();
                        student.Mobile = reader["Mobile"].ToString();
                        student.Marks = Convert.ToInt32(reader["Marks"]);
                        students.Add(student);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                connection.Close();
            }
            return students;
        }
    }
}
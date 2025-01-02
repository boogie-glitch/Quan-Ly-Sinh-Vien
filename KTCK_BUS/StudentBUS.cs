using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KTCK_DAL.EntitiesDB;
using KTCK_DAL.DTO;
using KTCK_DAL;

namespace KTCK_BUS
{
    public class StudentBUS
    {
        StudentDAL studentDAL = new StudentDAL();
        public StudentBUS() { }
        public List<Student> GetList()
        {
            return studentDAL.GetList();
        }
        public Student GetStudent(string id)
        {
            return studentDAL.GetStudent(id);
        }
        public void AddStudent(Student student)
        {
            studentDAL.AddStudent(student);
        }
        public void UpdateStudent(Student student)
        {
            studentDAL.UpdateStudent(student);
        }
        public void DeleteStudent(string id)
        {
            studentDAL.DeleteStudent(id);
        }
        public List<StudentDTO> GetListByCourse(string courseID)
        {
            return studentDAL.GetListByCourse(courseID);
        }

    }
}

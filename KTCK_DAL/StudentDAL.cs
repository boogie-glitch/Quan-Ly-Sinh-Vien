using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KTCK_DAL.EntitiesDB;

namespace KTCK_DAL
{
    public class StudentDAL
    {
        QLKHModelDB context = new QLKHModelDB();
        public StudentDAL() { }
        public List<Student> GetList()
        {
            return context.Students.ToList();
        }
        public Student GetStudent(string id)
        {
            return context.Students.Find(id);
        }
        public void AddStudent(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }
        public void UpdateStudent(Student student)
        {
            Student s = GetStudent(student.StudentID);
            s.StudentName = student.StudentName;
            s.CourseID = student.CourseID;
            context.SaveChanges();
        }
        public void DeleteStudent(string id)
        {
            Student s = GetStudent(id);
            context.Students.Remove(s);
            context.SaveChanges();
        }
        public List<Student> GetListByCourse(string courseID)
        {
            return context.Students.Where(s => s.CourseID == courseID).ToList();
        }
    }
}

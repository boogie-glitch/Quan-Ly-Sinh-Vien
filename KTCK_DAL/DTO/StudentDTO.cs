using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KTCK_DAL.EntitiesDB;

namespace KTCK_DAL.DTO
{
    public class StudentDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string CourseID { get; set; }

        public StudentDTO() { }
        public StudentDTO(string id, string name, DateTime? dateOfBirth, string courseID)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            CourseID = courseID;
        }
        public StudentDTO(Student student)
        {
            Id = student.StudentID;
            Name = student.StudentName;
            DateOfBirth = student.DateOfBirth;
            CourseID = student.CourseID;
        }

    }
}

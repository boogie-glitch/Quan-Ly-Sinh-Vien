using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KTCK_DAL.EntitiesDB;

namespace KTCK_DAL
{
    public class CourseDAL
    {
        QLKHModelDB QLKHModelDB = new QLKHModelDB();
        public CourseDAL() { }
        public List<Cours> GetList()
        {
            return QLKHModelDB.Courses.ToList();
        }
        public Cours GetCours(string id)
        {
            return QLKHModelDB.Courses.Find(id);
        }
        public void AddCours(Cours cours)
        {
            QLKHModelDB.Courses.Add(cours);
            QLKHModelDB.SaveChanges();
        }
        public void UpdateCours(Cours cours)
        {
            Cours c = GetCours(cours.CourseID);
            c.CourseName = cours.CourseName;
            QLKHModelDB.SaveChanges();
        }
        public void DeleteCours(string id)
        {
            Cours c = GetCours(id);
            QLKHModelDB.Courses.Remove(c);
            QLKHModelDB.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KTCK_DAL.EntitiesDB;
using KTCK_DAL;

namespace KTCK_BUS
{
    public class CourseBUS
    {
        CourseDAL courseDAL = new CourseDAL();
        public CourseBUS() { }
        public List<Cours> GetList()
        {
            return courseDAL.GetList();
        }
        public Cours GetCours(string id)
        {
            return courseDAL.GetCours(id);
        }
        public void AddCours(Cours cours)
        {
            courseDAL.AddCours(cours);
        }
        public void UpdateCours(Cours cours)
        {
            courseDAL.UpdateCours(cours);
        }
        public void DeleteCours(string id)
        {
            courseDAL.DeleteCours(id);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KTCK_DAL.EntitiesDB;

namespace KTCK_DAL
{
    public class UserDAL
    {
        QLKHModelDB db = new QLKHModelDB();
        public UserDAL() { }
        public User GetUser(string username)
        {
            return db.Users.Where(u => u.Username == username).FirstOrDefault();
        }
        public void AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
        public void UpdateUser(User user)
        {
            User userUpdate = db.Users.Find(user.Username);
            userUpdate.HashedPassword = user.HashedPassword;
            db.SaveChanges();
        }
        public void DeleteUser(User user)
        {
            User userDelete = db.Users.Find(user.Username);
            db.Users.Remove(userDelete);
            db.SaveChanges();
        }
        public string GetPassword(string username)
        {
            return db.Users.Where(u => u.Username == username).FirstOrDefault().HashedPassword;
        }
    }
}

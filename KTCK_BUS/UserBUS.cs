using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KTCK_DAL.EntitiesDB;
using KTCK_DAL;

namespace KTCK_BUS
{
    public class UserBUS
    {
        UserDAL userDAL = new UserDAL();
        public UserBUS() { }
        public User GetUser(string username)
        {
            return userDAL.GetUser(username);
        }
        public void AddUser(User user)
        {
            userDAL.AddUser(user);
        }
        public void UpdateUser(User user)
        {
            userDAL.UpdateUser(user);
        }
        public void DeleteUser(User user)
        {
            userDAL.DeleteUser(user);
        }
        public string GetPassword(string username)
        {
            return userDAL.GetPassword(username);
        }
    }
}

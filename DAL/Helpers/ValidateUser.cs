using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace DAL.Helpers
{
    public static class ValidateUser
    {
        public static User ValidateRegister(Tourist tourist, LoginData loginData)
        {
            var firstName = tourist.FirstName.ToLower();
            var secondName = tourist.SecondName.ToLower();
            var db = ContextHelper.GetContext();
            var t = db.Tourists.FirstOrDefault(x => x.FirstName.ToLower().Equals(firstName) && x.SecondName.ToLower().Equals(secondName));
            if (t != null)
            {
                throw new Exception("Tourist with such data is already in the database!");
            }
            else
            {
                UserRole userRole = db.UserRoles.FirstOrDefault(x => x.Name.Equals("User"));
                User u = new User() { LoginData = loginData, UserRole = userRole };
                tourist.User = u;
                db.Tourists.Add(tourist);
                db.SaveChanges();
                return u;
            }
        }
        public static Tourist ValidateLogin(LoginData loginData)
        {
            var db = ContextHelper.GetContext();
            var ld = db.LoginDatas.FirstOrDefault(x =>
            x.Login.ToLower().Equals(loginData.Login.ToLower()) &&
            x.Password.ToLower().Equals(loginData.Password.ToLower()));
            if (ld == null)
            {
                throw new Exception("Invalid login data");
            }
            else
            {
                var user = ld.Users.FirstOrDefault();
                var tourist = user.Tourists.FirstOrDefault();
                return tourist;
            }
        }
    }
}

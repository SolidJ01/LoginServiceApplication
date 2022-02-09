using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LoginServiceApplication
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class LoginService : ILoginService
    {
        public bool LoginUser(string email, string password)
        {
            using (DataModel db = new DataModel())
            {
                User user = db.Users.Where(m => m.Email == email).FirstOrDefault();
                if (user != null && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public bool LoginHost(string email, string password)
        {
            using (DataModel db = new DataModel())
            {
                Host host = db.Hosts.Where(m => m.Email == email).FirstOrDefault();
                if (host != null && host.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public bool LoginAdmin(string username, string password)
        {
            using (DataModel db = new DataModel())
            {
                Admin admin = db.Admins.Where(m => m.Username == username).FirstOrDefault();
                if (admin != null && admin.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CreateUser(string email, string password)
        {
            using (DataModel db = new DataModel())
            {
                User user = db.Users.Where(m => m.Email == email).FirstOrDefault();
                if (user == null)
                {
                    User newUser = new User();
                    newUser.Email = email;
                    newUser.Password = password;

                    db.Users.Add(newUser);
                    db.SaveChanges();

                    return true;
                }
            }
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QandA.Db;

namespace QandA.Methods
{
    public class UserRepository
    {
        readonly QandAEntities db;
        public UserRepository(QandAEntities db)
        {
            this.db = db;
        }

        public UserEx GetUser(int Id)
        {
            var r = db.Users.Where(c => c.Id == Id).FirstOrDefault();
            return Transform(r);

        }
        public void Save(UserEx n)
        {
            var t = Transform(n);
            if (t.CookieValue == null)
            {
                db.Users.Add(t);
            }
            db.SaveChanges();
            n.Id = t.Id;
        }

        public List<UserEx> Transform(IQueryable<User> n)
        {
            List<UserEx> aReturn = new List<UserEx>();
            foreach (var r in n)
            {
                aReturn.Add(Transform(r));
            }
            return aReturn;
        }

        public UserEx Transform(User n)
        {
            UserEx r = new UserEx();
            r.Id = n.Id;
            r.CookieValue = n.CookieValue;
            r.Name = n.Name;
           

            return r;
        }
        public User Transform(UserEx n)
        {
            User r;
            if (n.CookieValue  != null)
            {
                r = db.Users.Where(o => o.CookieValue == n.CookieValue).FirstOrDefault();
            }
            else
            {
                r = db.Users.Create();
            }

            r.CookieValue = n.CookieValue;
            r.Name = n.Name;

            return r;
        }
    }
}
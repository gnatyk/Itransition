using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Itransition.Models;

namespace Itransition.My
{
    public class GlobalRepository
    {
        private GlobalDbContext db;

        public GlobalRepository()
        {
            db = new GlobalDbContext();
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return db.Users;
        }

        public ApplicationUser GetUser(string id)
        {
            return db.Users.FirstOrDefault(a => a.Id == id);
        }

        public ApplicationUser FindUserByEmail(string email)
        {
            return db.Users.SingleOrDefault(a => a.Email == email);
        }
    }
}
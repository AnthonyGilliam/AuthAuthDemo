using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthAuthDemo.Domain;

namespace AuthAuthDemo.Repositories
{
    public class UserRepository
    {
        public void UpdateUser(User user)
        {
            using (var dbContext = new UserContext())
            {
                var domainObject = dbContext.Users.SingleOrDefault(usr => usr.EmailAddress == user.EmailAddress);

                domainObject.FirstName = user.FirstName;
                domainObject.LastName = user.LastName;
                dbContext.SaveChanges();
            }
        }

        public User[] GetAllUsers()
        {
            using (var dbContext = new UserContext())
            {
                return dbContext.Users.ToArray();
            }
        }

        public Membership GetUserMembership(int userId)
        {
            using (var dbContext = new UserContext())
            {
                return dbContext.UserMemberships.SingleOrDefault(membership => membership.UserId == userId);
            }
        }
    }
}

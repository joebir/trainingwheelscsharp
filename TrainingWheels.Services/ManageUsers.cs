using TrainingWheels.Data;
using TrainingWheels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace TrainingWheels.Services
{
    public class ManageUsers
    {

        public ManageUsers()
        {

        }

        public IEnumerable<UsersListItem> GetUsers()
        {   
            using(var context = new ApplicationDbContext())
            {
                var query = context.Users.Select(
                    e => new UsersListItem
                    {
                        UserId = e.Id,
                        Email = e.Email,
                        UserName = e.UserName
                    }
                );

                return query.ToArray();
            }

        }
    }
}
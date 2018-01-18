using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingWheels.Contracts;
using TrainingWheels.Data;
using TrainingWheels.Models;

namespace TrainingWheels.Services
{
    public class NotespaceService : INotespaceService
    {
        private readonly string _userId;

        public NotespaceService(string userId)
        {
            _userId = userId;
        }

        public NotespaceModel GetUser()
        {
            ApplicationUser user;

            using (var ctx = new ApplicationDbContext())
            {
                user = GetUser(ctx);
            }

            if (user == null) return new NotespaceModel();

            return
                new NotespaceModel()
                {
                    Id = _userId,
                    Note = user.Note
                };
        }

        public ApplicationUser GetUser(ApplicationDbContext context)
        {
            return
                context
                    .Users
                    .SingleOrDefault(e => e.Id == _userId);
        }


        public bool UpdateNotespace(NotespaceModel model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var user =
                    ctx
                        .Users
                        .SingleOrDefault(e => e.Id == model.Id);

                if (user == null) return false;

                user.Note = model.Note;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

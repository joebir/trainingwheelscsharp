using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingWheels.Data;
using TrainingWheels.Models;

namespace TrainingWheels.Contracts
{
    public interface INotespaceService
    {
        NotespaceModel GetUser();
        ApplicationUser GetUser(ApplicationDbContext applicationDbContext);
        bool UpdateNotespace(NotespaceModel notespaceModel);
    }
}

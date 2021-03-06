using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoothackForum.Data
{
    public interface IApplicationUser
    {
        ApplicationUser GetById(string id);
        IEnumerable<ApplicationUser> GetAll();

        Task SetProfileImage(string id, Uri uri);
        Task IncrementRating(string id, Type type);
    }
}

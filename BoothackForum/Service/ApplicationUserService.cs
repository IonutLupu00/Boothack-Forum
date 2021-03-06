using BoothackForum.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoothackForum.Service
{
    public class ApplicationUserService : IApplicationUser
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserService(ApplicationDbContext context)
        {
            _context = context;
        }

       public IEnumerable<ApplicationUser> GetAll()
        {
            return _context.ApplicationUsers;
        }

       public ApplicationUser GetById(string id)
        {
           return GetAll().FirstOrDefault(user => user.Id == id);
        }



        Task IApplicationUser.IncrementRating(string id, Type type)
        {
            throw new NotImplementedException();
        }

        async Task IApplicationUser.SetProfileImage(string id, Uri uri)
        {
            var user = GetById(id);
            user.Photo = uri.AbsoluteUri;
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

    }
}

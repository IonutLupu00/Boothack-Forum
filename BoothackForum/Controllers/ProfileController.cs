using BoothackForum.Data;
using BoothackForum.Models.ApplicationUserModel;
using BoothackForum.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BoothackForum.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUser _userService;
        private readonly IUpload _uploadService;
        

        public ProfileController(UserManager<ApplicationUser> userManager, IApplicationUser userService, IUpload uploadService)
        {
            _userManager = userManager;
            _userService = userService;
            _uploadService = uploadService;
        }



        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var users = _userService.GetAll();
            var profileListings = users.Select(forumUser => new ProfileModel
            {
                UserId = forumUser.Id,
                UserName = forumUser.UserName,
                Email = forumUser.Email,
                UserRating = forumUser.Rating,
                ProfileImageURL = forumUser.Photo,
                IsAdmin = forumUser.IsAdmin,
                MemberSince = forumUser.Created
            });

            var model = new ProfileListingModel
            {
                Profiles = profileListings
            };

            return View(model);
        }
        public IActionResult Detail(string id)
        {
            var user = _userService.GetById(id);

            var userRoles = _userManager.GetRolesAsync(user).Result;

            var model = new ProfileModel { 
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                UserRating = user.Rating,
                ProfileImageURL = user.Photo ?? "/images/users/default.jpg",
                IsAdmin = userRoles.Contains("Admin"),
                MemberSince = user.Created

            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UploadProfileImage(ProfileModel model)
        {
            ApplicationUser applicationUser = await _userManager.GetUserAsync(User);
            var image = model.ImageUpload;

            if (!string.IsNullOrEmpty(applicationUser.Photo) && image != null)
                await _uploadService.DeleteImage(applicationUser.Id);

            if (image != null)
                await _uploadService.UploadImage(applicationUser.Id, image);

            return RedirectToAction("Detail", "Profile", new {id = applicationUser.Id });
        }


    }
  
}

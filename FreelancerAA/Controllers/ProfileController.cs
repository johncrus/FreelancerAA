using FreelancerAA.Models.ProfileViewModels;
using FreelancerData;
using FreelancerData.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using System.Web;


namespace FreelancerAA.Controllers
{
    public class ProfileController:Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private IFreelancerApplicationUser _users;



        public ProfileController(
          UserManager<ApplicationUser> userManager,
          IFreelancerApplicationUser users
          )
        {
            _userManager = userManager;
            _users = users;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var model = new ProfileViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber=user.PhoneNumber,
                Email=user.Email,
                DateOfBirth=user.DateOfBirth,
                IsEmailConfirmed = user.EmailConfirmed,
                HiringExperience = user.HiringExperience,
                JobExperience = user.Jobexperience,
                Address = user.Address,
                Skills = user.Skills,
                DateOfJoining = user.DateOfJoining,
                UserPhoto = user.UserPhoto


            };
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Index(ProfileViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);

            
             await _users.SetUserPhoto(user.Id, "/images/" + model.UserPhoto + ".png");
            return RedirectToAction(nameof(Index));

        }


        [HttpGet]
        public IActionResult Detail(string id)
        {
            var user = _users.GetById(id);
            var model = new ProfileViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                DateOfBirth=user.DateOfBirth,
                IsEmailConfirmed = user.EmailConfirmed,
                HiringExperience = user.HiringExperience,
                JobExperience = user.Jobexperience,
                Address= user.Address,
                Skills= user.Skills,
                DateOfJoining=user.DateOfJoining,
                UserPhoto=user.UserPhoto

            };
            return View(model);

        }
    }
}

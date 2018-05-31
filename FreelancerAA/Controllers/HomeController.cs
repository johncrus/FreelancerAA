using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FreelancerAA.Models;
using FreelancerData;
using Microsoft.AspNetCore.Identity;
using FreelancerData.Models;
using System.Linq;
using FreelancerData.Migrations;
using FreelancerAA.Models.HomeViewModels;
using System.Collections.Generic;

namespace FreelancerAA.Controllers
{
    public class HomeController : Controller
    {

        private IFreelancerJob _jobs;
        private IFreelancerApplicationUser _users;
        private IFreelancerJobAppliance _jobapps;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public HomeController(
            IFreelancerJob jobs,
            IFreelancerApplicationUser users,
            IFreelancerJobAppliance jobapps,
            SignInManager<ApplicationUser> signInManager

            )
        {
            _jobs = jobs;
            _jobapps = jobapps;
            _users = users;
            _signInManager = signInManager;
        }
        [HttpPost]
        public IActionResult Index(HomeIndexViewModel model)
        {

            return RedirectToAction("SearchJob", "JobList", new { item=model.SearchedString });
        }
        [HttpGet]
        public IActionResult Index()
        {
            var boostupJobModels = _jobs.GetAll().Where(j => j.Status == "1");
            var boostupJobModelsOrdered = boostupJobModels.OrderByDescending(bjm => bjm.Boostup);

            var listingResult = boostupJobModelsOrdered
                .Select(result => new HomeBoostupListingModel
                {
                    JobId=result.Id,
                    JobOfferer=result.ApplicationUser.FirstName + " "+ result.ApplicationUser.LastName,
                    JobTitle= result.Title,
                    Description =result.Description,
                    Price =result.Price,
                    RequiredSkills=result.RequiredSkills

                });
            var topUsers = _users.GetTopUsers();
            var model = new HomeIndexViewModel()
            {
                BoostedJobs = listingResult,
                BCount=EnumCount(listingResult),
                TopUsers=topUsers
            };
            return View(model);
        }

        public int EnumCount(IEnumerable<HomeBoostupListingModel> jobs)
        {
            int count = 0;
            if (!jobs.Any())
                return 0;
            foreach (var e in jobs)
            {
                count++;
            }
            return count;
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

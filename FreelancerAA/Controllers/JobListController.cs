using Freelancer.Models.JobList;
using FreelancerAA.Models.AccountViewModels;
using FreelancerAA.Models.JobList;
using FreelancerData;
using FreelancerData.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerAA.Controllers
{
    public class JobListController : Controller
    {
        private IFreelancerJob _jobs;
        private IFreelancerApplicationUser _users;
        private IFreelancerJobAppliance _jobapps;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public JobListController(
            IFreelancerJob jobs, 
            IFreelancerApplicationUser users,
            IFreelancerJobAppliance jobapps,
        UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
            
            )
        {
            _jobs = jobs;
            _jobapps = jobapps;
            _users = users;
            _userManager = userManager;
            _signInManager = signInManager;
        }

       
        
        public async Task<IActionResult> Index()
        {
            var jobModels = _jobs.GetAll().Where(j => j.Status == "1");
            var user = await _userManager.GetUserAsync(User);
            var EC = true;
            if (user == null)
            {
                EC = false;
            }
            else
            {
                EC = user.EmailConfirmed;
            }

            var listingResult = jobModels
                .Select(result => new JobIndexListingModel
                {
                    Id = result.Id,
                    Title = result.Title,
                    Description = result.Description,
                    Price = result.Price,
                    DateCreated = result.DateCreated,
                    DateExpire=result.DateExpire,
                    User = result.ApplicationUser
                    
                });
            var model = new JobIndexModel()
            {
                Jobs = listingResult,
                IsEmailConfirmed=EC
            };
            return View(model);
        }


        public IActionResult BoostUp(int id)
        {
            _jobs.Boost(id);
            return RedirectToAction("MyJobs", "JobList");
        }


        public async Task<IActionResult> JobInProgress(int id)
        {
            var job = _jobs.GetById(id);
            var user = await _userManager.GetUserAsync(User);
           
            
            var model = new JobDetailModel
            {
                JobId = id,
                Title = job.Title,
                Description = job.Description,
                Price = job.Price,
                Status = job.Status,
                DateCreated = job.DateCreated,
                DateExpire = job.DateExpire,
                RequiredSkills=job.RequiredSkills,
                User = job.ApplicationUser,
                CurrentUser = user,
                Employer=job.Employer
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(JobIndexModel model)
        {

            return RedirectToAction("SearchJob", "JobList", new { item = model.SearchedString });
        }
        [HttpPost]
        public IActionResult Detail(int id, int userprice)
        {

            return RedirectToAction("ApplyForJob", "JobList", new { jobid= id, userprice });
        }

        [HttpPost]
        public IActionResult Detail(int id, string hiredEmploeeId, int price)
        {

            _jobs.SetEmployer(id, _users.GetById(hiredEmploeeId));

            _jobs.SetPrice(id, price);
           

            return RedirectToAction("JobInProgress", "JobList", new { jobid = id });
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var job = _jobs.GetById(id);
            var user = await _userManager.GetUserAsync(User);
            var EC = false;
            if (user != null)
            {
                EC = user.EmailConfirmed;
            }
            var ThisJobAppliances = _jobapps.GetThisJobAppliances(id);
            var AlreadyAppliedThis = false;
           foreach (var applicant in ThisJobAppliances)
            {
                if (applicant.AppliedBy == user)
                    AlreadyAppliedThis = true;
            }
            var model = new JobDetailModel
            {
                JobId = id,
                Title = job.Title,
                Description = job.Description,
                Price = job.Price,
                Status = job.Status,
                DateCreated = job.DateCreated,
                DateExpire=job.DateExpire,
                ListOfAppliances= ThisJobAppliances,
                User = job.ApplicationUser,
                IsEmailConfirmed= EC,
                AlreadyApplied=AlreadyAppliedThis,
                CurrentUser=user
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult CreateJob(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateJob(CreateJobViewModel model, string returnUrl = null)
        {

            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                if (user==null)
                    return RedirectToAction("Index","Home");
                if(!user.EmailConfirmed)
                    return RedirectToAction("Index", "Manage");
                var userId = user?.Id;
                var j = new Job { Title = model.Title, Description = model.Description, Price = model.Price, DateCreated = DateTime.Now,DateExpire=DateTime.Now.AddDays(10), Status = "1",ApplicationUser=_users.GetById(userId),RequiredSkills=model.RequiredSkills };
                _jobs.Add(j);
                return RedirectToAction("Detail", new { id = j.Id });
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        public async Task<IActionResult> ApplyForJob(int jobid,int userprice)
        {
            
            var user = await GetCurrentUserAsync();
            if (_jobapps.GetThisUserAppliances(user).Any(j => j.JobId == jobid))
            {
                _jobapps.SetMyPrice(_jobapps.GetThisUserAppliances(user).FirstOrDefault(j => j.JobId == jobid).Id, userprice);
                return RedirectToAction("Detail", new { id = jobid });
            }
            var date = DateTime.Now;
            var jobappliance = new JobAppliance {DateCreated=date,AppliedBy=user,JobId= jobid, MyPrice= userprice,Status="1" };
            _jobapps.Add(jobappliance);
            
            
            return RedirectToAction("Detail", new { id=jobid });
        }
        public async Task<IActionResult> AppliedJobs()
        {
            var user = await GetCurrentUserAsync();

            var jobAppliancesModels = _jobapps.GetThisUserAppliances(user);

            var listingResult = jobAppliancesModels
                .Select(result => new JobApplianceViewModel
                {
                    AppId=result.Id,
                    JobTitle = _jobs.GetById(result.JobId).Title,
                    JobOfferer = _jobs.GetJobOffererFullName(result.JobId),
                    JobId = result.JobId,
                    JobOffererHiringExperience=_jobs.GetById(result.JobId).ApplicationUser.HiringExperience,
                    JobOffererId=_jobs.GetById(result.JobId).ApplicationUser.Id,
                    DateApplied = result.DateCreated,
                    Status=result.Status
                    
                });
            var model = new JobAppliancesListingViewModel()
            {
                Visited = false,
                JobsAppliedTo=listingResult

            };
            return View(model);
        }
        public async Task<IActionResult> MyJobs()
        {
            var user = await GetCurrentUserAsync();

            var myJobsModels = _jobs.GetThisUserCreatedJobs(user);

            var listingResult = myJobsModels
                .Select(result => new JobMyJobsListingModel()
                {
                   JobId=result.Id,
                   Title=result.Title,
                   Status=result.Status,
                   DateCreated=result.DateCreated,
                   DateExpire=result.DateExpire

                });
            var model = new JobMyJobViewModel()
            {
                MyJobs = listingResult

            };
            return View(model);
        }
        public IActionResult QuitAppliedJob(int id)
        {
            _jobapps.Remove(id);
            return RedirectToAction("AppliedJobs");
        }
        public IActionResult DeleteJob(int id)
        {
            _jobs.DeleteJob(id);
            return RedirectToAction("MyJobs");
        }
        [HttpGet]
        public IActionResult SearchJob(string item)
        {
            var jobModels = _jobs.GetAll().Where(j => j.Status == "1" &&(j.Title.ToLower().Contains(item) || j.Description.ToLower().Contains(item)));
            var listingResult = jobModels
                .Select(result => new JobIndexListingModel
                {
                    Id = result.Id,
                    Title = result.Title,
                    Description = result.Description,
                    Price = result.Price,
                    DateCreated = result.DateCreated,
                    DateExpire = result.DateExpire,
                    User = result.ApplicationUser

                });
            var model = new JobIndexModel()
            {
                Jobs = listingResult,
                SearchedString=item
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult SearchJob(JobIndexModel model)
        {
            return RedirectToAction("SearchJob", "JobList", new { item = model.SearchedString });
        }


    }
}

using FreelancerData;
using FreelancerData.Migrations;
using FreelancerData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FreelancerService
{
    public class FreelancerJobService : IFreelancerJob
    {
        private FreelancerContext _context;

        public FreelancerJobService(FreelancerContext context)
        {
            _context = context;
        }
        public void Add(Job newJob)
        {
            _context.Add(newJob);
            _context.SaveChanges();
        }

        public void Boost(int id)
        {
            if (GetById(id).ApplicationUser.Currency < 1)
                return;
            if (GetById(id).Boostup < DateTime.Now)
                GetById(id).Boostup = DateTime.Now.AddDays(1);
            else
                GetById(id).Boostup.AddDays(1);
            GetById(id).ApplicationUser.Currency += -1;
            _context.SaveChanges();
        }

        public void DeleteJob(int id)
        {
            if (GetById(id).Status != "1")
                return;
            _context.Remove(GetById(id));
            foreach(var jobappliance in _context.JobAppliances.Where(ja => ja.JobId == id))
            {
                _context.Remove(jobappliance);
            }
            _context.SaveChanges();
        }

        public IEnumerable<Job> GetAll()
        {
            return _context.Jobs
                .Include(j => j.ApplicationUser).Include(u=>u.Employer);
        }

        public Job GetById(int id)
        {
            return GetAll()
               .FirstOrDefault(j => j.Id == id);
        }

        public DateTime GetDateTime(int id)
        {
            return GetById(id).DateCreated;
        }

        public string GetDescription(int id)
        {
            return GetById(id).Description;
        }

        public string GetJobOffererFullName(int id)
        {
            return GetById(id).ApplicationUser.FirstName + " " + GetById(id).ApplicationUser.LastName;
        }

        public int GetPrice(int id)
        {
            return GetById(id).Price;
        }

        public string GetStatus(int id)
        {
            return GetById(id).Status;
        }

        public IEnumerable<Job> GetThisUserCreatedJobs(ApplicationUser user)
        {
            return GetAll().Where(j => j.ApplicationUser.Id == user.Id);
        }

        public string GetTitle(int id)
        {
            return GetById(id).Title;
        }

        public ApplicationUser GetUser(int id)
        {
            return GetById(id).ApplicationUser;
        }

        public void SetEmployer(int id, ApplicationUser user)
        {
            GetById(id).Employer = user;
            _context.SaveChanges();
        }

        public void SetPrice(int id, int value)
        {
            GetById(id).Price = value;
            _context.SaveChanges();
        }

        public void SetStatusInProgress(int id)
        {
            GetById(id).Status = "2";
            _context.SaveChanges();
        }
    }
}

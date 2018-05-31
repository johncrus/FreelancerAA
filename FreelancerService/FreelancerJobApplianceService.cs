using FreelancerData;
using FreelancerData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;

namespace FreelancerService
{
    public class FreelancerJobApplianceService : IFreelancerJobAppliance
    {
        private FreelancerContext _context;
        private IFreelancerJob _jobs;
        public FreelancerJobApplianceService (FreelancerContext context, IFreelancerJob job)
        {
            _context = context;
            _jobs = job;
        }
        public void Add(JobAppliance newJobAppliance)
        {
            _context.Add(newJobAppliance);
            _context.SaveChanges();
        }

        public JobAppliance GetById(int id)
        {
            
                return _context.JobAppliances.Include(u=>u.AppliedBy)
                   .FirstOrDefault(j => j.Id == id);
            
        }

        public DateTime GetDateCreated(int id)
        {
            return _context.JobAppliances
                .FirstOrDefault(i => i.Id == id)
                .DateCreated;
        }

        public string GetStatus(int id)
        {
            return GetById(id).Status;
        }

        public IEnumerable<JobAppliance> GetThisJobAppliances(int id)
        {
            return _context.JobAppliances
                .Include(ja => ja.AppliedBy)
                .Where(x => x.JobId == id);
        }

        public IEnumerable<JobAppliance> GetThisUserAppliances(ApplicationUser user)
        {
            return _context.JobAppliances.Where(u => u.AppliedBy == user);    
        }
        

        public ApplicationUser GetUser(int id)
        {
            return _context
                .JobAppliances.Include(ja => ja.AppliedBy)
                .FirstOrDefault(i => i.Id == id)
                .AppliedBy;
        }

        public void Remove(int id)
        {
            if (GetById(id).Status == "3")
                return;
            _context.Remove(GetById(id));
            _context.SaveChanges();
        }

        public void SetMyPrice(int id,int value)
        {
            GetById(id).MyPrice = value;
            _context.SaveChanges();
        }
        public void SetInProgress(int id)
        {
            _context.Jobs.FirstOrDefault(j => j.Id == GetById(id).JobId).Status = "2";
            GetById(id).Status = "3";
            foreach(var app in   GetThisJobAppliances(GetById(id).JobId).Where(j => j.Id != id))
            {
                app.Status = "2";
            }
            _context.SaveChanges();
            
        }

        public void SetComplete(int id)
        {
            _context.Jobs.FirstOrDefault(j => j.Id == id).Status = "4";
            _context.JobAppliances.FirstOrDefault(u => u.AppliedBy == _context.Jobs.FirstOrDefault(j => j.Id == id).Employer && u.JobId == id).Status = "4";
            _context.SaveChanges();
        }

        public void SetReported(int id)
        {
            _context.Jobs.FirstOrDefault(j => j.Id == id).Status = "3";
            _context.JobAppliances.FirstOrDefault(u => u.AppliedBy == _context.Jobs.FirstOrDefault(j => j.Id == id).Employer && u.JobId == id).Status = "2";
            _context.SaveChanges();
        }
    }
}

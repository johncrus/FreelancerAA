using FreelancerData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreelancerData
{
    public interface IFreelancerJobAppliance
    {
        IEnumerable<JobAppliance> GetThisJobAppliances(int id);

        void Add(JobAppliance newJobAppliance);
        void Remove(int id);
        void SetMyPrice(int id, int value);
        void SetInProgress(int id);
        void SetComplete(int id);
        void SetReported(int id);
        JobAppliance GetById(int id);
        DateTime GetDateCreated(int id);
        string GetStatus(int id);
        

        ApplicationUser GetUser(int id);
        IEnumerable<JobAppliance> GetThisUserAppliances(ApplicationUser user);
    }
}

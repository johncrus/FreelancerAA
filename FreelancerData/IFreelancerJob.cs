using FreelancerData.Models;
using System;
using System.Collections.Generic;


namespace FreelancerData
{
    public interface IFreelancerJob
    {
        IEnumerable<Job> GetAll();
        IEnumerable<Job> GetThisUserCreatedJobs(ApplicationUser user);
        Job GetById(int id);

        void Add(Job newJob);
        void DeleteJob(int id);
        void Boost(int id);
        void SetStatusInProgress(int id);
        void SetPrice(int id,int value);
        void SetEmployer(int id, ApplicationUser user);
        string GetTitle(int id);
        string GetDescription(int id);
        string GetStatus(int id);
        string GetJobOffererFullName(int id);
        int GetPrice(int id);
        DateTime GetDateTime(int id);
        ApplicationUser GetUser(int id);

    }
}
using FreelancerData.Models;
using System;

namespace Freelancer.Models.JobList
{
    public class JobIndexListingModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateExpire { get; set; }
        public ApplicationUser User { get; set; }
    }
}

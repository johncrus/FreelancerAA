using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerAA.Models.JobList
{
    public class JobMyJobsListingModel
    {
        public int JobId { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateExpire { get; set; }
    }
}

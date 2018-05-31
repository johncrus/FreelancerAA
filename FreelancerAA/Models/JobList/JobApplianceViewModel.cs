using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerAA.Models.JobList
{
    public class JobApplianceViewModel
    {
        public int AppId { get; set; }
        public int JobId { get; set; }
        public string JobOffererId { get; set; }
        public string JobTitle { get; set; }
        public string JobOfferer { get; set; }
        public string Status { get; set; }
        public int JobOffererHiringExperience { get; set; }
        public DateTime DateApplied { get; set; }
    }
}

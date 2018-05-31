using FreelancerData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerAA.Models.JobList
{
    public class JobAppliancesListingViewModel
    {
        public bool Visited { get; set; }
        public IEnumerable<JobApplianceViewModel> JobsAppliedTo { get; set; }
    }
}

using System.Collections.Generic;

namespace Freelancer.Models.JobList
{
    public class JobIndexModel
    {
        public IEnumerable<JobIndexListingModel> Jobs { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string SearchedString { get; set; }
    }
}

using FreelancerData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerAA.Models.HomeViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<HomeBoostupListingModel> BoostedJobs { get; set; }
        public int BCount { get; set; }
        public string SearchedString { get; set; }
        public IEnumerable<ApplicationUser> TopUsers { get; set; }
    }
}

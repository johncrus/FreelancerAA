using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerAA.Models.HomeViewModels
{
    public class HomeBoostupListingModel
    {   
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public string JobOfferer { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string RequiredSkills { get; set; }
        
    }
}

using FreelancerData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Models.JobList
{
    public class JobDetailModel
    {
        public int JobId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int Price { get; set; }
        public string RequiredSkills { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateExpire { get; set; }
        public ApplicationUser User { get; set; }
        public IEnumerable<JobAppliance> ListOfAppliances { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public ApplicationUser CurrentUser { get; set; }
        public ApplicationUser Employer { get; set; }
        public string EmployerId { get; set; }
        public bool AlreadyApplied { get; set; }
        [Required]
        [Range(typeof(int), "1", "9999", ErrorMessage = "{0} can only be between {1} and {2}")]
        public int UserPrice { get; set; }
    }
}

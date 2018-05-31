using System;
using System.Collections.Generic;
using System.Text;

namespace FreelancerData.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string RequiredSkills { get; set; }
        public int Price { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateExpire { get; set; }
        public DateTime Boostup { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ApplicationUser Employer { get; set; }
        
    }
}

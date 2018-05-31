using System;
using System.Collections.Generic;
using System.Text;

namespace FreelancerData.Models
{
    public class JobAppliance
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public DateTime DateCreated { get; set; }
        public ApplicationUser AppliedBy { get; set; }
        public int MyPrice { get; set; }
        public string Status { get; set; }
    }
}

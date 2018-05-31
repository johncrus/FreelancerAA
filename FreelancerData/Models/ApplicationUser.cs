using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FreelancerData.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Skills { get; set; }
        public string Address { get; set; }

        public int Currency { get; set; }
        public int HiringExperience { get; set; }
        public int Jobexperience { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoining { get; set; }
        public bool NewApplianceNotification { get; set; }
        public bool NewJobApplicantNotification { get; set; }

        public string UserPhoto { get; set; }
        
    }
}

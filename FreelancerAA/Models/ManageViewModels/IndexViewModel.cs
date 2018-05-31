using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerAA.Models.ManageViewModels
{
    public class IndexViewModel
    {
        public string Username { get; set; }
        public int HiringExperience { get; set; }
        public int JobExperience { get; set; }
        public bool IsEmailConfirmed { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        [Required]
        public string Skills { get; set; }
        [Required]
        public string Address { get; set; }

        public string StatusMessage { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerAA.Models.AccountViewModels
{
    public class CreateJobViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Title { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 10)]
        public string Description { get; set; }

        [Required]
        [Range(typeof(int), "1", "9999",ErrorMessage = "{0} can only be between {1} and {2}")]
        public int Price { get; set; }

        [Required]
        public string RequiredSkills { get; set; }
       
    }

}

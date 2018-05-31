using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerAA.Models.ManageViewModels
{
    public class AddFundsViewModel
    {
        
        [StringLength(100, ErrorMessage = "The {0} must be {1} characters long.")]
        [Display(Name = "Card Number")]
        public string CardNumber { get; set; }

        [Required]
        [Range(typeof(int), "1", "9999", ErrorMessage = "{0} can only be between {1} and {2}")]
        public int Amount { get; set; }

        public string BankAccount { get; set; }
        public int CurrentBalance { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace FreelancerAA.Models.ProfileViewModels
{
    public class ProfileViewModel
    {
        public string Username { get; set; }
        public int HiringExperience { get; set; }
        public int JobExperience { get; set; }
        public bool IsEmailConfirmed { get; set; }

        public string FirstName { get; set; }


        public string LastName { get; set; }

        public string Skills { get; set; }
        public string Address { get; set; }


        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoining { get; set; }
        



        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string UserPhoto { get; set; }


        public string StatusMessage { get; set; }

        public List<SelectListItem> Names { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "morty", Text = "Morty" },
            new SelectListItem { Value = "patrick", Text = "Patrick" },
            new SelectListItem { Value = "rick", Text = "Rick"  },
            new SelectListItem { Value = "spongebob", Text = "SpongeBob"  },
        };
    }
}

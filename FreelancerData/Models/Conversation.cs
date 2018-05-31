using System;
using System.Collections.Generic;
using System.Text;

namespace FreelancerData.Models
{
    public class Conversation
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public string OffererId { get; set; }
        public string EmployerId { get; set; }
    }
}

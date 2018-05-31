using System;
using System.Collections.Generic;
using System.Text;

namespace FreelancerData.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateReported { get; set; }
        public int JobId { get; set; }
    }
}

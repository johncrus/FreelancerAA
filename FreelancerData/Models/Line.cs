using System;
using System.Collections.Generic;
using System.Text;

namespace FreelancerData.Models
{
    public class Line
    {
        public int id { get; set; }
        public int ConversationId { get; set; }
        public string LineOwnerId { get; set; }
        public string LineContent { get; set; }
    }
}

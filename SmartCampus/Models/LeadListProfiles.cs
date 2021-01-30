using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCampus.Models
{
    public class LeadListProfiles
    {
        public int profileId { get; set; }
        public string profileName { get; set; }
        public string originType { get; set; }
        public string emailAddress { get; set; }
        public double contactNumber { get; set; }
        public string nationality { get; set; }
        public string leadScoring { get; set; }
        public string leadStatus { get; set; }
        public string profileType { get; set; }
        public DateTime registrationDate { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampusTravel.Models
{
    public class AgentViewModels
    {
        public int agentId { get; set; }
        public string agentName { get; set; }
        public int officeKey { get; set; }
        public int officeId { get; set; }
        public string officeLocation { get; set; }
        public decimal total { get; set; }
        public int numBookings { get; set; }
        public int agent { get; set; }
        public Dictionary<string, int> officeDict = new Dictionary<string, int>();

    }
}
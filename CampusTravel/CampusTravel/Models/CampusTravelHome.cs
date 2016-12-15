using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampusTravel.Models
{
    public class CampusTravelHome
    {

        public class AgentViewModel
        {
            public int agentId { get; set; }
            public string agentName { get; set; }
            public int officeKey { get; set; }
            public int officeId { get; set; }
            public string officeLocation { get; set; }
            public decimal total { get; set; }
            public int numBookings { get; set; }
            public int agent { get; set; }
        }

        public class DestinationViewModel
        {
            public int destinationId { get; set; }
            public string destinationName { get; set; }
        }

        public class SaleViewModel
        {
            public int saleId { get; set; }
            public int agentKey { get; set; }
            public decimal amount { get; set; }
            public DateTime saleDate { get; set; }
            public int destinationKey { get; set; }
            public int numSales { get; set; }
            public string agentName { get; set; }
            public string destinationName { get; set; }
            public string officeLocation { get; set; }

        }
    }

}
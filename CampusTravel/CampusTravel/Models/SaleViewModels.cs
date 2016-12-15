using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampusTravel.Models
{
    public class SaleViewModels
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
using CampusTravel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CampusTravel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AgentBookings()
        {
            CampusDB campusdb = new CampusDB();
            IEnumerable<AgentViewModels> model = campusdb.GetAgentBookings();
            return View(model);
        }

        public ActionResult AddAgent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAgent(AgentViewModels vm)
        {
            CampusDB campusdb = new CampusDB();
            campusdb.AddAgent(vm);
            return View();
        }

        public ActionResult Sale()
        {
            CampusDB campusdb = new CampusDB();
            IEnumerable<SaleViewModels> model = campusdb.GetSales();
            
            return View(model);
        }

        public ActionResult AddSale()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSale(SaleViewModels vm)
        {
            CampusDB campusdb = new CampusDB();
            campusdb.AddSale(vm);
            return View();
        }

    }
}
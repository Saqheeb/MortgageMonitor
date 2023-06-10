using Microsoft.AspNetCore.Mvc;
using MortgageMoniteringSystem.Models;
using System.Diagnostics;

namespace MortgageMoniteringSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<DashboardCard> cards = new List<DashboardCard>()
            {
                new DashboardCard() {
                    title = "User Access Control",
                    description = "This page lets you control the user's access over the application",
                    imageUrl = "/images/users.png",
                    linkUrl = "/Registers",
                },
                new DashboardCard() {
                    title = "Risk Manager Control ",
                    description = "This page lets you add or remove the Risk Manager for the application",
                    imageUrl = "/images/managers.png",
                    linkUrl = "/RiskManagers",
                },
                new DashboardCard() {
                    title = "Ticket Managment",
                    description = "This page lets you respond to the tickets raiser by the user",
                    imageUrl = "/images/ickets.png",
                    linkUrl = "/Tickets",
                },
                new DashboardCard() {
                    title = "Feature Flags",
                    description = "This page lets you have control over the feature flags in application",
                    imageUrl = "/images/featureflags.png",
                    linkUrl = "/Feature",},
                };

            return View(cards);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestTCPIP.Models;

namespace TestTCPIP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string ip, string port, string message)
        {
            if (ip != null && port != null && message != null)
            {
                new TCPIPModel().SendMessage(ip, int.Parse(port), message);
                ViewData["message"] = message;
                ViewData["ip"] = ip;
                ViewData["port"] = port;
            }
            return View();
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
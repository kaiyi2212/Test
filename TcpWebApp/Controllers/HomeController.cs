using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TcpWebApp.Models;

namespace TcpWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController>? _logger;

        private readonly TcpClientClass? _tcpClientClass;

        public HomeController(TcpClientClass tcpClientClass)
        {
            _tcpClientClass = tcpClientClass;
        }

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Index()
        {
            string response = await _tcpClientClass?.SendMessageAsync("Hello, TCP Server!");
            ViewBag.Response = response;
            return View();
        }
    }
}

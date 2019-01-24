using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LearnOnDemand.Web.Models;
using LearnOnDemand.Interfaces;

namespace LearnOnDemand.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILearnOnDemandClient _learnOnDemandClient;
        public HomeController(ILearnOnDemandClient learnOnDemandClient)
        {
            _learnOnDemandClient = learnOnDemandClient;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _learnOnDemandClient.GetOrganizations());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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

using System.Threading.Tasks;
using LearnOnDemand.Interfaces;
using LearnOnDemand.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearnOnDemand.Web.Controllers
{
    [Authorize]
    public class OrganizationController : Controller
    {
        private readonly ILearnOnDemandClient _learnOnDemandClient;
        public OrganizationController(ILearnOnDemandClient learnOnDemandClient)
        {
            _learnOnDemandClient = learnOnDemandClient;
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _learnOnDemandClient.GetOrganization(id));
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _learnOnDemandClient.GetOrganization(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(OrganizationModel model)
        {
            await _learnOnDemandClient.UpdateOrganization(model);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrganizationModel model)
        {
            var id = await _learnOnDemandClient.CreateOrganization(model);

            return RedirectToAction("Details", "Organization", new { id });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _learnOnDemandClient.GetOrganization(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(OrganizationModel model)
        {
            await _learnOnDemandClient.DeleteOrganization(model.Id);

            return RedirectToAction("Index", "Home");
        }
    }
}
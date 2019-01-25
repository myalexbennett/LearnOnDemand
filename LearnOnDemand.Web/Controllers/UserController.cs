using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnOnDemand.Interfaces;
using LearnOnDemand.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnOnDemand.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly ILearnOnDemandClient _learnOnDemandClient;
        public UserController(ILearnOnDemandClient learnOnDemandClient)
        {
            _learnOnDemandClient = learnOnDemandClient;
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _learnOnDemandClient.GetUser(id));
        }

        public ActionResult Create(int organizationKey)
        {
            ViewBag.OrganizationKey = organizationKey;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserModel model)
        {
            var id = await _learnOnDemandClient.CreateUser(model);

            return RedirectToAction("Details", "User", new { id });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _learnOnDemandClient.GetUser(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserModel model)
        {
            await _learnOnDemandClient.UpdateUser(model);

            return RedirectToAction("Details", "Organization", new { id = model.OrganizationKey });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _learnOnDemandClient.GetUser(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UserModel model)
        {
            await _learnOnDemandClient.DeleteUser(model.Id);

            return RedirectToAction("Details", "Organization", new { id = model.OrganizationKey });
        }
    }
}
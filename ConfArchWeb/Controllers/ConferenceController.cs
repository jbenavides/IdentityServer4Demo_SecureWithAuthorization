using System.Threading.Tasks;
using ConfArchShared.Models;
using ConfArchWeb.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConfArchWeb.Controllers
{
    [Authorize]
    public class ConferenceController: Controller
    {
        private readonly ConferenceApiService service;

        public ConferenceController(ConferenceApiService service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Organizer - Conference Overview";
             return View(await service.GetAll());
        }

        [Authorize(Policy = "OrganizerAccessPolicy")]
        public IActionResult Add()
        {
            ViewBag.Title = "Organizer - Add Conference";
            return View(new ConferenceModel());
        }

        [HttpPost]
        [Authorize(Policy = "OrganizerAccessPolicy")]
        public async Task<IActionResult> Add(ConferenceModel model)
        {
            if (ModelState.IsValid)
                await service.Add(model);

            return RedirectToAction("Index");
        }
    }
}

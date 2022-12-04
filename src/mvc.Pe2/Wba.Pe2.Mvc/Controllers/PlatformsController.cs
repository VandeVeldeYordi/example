using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wba.Pe2.Domain;
using Wba.Pe2.Mvc.Data;
using Wba.Pe2.Mvc.ViewModels;

namespace Wba.Pe2.Mvc.Controllers
{
    public class PlatformsController : Controller
    {
        private readonly GameContext _gameContext;
        public PlatformsController(GameContext gameContext)
        {
            _gameContext = gameContext;
        }
        public IActionResult Index()
        {
            PlatFormIndexViewModel platFormIndexViewModel = new()
            {
                Platforms = _gameContext.Platforms
                .OrderBy(p => p.Name)
                .Select(p => new PlatformDetailsViewModel
                {
                    Id = p.Id,
                    Name = p.Name
                }).ToList(),
            };
            return View(platFormIndexViewModel);
        }
        public IActionResult Details (int id)
        {
            return base.View(LoadDetails(id));
        }
        [HttpGet]
        public IActionResult Edit (int id)
        {
            ViewBag.Action = "Edit";      
            return View(LoadDetails(id));
        }
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            PlatformDetailsViewModel platformDetailsViewModel = new();
            return View("Edit", platformDetailsViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PlatformDetailsViewModel platformDetailsViewModel)
        {
            return await Save(platformDetailsViewModel);
        }
        public IActionResult DeleteConfirmation(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        public IActionResult Delete(int id)
        {
            _gameContext.Platforms.Remove(new Platform { Id = id });
            _gameContext.SaveChanges();
            return RedirectToAction("Index");
        }   
        private async Task <IActionResult> Save (PlatformDetailsViewModel platformDetailsViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", platformDetailsViewModel);
            }
            Platform platform = new()
            {
                Id = platformDetailsViewModel.Id,
                Name = platformDetailsViewModel.Name
            };
            if (platformDetailsViewModel.Id !=0)
            {
                _gameContext.Platforms.Update(platform);
            }
            else
            {
                _gameContext.Platforms.Add(platform);
            }
            await _gameContext.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        private PlatformDetailsViewModel LoadDetails(int id)
        {
            return _gameContext.Platforms
                .Where(x => x.Id == id)
                .Select(x => new PlatformDetailsViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).FirstOrDefault();
        }       
    }
}

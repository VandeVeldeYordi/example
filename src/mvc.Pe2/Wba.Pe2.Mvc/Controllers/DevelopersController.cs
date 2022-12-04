using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Wba.Pe2.Domain;
using Wba.Pe2.Mvc.Data;
using Wba.Pe2.Mvc.ViewModels;
using Wba.Pe2.Mvc.ViewModels.DevVms;

namespace Wba.Pe2.Mvc.Controllers
{
    public class DevelopersController : Controller
    {
        private readonly GameContext _gameContext;
        public DevelopersController(GameContext gameContext)
        {
            _gameContext = gameContext;
        }
        public IActionResult Index()
        {
            DevelopersIndexViewModel developersIndexViewModel = new()
            {
                Developers = _gameContext.Developers
                .OrderBy(d => d.Name)
                .Select(d => new DevelopersDetailsViewModel
                {
                    Id = d.Id,
                    Name = d.Name
                }).ToList(),
            };
            developersIndexViewModel.DevelopersCount = developersIndexViewModel.Developers.Count; 
            return View(developersIndexViewModel);
        }
        public IActionResult Details (int id)
        {
            DevelopersInfoViewModel developersInfoViewModel = new();
            var developer = _gameContext.Developers
                .Include(d => d.Games)
                .FirstOrDefault(d => d.Id == id);
            developersInfoViewModel.Id = developer.Id;
            developersInfoViewModel.Name = developer.Name;
            developersInfoViewModel.GameIds = developer.Games.Select(d => d.Id);
            developersInfoViewModel.Games = developer.Games.Select(d => d.Name);
            return View(developersInfoViewModel);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var developersDetailVm = _gameContext
                .Developers
                .Select(d=> new DevelopersDetailsViewModel { Id = d.Id, Name = d.Name})
                .FirstOrDefault(d => d.Id == id);
            return View(developersDetailVm);
        }
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            DevelopersDetailsViewModel developersDetailsViewModel = new();
            return View("edit", developersDetailsViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit (DevelopersDetailsViewModel developersDetailsViewModel)
        {
            return await Save(developersDetailsViewModel);
        }
        public IActionResult DeleteConfirmation(int id)
        {
            ViewBag.Id = id;
            return View(); 
        }
        public IActionResult Delete(int id)
        {
            _gameContext.Developers.Remove(new Developer { Id = id });
            _gameContext.SaveChanges();
            return RedirectToAction("Index");
        }
        private async Task<IActionResult> Save(DevelopersDetailsViewModel developersDetailsViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit",developersDetailsViewModel);
            }
            Developer developer = new()
            {
                Id = developersDetailsViewModel.Id,
                Name = developersDetailsViewModel.Name
            };
            if (developersDetailsViewModel.Id != 0)
            {
                _gameContext.Developers.Update(developer);
            }
            else
            {
                _gameContext.Developers.Add(developer);
            }

            await _gameContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        //private async DevelopersInfoViewModel LoadDetails(int id)
        //{
        //    DevelopersInfoViewModel developersInfoViewModel = new();
        //    var developer =  _gameContext.Developers
        //        .Include(d => d.Games)
        //        .FirstOrDefault(d =>d.Id == id);
        //    developersInfoViewModel.Id = developer.Id; 
        //    developersInfoViewModel.Name = developer.Name;
        //    developersInfoViewModel.GameIds = developer.Games.Select(d => d.Id);
        //    developersInfoViewModel.Games = developer.Games.Select(d => d.Name);
        //    return View(developersInfoViewModel);
        //    //return _gameContext.Developers
        //    //    .Where(d => d.Id == id)
        //    //    .Select(d => new DevelopersInfoViewModel
        //    //    {
        //    //        Id = d.Id,
        //    //        Name = d.Name,
                 
                    
        //    //    }).FirstOrDefault();
        //}
    }
}

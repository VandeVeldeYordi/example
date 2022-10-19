using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Wba.Pe2.Domain;
using Wba.Pe2.Mvc.Data;
using Wba.Pe2.Mvc.ViewModels;

namespace Wba.Pe2.Mvc.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly GameContext _gameContext;
        public CategoriesController(GameContext gamesContext)
        {
            _gameContext = gamesContext;
        }
        public IActionResult Index()
        {
            CategoryIndexViewModel categoryIndexViewModel = new()
            {
                Categories = _gameContext.Categories
                .OrderBy(c => c.Name)
                .Select(c => new CategoryDetailsViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList(),
            };
            return View(categoryIndexViewModel);
        }
        public IActionResult Details(int id)
        {
            return base.View(LoadDetails(id));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            return View(LoadDetails(id));
        }
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            CategoryDetailsViewModel categoryDetailsViewModel = new();
            return View("Edit",categoryDetailsViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDetailsViewModel categoryDetailsViewModel)
        {
            return await Save(categoryDetailsViewModel);
        }
        public IActionResult DeleteConfirmation(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        public IActionResult Delete(int id)
        {
            _gameContext.Categories.Remove(new Category { Id = id });
            _gameContext.SaveChanges();
            return RedirectToAction("Index");
        }
        private async Task<IActionResult> Save(CategoryDetailsViewModel categoryDetailsViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit",categoryDetailsViewModel);
            }
            Category category = new()
            {
                Id = categoryDetailsViewModel.Id,
                Name = categoryDetailsViewModel.Name

            };
            if (categoryDetailsViewModel.Id !=0)
            {
               _gameContext.Categories.Update(category); 
            }
            else
            {
                _gameContext.Categories.Add(category);
            }
            await _gameContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        private CategoryDetailsViewModel LoadDetails(int id)
        {
            return _gameContext.Categories
                .Where(c => c.Id == id)
                .Select(c => new CategoryDetailsViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                   

                }).FirstOrDefault();
        }
    }
}

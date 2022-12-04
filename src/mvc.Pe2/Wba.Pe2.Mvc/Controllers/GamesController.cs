using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Wba.Pe2.Domain;
using Wba.Pe2.Mvc.Data;
using Wba.Pe2.Mvc.Extensions;
using Wba.Pe2.Mvc.Services.Interfaces;
using Wba.Pe2.Mvc.ViewModels;
using Wba.Pe2.Mvc.ViewModels.GameUpdateVms;

namespace Wba.Pe2.Mvc.Controllers
{
    public class GamesController : Controller
    {
        private readonly GameContext _gameContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFileService _fileService;
        private readonly IFormHelpersService _formHelpersService;

        public GamesController(GameContext gameContext , IWebHostEnvironment webHostEnvironment , IFileService fileService , IFormHelpersService formHelpersService)
        {
            _fileService = fileService; ;
            _gameContext = gameContext; ;
            _webHostEnvironment = webHostEnvironment;
            _formHelpersService = formHelpersService;
        }

        public async  Task<IActionResult> Index()
        {
            GameIndexViewModel gameIndexViewModel = new();
            gameIndexViewModel.Games = await _gameContext.Games.Select(g => new GameBasicViewModel
            {
                Id = g.Id,
                Name = g.Name,
                ImagePath = g.ImagePath,
                Price = g.Price             
            }).ToListAsync();                 
            //gameIndexViewModel.GamesCount = gameIndexViewModel.Games.Count;
            return View(gameIndexViewModel);
        }
        [HttpGet]
        public IActionResult DeleteConfirmation(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _gameContext.Games.Remove(new Game { Id = id });
            _gameContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            GamesInfoViewModel gamesInfoViewModel = new();
            var game = await _gameContext.Games
                .Include(g => g.Characters)
                .Include(g=> g.Platforms)
                .Include(g => g.Properties)
                .Include(g => g.Developer)
                .Include(g => g.Category)
                .FirstOrDefaultAsync(g => g.Id == id);
            gamesInfoViewModel.Id = game?.Id ?? 0;
            gamesInfoViewModel.Title = game?.Name ?? "<no Title>";
            gamesInfoViewModel.ReleaseDate = game?.ReleaseDate ?? DateTime.Now;
            gamesInfoViewModel.ImagePath = game?.ImagePath ?? $"{ _webHostEnvironment.WebRootPath}/ images / placeholder.png";
            gamesInfoViewModel.Price = game?.Price ?? 0;
            gamesInfoViewModel.Developers = new BaseViewModel
            {
                Id = game?.DeveloperId ?? 0,
                Item = game?.Developer?.Name ?? "<NoName>"
            };
            gamesInfoViewModel.Category = new BaseViewModel
            {
                Id = game?.CategoryId ?? 0,
                Item = game?.Category?.Name ?? "<NoNAme>"
            };
            gamesInfoViewModel.Characters = game?.Characters.Select(
                c => new BaseViewModel
                {
                    Id = c?.Id,
                    Item = $"{c.Name}"
                }
                );
            gamesInfoViewModel.Platforms = game?.Platforms.Select(
                p => new BaseViewModel
                {
                    Id = p?.Id,
                    Item = $"{p.Name}"
                });
            gamesInfoViewModel.Properties = game?.Properties.Select(
                o => new BaseViewModel
                {
                    Id = o?.Id,
                    Item = $"{o.SubCategory }"
                });
            ViewBag.Action = game?.Name ?? "<no name>";
            return View(gamesInfoViewModel);
        }
        
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            GamesUpdateViewModel gamesUpdateViewModel = new();
            gamesUpdateViewModel.Characters =
                 await _formHelpersService.BuildCheckboxList(1);
            gamesUpdateViewModel.Platforms =
                await _formHelpersService.BuildCheckboxList(3);
            gamesUpdateViewModel.Properties =
                await _formHelpersService.BuildCheckboxList(2);
            gamesUpdateViewModel.Category =
                await _formHelpersService.BuildCategoryList();
            gamesUpdateViewModel.Developers =
                await _formHelpersService.BuildDeveloperList();
            gamesUpdateViewModel.ReleaseDate = DateTime.Now.Date;
            return View(gamesUpdateViewModel);
                
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(GamesUpdateViewModel gamesUpdateViewModel)
        {
            if (!ModelState.IsValid)
            {
                gamesUpdateViewModel.Developers
                    =await _formHelpersService.BuildDeveloperList();
                gamesUpdateViewModel.Category
                    = await _formHelpersService.BuildCategoryList();
                return View(gamesUpdateViewModel);               
            }
            Game newGame = new();
            newGame.Name = gamesUpdateViewModel.Title;
            newGame.CategoryId = gamesUpdateViewModel.CategoryId;
            newGame.ReleaseDate = gamesUpdateViewModel.ReleaseDate;
            newGame.DeveloperId = gamesUpdateViewModel.DeveloperId;
            newGame.Price = gamesUpdateViewModel.Price;
            if (gamesUpdateViewModel.Image != null)
            {
                if (!Path.GetExtension(gamesUpdateViewModel.Image.FileName).Equals(".png") )
                {
                    gamesUpdateViewModel.Developers 
                        = await _formHelpersService.BuildDeveloperList();
                    ModelState.AddModelError("", "Only .png images allowed");
                    return View(gamesUpdateViewModel);
                }
                newGame.ImagePath = await _fileService.StoreFile(gamesUpdateViewModel.Image, "games");
            }
            var selectedCharacters = gamesUpdateViewModel
                .Characters
                .Where(c => c.IsSelected == true).Select(c => c.Id);
            newGame.Characters = await _gameContext
                .Characters
                .Where(c => selectedCharacters.Contains(c.Id)).ToListAsync();

            var selectedPlatforms = gamesUpdateViewModel
                .Platforms.Where(p => p.IsSelected == true)
                .Select(p => p.Id);
            newGame.Platforms = await _gameContext
                .Platforms
                .Where(p => selectedPlatforms .Contains(p.Id)).ToListAsync();

            var selectedProperties = gamesUpdateViewModel
                .Properties
                .Where(o => o.IsSelected == true)
                .Select(o => o.Id);
            newGame.Properties = await _gameContext
                .Properties
                .Where(o => selectedProperties.Contains(o.Id)).ToListAsync();

            _gameContext.Games.Add(newGame); 
            await _gameContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            GamesUpdateViewModel gamesUpdateViewModel = new();
            var game = await _gameContext
                .Games
                .Include(g => g.Characters)
                .Include(g => g.Platforms)
                .Include(g=> g.Properties)
                .FirstOrDefaultAsync(g => g.Id == Id);

            gamesUpdateViewModel.Title = game?.Name ?? "<NoTitle>";
            gamesUpdateViewModel.ReleaseDate = game?.ReleaseDate ?? DateTime.Today;
            gamesUpdateViewModel.Id = game?.Id ?? 0;
            gamesUpdateViewModel.Price = game?.Price ?? 0;
            gamesUpdateViewModel.CategoryId = game?.CategoryId ?? 0;
            gamesUpdateViewModel.DeveloperId = game?.DeveloperId ?? 0;

            gamesUpdateViewModel.Characters
                = await _formHelpersService.BuildCheckboxList(1, game);
            gamesUpdateViewModel.Properties
                = await _formHelpersService.BuildCheckboxList(2, game);
            gamesUpdateViewModel.Platforms
                = await _formHelpersService.BuildCheckboxList(3, game);

            gamesUpdateViewModel.Developers = await _formHelpersService
                .BuildDeveloperList();
            gamesUpdateViewModel.Category = await _formHelpersService
                .BuildCategoryList();

            return View(gamesUpdateViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GamesUpdateViewModel gamesUpdateViewModel)
        {
            if (gamesUpdateViewModel.Image != null && !Path.GetExtension(gamesUpdateViewModel.Image?.FileName).Equals(".png"))
            {
                ModelState.AddModelError("", "Image must be .png");
            }
            if (!ModelState.IsValid)
            {
                gamesUpdateViewModel.Developers = await  _formHelpersService
                    .BuildDeveloperList();
                gamesUpdateViewModel.Category = await _formHelpersService
                    .BuildCategoryList();
                return View(gamesUpdateViewModel);
            }
            var game = await _gameContext
                .Games
                .Include(g => g.Characters)
                .Include(g => g.Platforms)
                .Include(g => g.Properties)
                .FirstOrDefaultAsync(g => g.Id == gamesUpdateViewModel.Id);
            game.Name = gamesUpdateViewModel.Title;
            game.ReleaseDate = gamesUpdateViewModel.ReleaseDate;
            game.Price = gamesUpdateViewModel.Price;
            game.CategoryId = gamesUpdateViewModel.CategoryId;
            game.DeveloperId = gamesUpdateViewModel.DeveloperId;

            var selectedCharacters = gamesUpdateViewModel.Characters.Where(c => c.IsSelected == true).Select(c => c.Id);
            game.Characters = await _gameContext.Characters.Where(c => selectedCharacters.Contains(c.Id)).ToListAsync();

            var selectedPlatforms = gamesUpdateViewModel.Platforms.Where(p => p.IsSelected == true).Select(p => p.Id);
            game.Platforms = await _gameContext.Platforms.Where(p=> selectedPlatforms.Contains(p.Id)).ToListAsync();

            var selectedProperties = gamesUpdateViewModel.Properties.Where(o => o.IsSelected==true).Select(o => o.Id);
            game.Properties = await _gameContext.Properties.Where(o => selectedProperties.Contains(o.Id)).ToListAsync();

            if (gamesUpdateViewModel.Image != null)
            {
                if (game.ImagePath == null)
                {
                    game.ImagePath = await _fileService.StoreFile(gamesUpdateViewModel.Image, "games");
                }
                else
                {
                    game.ImagePath = await _fileService
                        .StoreFile(gamesUpdateViewModel.Image, "games", game.ImagePath);
                }
            }
            await _gameContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
  }   
}

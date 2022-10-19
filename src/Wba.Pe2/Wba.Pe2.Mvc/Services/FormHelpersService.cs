using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wba.Pe2.Domain;
using Wba.Pe2.Mvc.Data;
using Wba.Pe2.Mvc.Models;
using Wba.Pe2.Mvc.Services.Interfaces;

namespace Wba.Pe2.Mvc.Services
{
    public class FormHelpersService : IFormHelpersService
    {
        private readonly GameContext _gameContext;

        public FormHelpersService(GameContext gameContext)
        {
         _gameContext = gameContext; ;
        }

        public async Task<List<SelectListItem>> BuildCategoryList()
        {
            return await _gameContext
                .Categories
                .Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() })
                .ToListAsync();
        }
        public async Task<List<SelectListItem>> BuildDeveloperList()
        {
            return await _gameContext
                .Developers
                .Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() })
                .ToListAsync();
        }

        public async Task<List<CheckboxHelper>> BuildCheckboxList(int isEntity)
        {
            if (isEntity == 1)
            {
                return await _gameContext.Characters.Select(a => new CheckboxHelper
                {
                    Id = a.Id,
                    Text = $"{a.Name}"
                }).ToListAsync();
            }
            else if (isEntity == 2)
            {
                return await _gameContext.Properties.Select(a => new CheckboxHelper
                {
                    Id = a.Id,
                    Text = $"{a.SubCategory}"
                }).ToListAsync();
            }

            else
            {
                return await _gameContext.Platforms.Select(d => new CheckboxHelper
                {
                    Id = d.Id,
                    Text = $"{d.Name}"
                }).ToListAsync();
            }
            
        }

        public async Task<List<CheckboxHelper>> BuildCheckboxList(int isEntity, Game editGame )
        {
            var checkboxList = await BuildCheckboxList(isEntity);
            foreach (var checkbox in checkboxList)
            {
                if (isEntity == 1)
                {
                    if (editGame.Characters.Any(m => m.Id == checkbox.Id))
                    {
                        checkbox.IsSelected = true;
                    }
                }
                else if (isEntity == 2)
                {
                    if (editGame.Properties.Any(m => m.Id == checkbox.Id))
                    {
                        checkbox.IsSelected = true;
                    }
                }
                else if(isEntity == 3)
                {
                    if (editGame.Platforms.Any(m => m.Id == checkbox.Id))
                    {
                        checkbox.IsSelected = true;
                    }
                }
            }
            return checkboxList;
        }
    }
}

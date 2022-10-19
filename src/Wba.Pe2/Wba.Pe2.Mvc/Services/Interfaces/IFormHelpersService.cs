using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wba.Pe2.Domain;
using Wba.Pe2.Mvc.Models;

namespace Wba.Pe2.Mvc.Services.Interfaces
{
    public interface IFormHelpersService
    {
        Task<List<SelectListItem>> BuildCategoryList();
        Task<List<SelectListItem>> BuildDeveloperList();
        public Task<List<CheckboxHelper>> BuildCheckboxList(int isEntity, Game editMovie);
        public Task<List<CheckboxHelper>> BuildCheckboxList(int isEntity);
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CityBreaks.Web.Models;
using CityBreaks.Web.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityBreaks.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICityService _cityService;
        private readonly IPropertyService _propertyService;
        public IList<City> Cities { get; set; } = new List<City>();

        public IndexModel(ICityService cityService, IPropertyService propertyService)
        {
            _cityService = cityService;
            _propertyService = propertyService;
        }

        public async Task OnGetAsync()
        {
            Cities = await _cityService.GetAllAsync();
        }

        public async Task<IActionResult> OnPostDeletePropertyAsync(int id)
        {
            await _propertyService.DeleteAsync(id);
            TempData["SuccessMessage"] = "Propriedade deletada (soft delete) com sucesso!";
            return RedirectToPage("/Index");
        }
    }
}
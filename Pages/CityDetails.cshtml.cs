using CityBreaks.Web.Models;
using CityBreaks.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Web.Pages
{
    public class CityDetailsModel : PageModel
    {
        private readonly ICityService _cityService;

        public City? City { get; set; }

        public CityDetailsModel(ICityService cityService)
        {
            _cityService = cityService;
        }

        public async Task<IActionResult> OnGetAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return RedirectToPage("/Index");
            }

            City = await _cityService.GetByNameAsync(name);

            if (City == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}

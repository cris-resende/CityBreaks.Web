using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CityBreaks.Web.Models;
using CityBreaks.Web.Services;
using CityBreaks.Web.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CityBreaks.Web.Pages
{
    public class CreatePropertyModel : PageModel
    {
        private readonly ICityService _cityService;
        private readonly CityBreaksContext _context;

        public CreatePropertyModel(ICityService cityService, CityBreaksContext context)
        {
            _cityService = cityService;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        public SelectList CityOptions { get; set; } = new SelectList(new List<City>(), "Id", "Name");

        public class InputModel
        {
            [Required(ErrorMessage = "O nome da propriedade é obrigatório.")]
            [StringLength(250, ErrorMessage = "O nome não pode exceder 250 caracteres.")]
            [Display(Name = "Nome da Propriedade")]
            public string Name { get; set; } = string.Empty;

            [Required(ErrorMessage = "O preço por noite é obrigatório.")]
            [Range(0.01, 10000.00, ErrorMessage = "O preço deve estar entre 0.01 e 10000.00.")]
            [Display(Name = "Preço por Noite")]
            public decimal PricePerNight { get; set; }

            [Required(ErrorMessage = "A cidade é obrigatória.")]
            [Display(Name = "Cidade")]
            public int CityId { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await PopulateCityDropdown();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await PopulateCityDropdown();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var newProperty = new Property
            {
                Name = Input.Name,
                PricePerNight = Input.PricePerNight,
                CityId = Input.CityId
            };

            await _context.Properties.AddAsync(newProperty);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Propriedade cadastrada com sucesso!";

            return RedirectToPage("/Index");
        }

        private async Task PopulateCityDropdown()
        {
            var cities = await _cityService.GetAllAsync();
            CityOptions = new SelectList(cities, "Id", "Name");
        }
    }
}
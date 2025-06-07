using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CityBreaks.Web.Models;
using CityBreaks.Web.Data;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace CityBreaks.Web.Pages
{
    public class EditPropertyModel : PageModel
    {
        private readonly CityBreaksContext _context;

        public EditPropertyModel(CityBreaksContext context)
        {
            _context = context;
        }

        public Property Property { get; set; } = default!;

        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        public class InputModel
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "O nome da propriedade é obrigatório.")]
            [StringLength(250, ErrorMessage = "O nome não pode exceder 250 caracteres.")]
            [Display(Name = "Nome da Propriedade")]
            public string Name { get; set; } = string.Empty;

            [Required(ErrorMessage = "O preço por noite é obrigatório.")]
            [Range(0.01, 10000.00, ErrorMessage = "O preço deve estar entre 0.01 e 10000.00.")]
            [Display(Name = "Preço por Noite")]
            public decimal PricePerNight { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Property = await _context.Properties
                                    .Include(p => p.City)
                                    .FirstOrDefaultAsync(p => p.Id == id);

            if (Property == null)
            {
                return NotFound();
            }

            Input.Id = Property.Id;
            Input.Name = Property.Name;
            Input.PricePerNight = Property.PricePerNight;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                this.Property = await _context.Properties
                                             .Include(p => p.City)
                                             .FirstOrDefaultAsync(p => p.Id == id);
                return Page();
            }

            int propertyIdToUpdate = id;
            if (propertyIdToUpdate == 0)
            {
                propertyIdToUpdate = Input.Id;
            }

            var propertyToUpdate = await _context.Properties.FindAsync(propertyIdToUpdate);

            if (propertyToUpdate == null)
            {
                return NotFound();
            }
            propertyToUpdate.Name = Input.Name;
            propertyToUpdate.PricePerNight = Input.PricePerNight;

            try
            {
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Propriedade atualizada com sucesso!";
                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocorreu um erro ao salvar a propriedade. Tente novamente.");
                this.Property = await _context.Properties
                                             .Include(p => p.City)
                                             .FirstOrDefaultAsync(p => p.Id == propertyIdToUpdate);
                return Page();
            }
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CityBreaks.Web.Models;
using CityBreaks.Web.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CityBreaks.Web.Pages
{
    public class FilterPropertiesModel : PageModel
    {
        private readonly IPropertyService _propertyService;

        public FilterPropertiesModel(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [BindProperty(SupportsGet = true)]
        [Display(Name = "Preço Mínimo")]
        public decimal? MinPrice { get; set; }

        [BindProperty(SupportsGet = true)]
        [Display(Name = "Preço Máximo")]
        public decimal? MaxPrice { get; set; }

        [BindProperty(SupportsGet = true)]
        [Display(Name = "Nome da Cidade")]
        public string? CityName { get; set; }

        [BindProperty(SupportsGet = true)]
        [Display(Name = "Nome da Propriedade")]
        public string? PropertyName { get; set; }

        public IList<Property> FilteredProperties { get; set; } = new List<Property>();


        public async Task OnGetAsync()
        {
            FilteredProperties = await _propertyService.GetFilteredAsync(
                MinPrice, MaxPrice, CityName, PropertyName
            );
        }
    }
}

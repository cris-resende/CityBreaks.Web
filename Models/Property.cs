using System.ComponentModel.DataAnnotations.Schema;

namespace CityBreaks.Web.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal PricePerNight { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }
    }
}

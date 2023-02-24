using HotelListing.Database;
using System.ComponentModel.DataAnnotations;

namespace HotelListing.DTOs
{
    public class CreateCountryDto
    {
        [Required]
        [StringLength(maximumLength: 150, ErrorMessage = "Country Name is too long")]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 2, ErrorMessage = "Short Country Name is too long")]
        public string ShortName { get; set; }
    }
    public class CountryDto : CreateCountryDto
    {
        public int Id { get; set; }
        public IList<HotelDto> Hotels { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace CitiesManager.WebApi.Models
{
    public class City
    {
        [Key]
        public Guid CityID { get; set; }
        [Required(ErrorMessage = "City Name Can't be blank")]
        public string? CityName { get; set; }
    }
}

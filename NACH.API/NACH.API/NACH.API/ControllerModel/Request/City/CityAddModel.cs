using System.ComponentModel.DataAnnotations;

namespace NACH.API.ControllerModel.Request.City
{
    public class CityAddModel : BaseRequestModel
    {
        [Required(ErrorMessage = "City Name is required")]
        [StringLength(15, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 4)]
        public string CityName { get; set; }

        [Required]
        public int StateCode { get; set; }
    }
}
